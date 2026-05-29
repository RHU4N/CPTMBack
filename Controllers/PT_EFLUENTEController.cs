using CPTMBack.Application.ViewModels;
using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PT_EFLUENTEController : ControllerBase
    {
        private readonly IPT_EFLUENTERepository _efluenteRepository;
        private readonly ILogger<PT_EFLUENTEController> _logger;

        public PT_EFLUENTEController(
            IPT_EFLUENTERepository efluenteRepository,
            ILogger<PT_EFLUENTEController> logger)
        {
            _efluenteRepository = efluenteRepository;
            _logger = logger;
        }

        /// <summary>
        /// Get all efluentes
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var efluentes = _efluenteRepository.GetAll();

                if (!efluentes.Any())
                {
                    return Ok(new { dados = efluentes, total = 0 });
                }

                var dtos = efluentes.Select(e => MapToDTO(e)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} efluentes");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving efluentes: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar efluentes", erro = ex.Message });
            }
        }

        /// <summary>
        /// Get efluente by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var efluente = _efluenteRepository.Get(id);

                if (efluente == null)
                {
                    return NotFound(new { mensagem = "Efluente não encontrado" });
                }

                var dto = MapToDTO(efluente);

                _logger.LogInformation($"? Retrieved efluente: {id}");

                return Ok(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error retrieving efluente: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao recuperar efluente", erro = ex.Message });
            }
        }

        /// <summary>
        /// Search efluentes by status
        /// </summary>
        [HttpGet("search/by-status/{idStatusDesvio}")]
        public IActionResult GetByStatus(int idStatusDesvio)
        {
            try
            {
                var efluentes = _efluenteRepository.GetAll()
                    .Where(e => e.idStatusDesvio == idStatusDesvio)
                    .ToList();

                var dtos = efluentes.Select(e => MapToDTO(e)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} efluentes with status {idStatusDesvio}");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error searching by status: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao buscar por status", erro = ex.Message });
            }
        }

        /// <summary>
        /// Search efluentes by municipality
        /// </summary>
        [HttpGet("search/by-municipality/{idMunicipio}")]
        public IActionResult GetByMunicipality(int idMunicipio)
        {
            try
            {
                var efluentes = _efluenteRepository.GetAll()
                    .Where(e => e.idMunicipio == idMunicipio)
                    .ToList();

                var dtos = efluentes.Select(e => MapToDTO(e)).ToList();

                _logger.LogInformation($"? Retrieved {dtos.Count} efluentes in municipality {idMunicipio}");

                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error searching by municipality: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao buscar por município", erro = ex.Message });
            }
        }

        /// <summary>
        /// Create new efluente
        /// </summary>
        [HttpPost]
        public IActionResult Create([FromBody] PT_EFLUENTEViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.pkCdMeioAmbienteCptm))
                {
                    return BadRequest(new { mensagem = "Código do meio ambiente é obrigatório" });
                }

                // Check if already exists
                var existing = _efluenteRepository.Get(model.pkCdMeioAmbienteCptm);
                if (existing != null)
                {
                    return Conflict(new { mensagem = "Efluente já existe" });
                }

                var efluente = new PT_EFLUENTE(
                    pkCdMeioAmbienteCptm: model.pkCdMeioAmbienteCptm,
                    idDeptoCampoAmbiente: model.idDeptoCampoAmbiente,
                    idStatusDesvio: model.idStatusDesvio,
                    idStatusRegistro: model.idStatusRegistro,
                    idMunicipio: model.idMunicipio,
                    idLinha: model.idLinha,
                    idVia: model.idVia,
                    idTrecho: model.idTrecho,
                    idTipoEfluente: model.idTipoEfluente,
                    txNrElementoMonitoramento: model.txNrElementoMonitoramento,
                    txNmElementoMonitoramento: model.txNmElementoMonitoramento,
                    txKmPoste: model.txKmPoste,
                    txEndereco: model.txEndereco,
                    txCoordenadaX: model.txCoordenadaX,
                    txCoordenadaY: model.txCoordenadaY,
                    dtRegistro: DateTime.Now,
                    dtAtualizacao: DateTime.Now,
                    txNomeTecnicoResponsavel: model.txNomeTecnicoResponsavel,
                    txEmailTecnicoResponsavel: model.txEmailTecnicoResponsavel,
                    txTelefoneTecnicoResponsavel: model.txTelefoneTecnicoResponsavel,
                    txEmpresaContratada: model.txEmpresaContratada,
                    txNumeroContrato: model.txNumeroContrato,
                    txProcessoAmbiental: model.txProcessoAmbiental,
                    txOrigemEfluente: model.txOrigemEfluente,
                    txDestinacaoEfluente: model.txDestinacaoEfluente,
                    txVolumeEfluente: model.txVolumeEfluente,
                    txUnidadeVolume: model.txUnidadeVolume,
                    txCorEfluente: model.txCorEfluente,
                    txOdorEfluente: model.txOdorEfluente,
                    txPh: model.txPh,
                    txTemperatura: model.txTemperatura,
                    txObservacao: model.txObservacao,
                    txLinkMapa: model.txLinkMapa,
                    txNomeFoto01: model.txNomeFoto01,
                    txNomeFoto02: model.txNomeFoto02,
                    txNomeFoto03: model.txNomeFoto03,
                    txNomeFoto04: model.txNomeFoto04
                );

                _efluenteRepository.Add(efluente);

                _logger.LogInformation($"? Efluente created: {model.pkCdMeioAmbienteCptm}");

                return CreatedAtAction(nameof(GetById), new { id = model.pkCdMeioAmbienteCptm }, MapToDTO(efluente));
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error creating efluente: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao criar efluente", erro = ex.Message });
            }
        }

        /// <summary>
        /// Update efluente
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PT_EFLUENTEViewModel model)
        {
            try
            {
                var efluente = _efluenteRepository.Get(id);

                if (efluente == null)
                {
                    return NotFound(new { mensagem = "Efluente não encontrado" });
                }

                // Update properties
                efluente = new PT_EFLUENTE(
                    pkCdMeioAmbienteCptm: efluente.pkCdMeioAmbienteCptm,
                    idDeptoCampoAmbiente: model.idDeptoCampoAmbiente,
                    idStatusDesvio: model.idStatusDesvio,
                    idStatusRegistro: model.idStatusRegistro,
                    idMunicipio: model.idMunicipio,
                    idLinha: model.idLinha,
                    idVia: model.idVia,
                    idTrecho: model.idTrecho,
                    idTipoEfluente: model.idTipoEfluente,
                    txNrElementoMonitoramento: model.txNrElementoMonitoramento,
                    txNmElementoMonitoramento: model.txNmElementoMonitoramento,
                    txKmPoste: model.txKmPoste,
                    txEndereco: model.txEndereco,
                    txCoordenadaX: model.txCoordenadaX,
                    txCoordenadaY: model.txCoordenadaY,
                    dtRegistro: efluente.dtRegistro,
                    dtAtualizacao: DateTime.Now,
                    txNomeTecnicoResponsavel: model.txNomeTecnicoResponsavel,
                    txEmailTecnicoResponsavel: model.txEmailTecnicoResponsavel,
                    txTelefoneTecnicoResponsavel: model.txTelefoneTecnicoResponsavel,
                    txEmpresaContratada: model.txEmpresaContratada,
                    txNumeroContrato: model.txNumeroContrato,
                    txProcessoAmbiental: model.txProcessoAmbiental,
                    txOrigemEfluente: model.txOrigemEfluente,
                    txDestinacaoEfluente: model.txDestinacaoEfluente,
                    txVolumeEfluente: model.txVolumeEfluente,
                    txUnidadeVolume: model.txUnidadeVolume,
                    txCorEfluente: model.txCorEfluente,
                    txOdorEfluente: model.txOdorEfluente,
                    txPh: model.txPh,
                    txTemperatura: model.txTemperatura,
                    txObservacao: model.txObservacao,
                    txLinkMapa: model.txLinkMapa,
                    txNomeFoto01: model.txNomeFoto01,
                    txNomeFoto02: model.txNomeFoto02,
                    txNomeFoto03: model.txNomeFoto03,
                    txNomeFoto04: model.txNomeFoto04
                );

                _efluenteRepository.Update(efluente);

                _logger.LogInformation($"? Efluente updated: {id}");

                return Ok(new { mensagem = "Efluente atualizado com sucesso", dados = MapToDTO(efluente) });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error updating efluente: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao atualizar efluente", erro = ex.Message });
            }
        }

        /// <summary>
        /// Delete efluente
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                var efluente = _efluenteRepository.Get(id);

                if (efluente == null)
                {
                    return NotFound(new { mensagem = "Efluente não encontrado" });
                }

                _efluenteRepository.Delete(id);

                _logger.LogInformation($"? Efluente deleted: {id}");

                return Ok(new { mensagem = "Efluente deletado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError($"? Error deleting efluente: {ex.Message}");
                return BadRequest(new { mensagem = "Erro ao deletar efluente", erro = ex.Message });
            }
        }

        // ===== HELPER METHODS =====

        private PT_EFLUENTEDTO MapToDTO(PT_EFLUENTE efluente)
        {
            return new PT_EFLUENTEDTO
            {
                pkCdMeioAmbienteCptm = efluente.pkCdMeioAmbienteCptm,
                idDeptoCampoAmbiente = efluente.idDeptoCampoAmbiente,
                idStatusDesvio = efluente.idStatusDesvio,
                idStatusRegistro = efluente.idStatusRegistro,
                idMunicipio = efluente.idMunicipio,
                idLinha = efluente.idLinha,
                idVia = efluente.idVia,
                idTrecho = efluente.idTrecho,
                idTipoEfluente = efluente.idTipoEfluente,
                txNrElementoMonitoramento = efluente.txNrElementoMonitoramento,
                txNmElementoMonitoramento = efluente.txNmElementoMonitoramento,
                txKmPoste = efluente.txKmPoste,
                txEndereco = efluente.txEndereco,
                txCoordenadaX = efluente.txCoordenadaX,
                txCoordenadaY = efluente.txCoordenadaY,
                dtRegistro = efluente.dtRegistro,
                dtAtualizacao = efluente.dtAtualizacao,
                txNomeTecnicoResponsavel = efluente.txNomeTecnicoResponsavel,
                txEmailTecnicoResponsavel = efluente.txEmailTecnicoResponsavel,
                txTelefoneTecnicoResponsavel = efluente.txTelefoneTecnicoResponsavel,
                txEmpresaContratada = efluente.txEmpresaContratada,
                txNumeroContrato = efluente.txNumeroContrato,
                txProcessoAmbiental = efluente.txProcessoAmbiental,
                txOrigemEfluente = efluente.txOrigemEfluente,
                txDestinacaoEfluente = efluente.txDestinacaoEfluente,
                txVolumeEfluente = efluente.txVolumeEfluente,
                txUnidadeVolume = efluente.txUnidadeVolume,
                txCorEfluente = efluente.txCorEfluente,
                txOdorEfluente = efluente.txOdorEfluente,
                txPh = efluente.txPh,
                txTemperatura = efluente.txTemperatura,
                txObservacao = efluente.txObservacao,
                txLinkMapa = efluente.txLinkMapa,
                txNomeFoto01 = efluente.txNomeFoto01,
                txNomeFoto02 = efluente.txNomeFoto02,
                txNomeFoto03 = efluente.txNomeFoto03,
                txNomeFoto04 = efluente.txNomeFoto04
            };
        }
    }
}
