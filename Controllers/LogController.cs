using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using CPTMBack.Infraestrutura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly ConnectContext _context;
        private readonly ITB_LOG_ACAORepository _logAcaoRepository;
        private readonly ITB_LOG_SINCRONIZACAORepository _logSyncRepository;
        private readonly ILogger<LogController> _logger;

        public LogController(
            ConnectContext context,
            ITB_LOG_ACAORepository logAcaoRepository,
            ITB_LOG_SINCRONIZACAORepository logSyncRepository,
            ILogger<LogController> logger)
        {
            _context = context;
            _logAcaoRepository = logAcaoRepository;
            _logSyncRepository = logSyncRepository;
            _logger = logger;
        }

        // GET /api/log/acoes
        [HttpGet("acoes")]
        [Authorize(Roles = "admin")]
        public IActionResult GetLogsAcao(
            [FromQuery] int? idUsuario = null,
            [FromQuery] string? dsLogin = null,
            [FromQuery] string? dsAcao = null,
            [FromQuery] string? nmTabela = null,
            [FromQuery] DateTime? dtInicio = null,
            [FromQuery] DateTime? dtFim = null,
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanhoPagina = 50)
        {
            try
            {
                var logs = _logAcaoRepository.GetAll().AsQueryable();

                if (idUsuario.HasValue)
                    logs = logs.Where(l => l.idUsuario == idUsuario.Value);

                if (!string.IsNullOrWhiteSpace(dsLogin))
                {
                    var ids = _context.TB_USUARIO.AsNoTracking()
                        .Where(u => u.dsLogin.ToUpper().Contains(dsLogin.ToUpper()))
                        .Select(u => u.idUsuario)
                        .ToList();
                    logs = logs.Where(l => ids.Contains(l.idUsuario));
                }

                if (!string.IsNullOrWhiteSpace(dsAcao))
                    logs = logs.Where(l => l.dsAcao.ToUpper().Contains(dsAcao.ToUpper()));

                if (!string.IsNullOrWhiteSpace(nmTabela))
                    logs = logs.Where(l => l.nmTabela.ToUpper().Contains(nmTabela.ToUpper()));

                if (dtInicio.HasValue)
                    logs = logs.Where(l => l.dtAcao >= dtInicio.Value);

                if (dtFim.HasValue)
                    logs = logs.Where(l => l.dtAcao <= dtFim.Value.AddDays(1));

                var total = logs.Count();
                var paginados = logs
                    .OrderByDescending(l => l.dtAcao)
                    .Skip((pagina - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .ToList();

                // Enriquecer com login do usuário
                var usuarioIds = paginados.Select(l => l.idUsuario).Distinct().ToList();
                var usuarios = _context.TB_USUARIO.AsNoTracking()
                    .Where(u => usuarioIds.Contains(u.idUsuario))
                    .ToDictionary(u => u.idUsuario, u => u.dsLogin);

                var dtos = paginados.Select(l => new
                {
                    l.idLog,
                    l.idUsuario,
                    dsLogin = usuarios.GetValueOrDefault(l.idUsuario, $"ID:{l.idUsuario}"),
                    l.dsAcao,
                    l.nmTabela,
                    l.idRegistro,
                    l.dtAcao,
                    l.dsIp
                }).ToList();

                return Ok(new { dados = dtos, total, pagina, tamanhoPagina });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar logs de ação");
                return BadRequest(new { mensagem = "Erro ao recuperar logs de ação", erro = ex.Message });
            }
        }

        // GET /api/log/sincronizacoes
        [HttpGet("sincronizacoes")]
        [Authorize(Roles = "admin")]
        public IActionResult GetLogsSincronizacao(
            [FromQuery] int? idUsuario = null,
            [FromQuery] string? dsLogin = null,
            [FromQuery] string? dsStatus = null,
            [FromQuery] DateTime? dtInicio = null,
            [FromQuery] DateTime? dtFim = null,
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanhoPagina = 50)
        {
            try
            {
                var logs = _logSyncRepository.GetAll().AsQueryable();

                if (idUsuario.HasValue)
                    logs = logs.Where(l => l.idUsuario == idUsuario.Value);

                if (!string.IsNullOrWhiteSpace(dsLogin))
                {
                    var ids = _context.TB_USUARIO.AsNoTracking()
                        .Where(u => u.dsLogin.ToUpper().Contains(dsLogin.ToUpper()))
                        .Select(u => u.idUsuario)
                        .ToList();
                    logs = logs.Where(l => ids.Contains(l.idUsuario));
                }

                if (!string.IsNullOrWhiteSpace(dsStatus))
                    logs = logs.Where(l => l.dsStatus.ToUpper().Contains(dsStatus.ToUpper()));

                if (dtInicio.HasValue)
                    logs = logs.Where(l => l.dtSincronizacao >= dtInicio.Value);

                if (dtFim.HasValue)
                    logs = logs.Where(l => l.dtSincronizacao <= dtFim.Value.AddDays(1));

                var total = logs.Count();
                var paginados = logs
                    .OrderByDescending(l => l.dtSincronizacao)
                    .Skip((pagina - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .ToList();

                var usuarioIds = paginados.Select(l => l.idUsuario).Distinct().ToList();
                var usuarios = _context.TB_USUARIO.AsNoTracking()
                    .Where(u => usuarioIds.Contains(u.idUsuario))
                    .ToDictionary(u => u.idUsuario, u => u.dsLogin);

                var dtos = paginados.Select(l => new
                {
                    l.idLog,
                    l.idUsuario,
                    dsLogin = usuarios.GetValueOrDefault(l.idUsuario, $"ID:{l.idUsuario}"),
                    l.dsStatus,
                    l.dtSincronizacao,
                    l.dsMensagem
                }).ToList();

                return Ok(new { dados = dtos, total, pagina, tamanhoPagina });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar logs de sincronização");
                return BadRequest(new { mensagem = "Erro ao recuperar logs de sincronização", erro = ex.Message });
            }
        }

        // POST /api/log/sincronizacoes  — Registrar evento de sincronização
        [HttpPost("sincronizacoes")]
        public IActionResult RegistrarSincronizacao([FromBody] RegistrarSyncDTO dto)
        {
            try
            {
                var userId = ObterIdUsuarioLogado();
                if (userId == 0)
                    return Unauthorized(new { mensagem = "Token inválido" });

                if (string.IsNullOrWhiteSpace(dto?.dsStatus))
                    return BadRequest(new { mensagem = "Status é obrigatório" });

                var log = new TB_LOG_SINCRONIZACAO(
                    idUsuario: userId,
                    dsStatus: dto.dsStatus.Trim(),
                    dtSincronizacao: DateTime.UtcNow,
                    dsMensagem: dto.dsMensagem?.Trim()
                );

                _logSyncRepository.Add(log);
                _logger.LogInformation("Sync log registrado: {Status} | usuario {Id}", dto.dsStatus, userId);

                return Ok(new { sucesso = true, idLog = log.idLog });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao registrar log de sincronização");
                return BadRequest(new { mensagem = "Erro ao registrar log", erro = ex.Message });
            }
        }

        private int ObterIdUsuarioLogado()
        {
            var claim = User.FindFirst("sub")?.Value ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(claim, out var id) ? id : 0;
        }
    }

    public class RegistrarSyncDTO
    {
        public string dsStatus { get; set; } = string.Empty;
        public string? dsMensagem { get; set; }
    }
}
