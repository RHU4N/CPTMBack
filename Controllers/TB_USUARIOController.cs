using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TB_USUARIOController : ControllerBase
    {
        private readonly ITB_USUARIORepository _usuarioRepository;
        private readonly ILogger<TB_USUARIOController> _logger;

        public TB_USUARIOController(
            ITB_USUARIORepository usuarioRepository,
            ILogger<TB_USUARIOController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all users (Admin only)
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll();

                if (!usuarios.Any())
                {
                    return Ok(new { dados = usuarios, total = 0 });
                }

                var dtos = usuarios.Select(u => MapToDTO(u)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} users");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving users: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar usuários", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get user by ID (Admin only)
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado" });
                }

                var dto = MapToDTO(usuario);

                _logger.LogInformation($"? Retrieved user: {id}");

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving user: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar usuário", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get user by login
        /// </summary>
        [HttpGet("by-login/{login}")]
        public IActionResult GetByLogin(string login)
        {
            try
            {
                var usuario = _usuarioRepository.GetAll()
                    .FirstOrDefault(u => u.dsLogin.ToLower() == login.ToLower());

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado" });
                }

                var dto = MapToDTO(usuario);

                _logger.LogInformation($"? Retrieved user by login: {login}");

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving user by login: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar usuário", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get users by profile/role (Admin only)
        /// </summary>
        [HttpGet("by-profile/{idPerfil}")]
        [Authorize(Roles = "admin")]
        public IActionResult GetByProfile(int idPerfil)
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll()
                    .Where(u => u.idPerfil == idPerfil)
                    .ToList();

                var dtos = usuarios.Select(u => MapToDTO(u)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} users with profile {idPerfil}");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving users by profile: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar usuários", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get active users (Admin only)
        /// </summary>
        [HttpGet("filter/active")]
        [Authorize(Roles = "admin")]
        public IActionResult GetActive()
        {
            try
            {
                var usuarios = _usuarioRepository.GetAll()
                    .Where(u => u.flAtivo)
                    .ToList();

                var dtos = usuarios.Select(u => MapToDTO(u)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} active users");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving active users: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar usuários ativos", erro = ex.Message });
            }
        }

        /// <summary>
        /// Deactivate user (Admin only)
        /// </summary>
        [HttpPut("{id}/deactivate")]
        [Authorize(Roles = "admin")]
        public IActionResult DeactivateUser(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado" });
                }

                usuario.SetActive(false);
                _usuarioRepository.Update(usuario);

                _logger.LogInformation($"? User deactivated: {id}");

                return Ok(new { mensagem = "Usuário desativado com sucesso", dados = MapToDTO(usuario) });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error deactivating user: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao desativar usuário", erro = ex.Message });
            }
        }

        /// <summary>
        /// Activate user (Admin only)
        /// </summary>
        [HttpPut("{id}/activate")]
        [Authorize(Roles = "admin")]
        public IActionResult ActivateUser(int id)
        {
            try
            {
                var usuario = _usuarioRepository.Get(id);

                if (usuario == null)
                {
                    return NotFound(new { mensagem = "Usuário não encontrado" });
                }

                usuario.SetActive(true);
                _usuarioRepository.Update(usuario);

                _logger.LogInformation($"? User activated: {id}");

                return Ok(new { mensagem = "Usuário ativado com sucesso", dados = MapToDTO(usuario) });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error activating user: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao ativar usuário", erro = ex.Message });
            }
        }

        // ===== HELPER METHODS =====

        private TB_USUARIODTO MapToDTO(TB_USUARIO usuario)
        {
            return new TB_USUARIODTO
            {
                idUsuario = usuario.idUsuario,
                nmUsuario = usuario.nmUsuario,
                dsLogin = usuario.dsLogin,
                dsEmail = usuario.dsEmail,
                idPerfil = usuario.idPerfil,
                flAtivo = usuario.flAtivo,
                dtCadastro = usuario.dtCadastro
            };
        }
    }
}
