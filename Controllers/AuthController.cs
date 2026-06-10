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
        /// Login — retorna token JWT e flag primeiroAcesso.
        /// Se primeiroAcesso = true, o frontend deve redirecionar para /trocar-senha.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.dsLogin) || string.IsNullOrWhiteSpace(model.dsSenha))
                    return BadRequest(new { mensagem = "Login e senha sao obrigatorios" });

                var usuario = _usuarioRepository.GetAll()
                    .FirstOrDefault(u => u.dsLogin.ToLower() == model.dsLogin.ToLower());

                if (usuario == null)
                {
                    _logger.LogWarning("Tentativa de login com usuario inexistente: {Login}", model.dsLogin);
                    return Unauthorized(new { mensagem = "Usuario ou senha invalidos" });
                }

                if (!usuario.flAtivo)
                {
                    _logger.LogWarning("Tentativa de login com usuario inativo: {Login}", model.dsLogin);
                    return Unauthorized(new { mensagem = "Usuario inativo. Contate o administrador." });
                }

                var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.dsSenhaHash, model.dsSenha);
                if (result == PasswordVerificationResult.Failed)
                {
                    _logger.LogWarning("Senha incorreta para usuario: {Login}", model.dsLogin);
                    return Unauthorized(new { mensagem = "Usuario ou senha invalidos" });
                }

                var token = _jwtTokenService.GenerateToken(usuario);

                _logger.LogInformation("Login realizado: {Login} | primeiroAcesso={PA}", model.dsLogin, usuario.flPrimeiroAcesso);

                return Ok(new AuthResponseViewModel
                {
                    sucesso = true,
                    mensagem = usuario.flPrimeiroAcesso
                        ? "Primeiro acesso detectado. Troca de senha obrigatoria."
                        : "Login realizado com sucesso",
                    token = token,
                    idUsuario = usuario.idUsuario,
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    dsEmail = usuario.dsEmail,
                    idPerfil = usuario.idPerfil,
                    primeiroAcesso = usuario.flPrimeiroAcesso
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao realizar login");
                return BadRequest(new { mensagem = "Erro ao realizar login", erro = ex.Message });
            }
        }

        /// <summary>
        /// Retorna dados do usuario autenticado pelo token.
        /// </summary>
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            try
            {
                var userIdClaim = User.FindFirst("sub")?.Value;
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(new { mensagem = "Token invalido" });

                var usuario = _usuarioRepository.Get(userId);
                if (usuario == null)
                    return NotFound(new { mensagem = "Usuario nao encontrado" });

                return Ok(new TB_USUARIODTO
                {
                    idUsuario = usuario.idUsuario,
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    dsEmail = usuario.dsEmail,
                    idPerfil = usuario.idPerfil,
                    flAtivo = usuario.flAtivo,
                    flPrimeiroAcesso = usuario.flPrimeiroAcesso,
                    dtUltimaTrocaSenha = usuario.dtUltimaTrocaSenha,
                    dtCadastro = usuario.dtCadastro,
                    dtAtualizacao = usuario.dtAtualizacao
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter dados do usuario autenticado");
                return BadRequest(new { mensagem = "Erro ao obter dados do usuario", erro = ex.Message });
            }
        }

        /// <summary>
        /// Renova o token JWT.
        /// </summary>
        [Authorize]
        [HttpPost("refresh")]
        public IActionResult RefreshToken()
        {
            try
            {
                var userIdClaim = User.FindFirst("sub")?.Value;
                if (!int.TryParse(userIdClaim, out var userId))
                    return Unauthorized(new { mensagem = "Token invalido" });

                var usuario = _usuarioRepository.Get(userId);
                if (usuario == null || !usuario.flAtivo)
                    return Unauthorized(new { mensagem = "Usuario nao encontrado ou inativo" });

                var newToken = _jwtTokenService.GenerateToken(usuario);

                _logger.LogInformation("Token renovado para usuario: {Login}", usuario.dsLogin);

                return Ok(new AuthResponseViewModel
                {
                    sucesso = true,
                    mensagem = "Token renovado com sucesso",
                    token = newToken,
                    idUsuario = usuario.idUsuario,
                    nmUsuario = usuario.nmUsuario,
                    dsLogin = usuario.dsLogin,
                    dsEmail = usuario.dsEmail,
                    idPerfil = usuario.idPerfil,
                    primeiroAcesso = usuario.flPrimeiroAcesso
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao renovar token");
                return BadRequest(new { mensagem = "Erro ao renovar token", erro = ex.Message });
            }
        }

        /// <summary>
        /// Criacao de conta restrita a administradores.
        /// Usuarios novos devem ser criados pelo admin via /api/TB_USUARIO.
        /// </summary>
        [Authorize(Roles = "admin")]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.nmUsuario) ||
                    string.IsNullOrWhiteSpace(model.dsLogin) ||
                    string.IsNullOrWhiteSpace(model.dsSenha))
                    return BadRequest(new { mensagem = "Nome, login e senha sao obrigatorios" });

                if (model.dsSenha != model.dsSenhaConfirm)
                    return BadRequest(new { mensagem = "As senhas nao conferem" });

                var existingUsers = _usuarioRepository.GetAll().ToList();
                if (existingUsers.Any(u => u.dsLogin.ToLower() == model.dsLogin.ToLower()))
                    return Conflict(new { mensagem = "Login ja existe" });

                var senhaHash = _passwordHasher.HashPassword(null!, model.dsSenha);
                var nextId = existingUsers.Any() ? existingUsers.Max(u => u.idUsuario) + 1 : 1;

                var newUser = new TB_USUARIO(
                    idUsuario: nextId,
                    nmUsuario: model.nmUsuario,
                    dsLogin: model.dsLogin,
                    dsSenhaHash: senhaHash,
                    idPerfil: model.idPerfil,
                    dsEmail: model.dsEmail,
                    flAtivo: true,
                    flPrimeiroAcesso: true
                );

                _usuarioRepository.Add(newUser);
                _logger.LogInformation("Usuario registrado via admin: {Login}", model.dsLogin);

                return Ok(new { sucesso = true, mensagem = "Usuario registrado com sucesso", idUsuario = newUser.idUsuario });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao registrar usuario");
                return BadRequest(new { mensagem = "Erro ao registrar usuario", erro = ex.Message });
            }
        }
    }
}
