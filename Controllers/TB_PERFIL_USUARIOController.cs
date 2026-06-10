using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TB_PERFIL_USUARIOController : ControllerBase
    {
        private readonly ITB_PERFIL_USUARIORepository _perfilRepository;
        private readonly ILogger<TB_PERFIL_USUARIOController> _logger;

        public TB_PERFIL_USUARIOController(
            ITB_PERFIL_USUARIORepository perfilRepository,
            ILogger<TB_PERFIL_USUARIOController> logger)
        {
            _perfilRepository = perfilRepository;
            _logger = logger;
        }

        /// <summary>
        /// Lista todos os perfis de usuario cadastrados na tabela TB_PERFIL_USUARIO.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var perfis = _perfilRepository.GetAll()
                    .Select(p => new { p.idPerfil, p.dsPerfil })
                    .ToList();

                return Ok(new { dados = perfis, total = perfis.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar perfis de usuario");
                return BadRequest(new { mensagem = "Erro ao recuperar perfis", erro = ex.Message });
            }
        }
    }
}
