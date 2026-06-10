using CPTMBack.Application.ViewModels;
using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using CPTMBack.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITB_USUARIORepository _usuarioRepository;
        private readonly IPasswordHasher<TB_USUARIO> _passwordHasher;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ITB_USUARIORepository usuarioRepository,
            IPasswordHasher<TB_USUARIO> passwordHasher,
            IJwtTokenService jwtTokenService,
            ILogger<AuthController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenService = jwtTokenService;
            _logger = logger;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(model.nmUsuario) ||
                    string.IsNullOrWhiteSpace(model.dsLogin) ||
                    string.IsNullOrWhiteSpace(model.dsSenha))
                {
                    return BadRequest(new { mensagem = "Nome de usu�rio, login e senha s�o obrigat�rios" });
                }

                // Validate password confirmation
                if (model.dsSenha != model.dsSenhaConfirm)
                {
                    return BadRequest(new { mensagem = "As senhas n�o conferem" });
                }

                // Check if user already exists
                var existingUsers = _usuarioRepository.GetAll();
                if (existingUsers.Any(u => u.dsLogin.ToLower() == model.dsLogin.ToLower()))
                {
                    return Conflict(new { mensagem = "Usu�rio j� existe" });
                }

                // Hash password
                var senhaHash = _passwordHasher.HashPassword(null, model.dsSenha);

                // Create new user
                var newUser = new TB_USUARIO(
                    idUsuario: existingUsers.Max(u => u.idUsuario) + 1,
                    nmUsuario: model.nmUsuario,
                    dsLogin: model.dsLogin,
                    dsSenhaHash: senhaHash,
                    idPerfil: model.idPerfil,
                    dsEmail: model.dsEmail,
                    flAtivo: true
                );

                // Save user
                _usuarioRepository.Add(newUser);

                _logger.LogInformation($"? New user registered: {model.dsLogin}");

                return Ok(new { 
                    sucesso = true,
                    mensagem = "Usu�rio registrado com sucesso",
                    idUsuario = newUser.idUsuario
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error registering user: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao registrar usu�rio", erro = ex.Message });
            }
        }

        /// <summary>
        /// Login and get JWT token
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(model.dsLogin) || string.IsNullOrWhiteSpace(model.dsSenha))
                {
                    return BadRequest(new { mensagem = "Login e senha s�o obrigat�rios" });
                }

                // Find user
                var usuario = _usuarioRepository.GetAll()
                    .FirstOrDefault(u => u.dsLogin.ToLower() == model.dsLogin.ToLower());

                if (usuario == null)
                {
                    _logger.LogWarning($"?? Login attempt with non-existent user: {model.dsLogin}");
                    return Unauthorized(new { mensagem = "Usu�rio ou senha inv�lidos" });
                }

                // Check if user is active
                if (!usuario.flAtivo)
                {
                    _logger.LogWarning($"?? Login attempt with inactive user: {model.dsLogin}");
                    return Unauthorized(new { mensagem = "Usu�rio inativo" });
                }

                // Verify password
                var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.dsSenhaHash, model.dsSenha);

                if (result == PasswordVerificationResult.Failed)
                {
                    _logger.LogWarning($"?? Failed login attempt: {model.dsLogin}");
                    return Unauthorized(new { mensagem = "Usu�rio ou senha inv�lidos" });
                }

                // Generate JWT token
                var token = _jwtTokenService.GenerateToken(usuario);

                _logger.LogInformation($"? User logged in successfully: {model.dsLogin}");

                return Ok(new AuthResponseViewModel
                {
                    sucesso = true,
                    mensagem = "Login realizado com sucesso",
                    token = token,
                    idUsuario = usuario.idUsuario,
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    dsEmail = usuario.dsEmail,
                    idPerfil = usuario.idPerfil
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error during login: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao realizar login", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get current user info
        /// </summary>
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            try
            {
                var userIdClaim = User.FindFirst("sub")?.Value;

                if (!int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized(new { mensagem = "Token inv�lido" });
                }

                var usuario = _usuarioRepository.Get(userId);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usu�rio n�o encontrado" });
                }

                var dto = new TB_USUARIODTO
                {
                    idUsuario = usuario.idUsuario,
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    dsEmail = usuario.dsEmail,
                    idPerfil = usuario.idPerfil,
                    flAtivo = usuario.flAtivo,
                    dtCadastro = usuario.dtCadastro
                };

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error getting current user: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao obter dados do usu�rio", erro = ex.Message });
            }
        }

        /// <summary>
        /// Refresh JWT token
        /// </summary>
        [Authorize]
        [HttpPost("refresh")]
        public IActionResult RefreshToken()
        {
            try
            {
                var userIdClaim = User.FindFirst("sub")?.Value;

                if (!int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized(new { mensagem = "Token inv�lido" });
                }

                var usuario = _usuarioRepository.Get(userId);

                if (usuario == null || !usuario.flAtivo)
                {
                    return Unauthorized(new { mensagem = "Usu�rio n�o encontrado ou inativo" });
                }

                var newToken = _jwtTokenService.GenerateToken(usuario);

                _logger.LogInformation($"? Token refreshed for user: {usuario.dsLogin}");

                return Ok(new AuthResponseViewModel
                {
                    sucesso = true,
                    mensagem = "Token renovado com sucesso",
                    token = newToken,
                    idUsuario = usuario.idUsuario,
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    idPerfil = usuario.idPerfil
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error refreshing token: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao renovar token", erro = ex.Message });
            }
        }
    }
}
