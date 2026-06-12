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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var efluentes = _efluenteRepository.GetAll();

                if (!User.IsInRole("admin"))
                {
                    var dsLogin = User.FindFirst("dsLogin")?.Value ?? string.Empty;
                    efluentes = efluentes.Where(e => e.txAutorPfDoCadastro == dsLogin);
                }

                var dtos = efluentes.Select(MapToDTO).ToList();
                return Ok(new { dados = dtos, total = dtos.Count });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao recuperar efluentes: {Message}", ex.Message);
                return BadRequest(new { mensagem = "Erro ao recuperar efluentes", erro = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var efluente = _efluenteRepository.Get(id);
                if (efluente == null)
                    return NotFound(new { mensagem = "Efluente não encontrado" });

                return Ok(MapToDTO(efluente));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao recuperar efluente {Id}: {Message}", id, ex.Message);
                return BadRequest(new { mensagem = "Erro ao recuperar efluente", erro = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PT_EFLUENTEViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.pkCdMeioAmbienteCptm))
                    return BadRequest(new { mensagem = "Chave primária é obrigatória" });

                var existing = _efluenteRepository.Get(model.pkCdMeioAmbienteCptm);
                if (existing != null)
                    return Conflict(new { mensagem = "Registro já existe com esta chave primária" });

                var efluente = MapFromViewModel(model);
                _efluenteRepository.Add(efluente);

                _logger.LogInformation("Efluente criado: {Id}", model.pkCdMeioAmbienteCptm);
                return CreatedAtAction(nameof(GetById), new { id = model.pkCdMeioAmbienteCptm }, MapToDTO(efluente));
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao criar efluente: {Message}", ex.Message);
                return BadRequest(new { mensagem = "Erro ao criar efluente", erro = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] PT_EFLUENTEViewModel model)
        {
            try
            {
                var existing = _efluenteRepository.Get(id);
                if (existing == null)
                    return NotFound(new { mensagem = "Efluente não encontrado" });

                var efluente = new PT_EFLUENTE(
                    pkCdMeioAmbienteCptm: id,
                    txNrElementoMonitoramento: model.txNrElementoMonitoramento,
                    txNmElementoMonitoramento: model.txNmElementoMonitoramento,
                    txSiglaDeptomMeioAmbiente: model.txSiglaDeptomMeioAmbiente,
                    txStatusDoDesvioAmbiental: model.txStatusDoDesvioAmbiental,
                    txStatusDoRegistroNoBd: model.txStatusDoRegistroNoBd,
                    txMunicipio: model.txMunicipio,
                    txLinhaCptm: model.txLinhaCptm,
                    txViaCptm: model.txViaCptm,
                    txTrechoESentidoCptm: model.txTrechoESentidoCptm,
                    txKmPoste: model.txKmPoste,
                    txEstacaoCptm: model.txEstacaoCptm,
                    nrLatGrauDecimalWgs84: model.nrLatGrauDecimalWgs84,
                    nrLongGrauDecimalWgs84: model.nrLongGrauDecimalWgs84,
                    nrLatMetrosSirgas2000: model.nrLatMetrosSirgas2000,
                    nrLongMetrosSirgas2000: model.nrLongMetrosSirgas2000,
                    txNmLocalEscopoContratual: model.txNmLocalEscopoContratual,
                    txTipoDeFormulario: model.txTipoDeFormulario,
                    dtDataEmissaoFormulario: model.dtDataEmissaoFormulario,
                    nrNumeroDeFormulario: model.nrNumeroDeFormulario,
                    txAutorPfDoFormulario: model.txAutorPfDoFormulario,
                    txNaturezaDoPga: model.txNaturezaDoPga,
                    txNomePjExecutora: model.txNomePjExecutora,
                    txTipoAtividadeListada: model.txTipoAtividadeListada,
                    txTipoAtividadeNListada: model.txTipoAtividadeNListada,
                    txTipoDraListado: model.txTipoDraListado,
                    txTipoDraNListado: model.txTipoDraNListado,
                    txIdDra: model.txIdDra,
                    dtValidadeDra: model.dtValidadeDra,
                    txAnaliseCptmAprovacao: model.txAnaliseCptmAprovacao,
                    txTipoAtividadeCptm: model.txTipoAtividadeCptm,
                    txNmLocalAtiv: model.txNmLocalAtiv,
                    txNmLocalAtivComplemento: model.txNmLocalAtivComplemento,
                    txOrigemEfluente: model.txOrigemEfluente,
                    txFonteGeradora: model.txFonteGeradora,
                    nrQuantidadeL: model.nrQuantidadeL,
                    txTipoDestinacao: model.txTipoDestinacao,
                    txTipoVeiculo: model.txTipoVeiculo,
                    txIdVeiculo: model.txIdVeiculo,
                    txIdGuiaRemessa: model.txIdGuiaRemessa,
                    nrDistanciaDaViaM: model.nrDistanciaDaViaM,
                    txOfereceRiscoSistemaCptm: model.txOfereceRiscoSistemaCptm,
                    txProprietario: model.txProprietario,
                    txObsCadastramento: model.txObsCadastramento,
                    dtDataDoCadastramento: model.dtDataDoCadastramento,
                    hrHorasDoCadastramento: model.hrHorasDoCadastramento,
                    txAutorPjDoCadastro: model.txAutorPjDoCadastro,
                    txAutorPfDoCadastro: model.txAutorPfDoCadastro,
                    txNmResponsavelCadastro: model.txNmResponsavelCadastro,
                    txRpResponsavelCadastro: model.txRpResponsavelCadastro,
                    txDrtResponsavelCadastro: model.txDrtResponsavelCadastro,
                    txNomePjDaContratada: model.txNomePjDaContratada,
                    txNrContratoContratada: model.txNrContratoContratada,
                    txNmAreaGestoraCptm: model.txNmAreaGestoraCptm,
                    txIdAreaGestoraCptm: model.txIdAreaGestoraCptm,
                    txSiglaAreaGestoraCptm: model.txSiglaAreaGestoraCptm,
                    txNomePfDaRepresentante: model.txNomePfDaRepresentante,
                    txNomePjDaSupervisora: model.txNomePjDaSupervisora,
                    txNrContratoSupervisora: model.txNrContratoSupervisora,
                    txNmArquivoFdcRelacionado: model.txNmArquivoFdcRelacionado,
                    pkCdArquivoFdcRelacionado: model.pkCdArquivoFdcRelacionado,
                    txNmArquivoRvtRelacionado: model.txNmArquivoRvtRelacionado,
                    pkCdElementoDeMonitorRvt: model.pkCdElementoDeMonitorRvt,
                    txNmArquivoDacRelacionado: model.txNmArquivoDacRelacionado,
                    pkCdElementoDeMonitorDac: model.pkCdElementoDeMonitorDac,
                    txNmArquivoCncRelacionado: model.txNmArquivoCncRelacionado,
                    pkCdElementoDeMonitorCnc: model.pkCdElementoDeMonitorCnc,
                    pkCdCodigoNoUltimoRra: model.pkCdCodigoNoUltimoRra,
                    pkCdCedoc: model.pkCdCedoc,
                    txNomeFoto01: model.txNomeFoto01,
                    txNomeFoto02: model.txNomeFoto02,
                    txNomeFoto03: model.txNomeFoto03,
                    txNomeFoto04: model.txNomeFoto04
                );

                _efluenteRepository.Update(efluente);
                _logger.LogInformation("Efluente atualizado: {Id}", id);
                return Ok(new { mensagem = "Efluente atualizado com sucesso", dados = MapToDTO(efluente) });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao atualizar efluente {Id}: {Message}", id, ex.Message);
                return BadRequest(new { mensagem = "Erro ao atualizar efluente", erro = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            try
            {
                var efluente = _efluenteRepository.Get(id);
                if (efluente == null)
                    return NotFound(new { mensagem = "Efluente não encontrado" });

                _efluenteRepository.Delete(id);
                _logger.LogInformation("Efluente deletado: {Id}", id);
                return Ok(new { mensagem = "Efluente deletado com sucesso" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao deletar efluente {Id}: {Message}", id, ex.Message);
                return BadRequest(new { mensagem = "Erro ao deletar efluente", erro = ex.Message });
            }
        }

        private static PT_EFLUENTE MapFromViewModel(PT_EFLUENTEViewModel model) => new PT_EFLUENTE(
            pkCdMeioAmbienteCptm: model.pkCdMeioAmbienteCptm,
            txNrElementoMonitoramento: model.txNrElementoMonitoramento,
            txNmElementoMonitoramento: model.txNmElementoMonitoramento,
            txSiglaDeptomMeioAmbiente: model.txSiglaDeptomMeioAmbiente,
            txStatusDoDesvioAmbiental: model.txStatusDoDesvioAmbiental,
            txStatusDoRegistroNoBd: model.txStatusDoRegistroNoBd,
            txMunicipio: model.txMunicipio,
            txLinhaCptm: model.txLinhaCptm,
            txViaCptm: model.txViaCptm,
            txTrechoESentidoCptm: model.txTrechoESentidoCptm,
            txKmPoste: model.txKmPoste,
            txEstacaoCptm: model.txEstacaoCptm,
            nrLatGrauDecimalWgs84: model.nrLatGrauDecimalWgs84,
            nrLongGrauDecimalWgs84: model.nrLongGrauDecimalWgs84,
            nrLatMetrosSirgas2000: model.nrLatMetrosSirgas2000,
            nrLongMetrosSirgas2000: model.nrLongMetrosSirgas2000,
            txNmLocalEscopoContratual: model.txNmLocalEscopoContratual,
            txTipoDeFormulario: model.txTipoDeFormulario,
            dtDataEmissaoFormulario: model.dtDataEmissaoFormulario,
            nrNumeroDeFormulario: model.nrNumeroDeFormulario,
            txAutorPfDoFormulario: model.txAutorPfDoFormulario,
            txNaturezaDoPga: model.txNaturezaDoPga,
            txNomePjExecutora: model.txNomePjExecutora,
            txTipoAtividadeListada: model.txTipoAtividadeListada,
            txTipoAtividadeNListada: model.txTipoAtividadeNListada,
            txTipoDraListado: model.txTipoDraListado,
            txTipoDraNListado: model.txTipoDraNListado,
            txIdDra: model.txIdDra,
            dtValidadeDra: model.dtValidadeDra,
            txAnaliseCptmAprovacao: model.txAnaliseCptmAprovacao,
            txTipoAtividadeCptm: model.txTipoAtividadeCptm,
            txNmLocalAtiv: model.txNmLocalAtiv,
            txNmLocalAtivComplemento: model.txNmLocalAtivComplemento,
            txOrigemEfluente: model.txOrigemEfluente,
            txFonteGeradora: model.txFonteGeradora,
            nrQuantidadeL: model.nrQuantidadeL,
            txTipoDestinacao: model.txTipoDestinacao,
            txTipoVeiculo: model.txTipoVeiculo,
            txIdVeiculo: model.txIdVeiculo,
            txIdGuiaRemessa: model.txIdGuiaRemessa,
            nrDistanciaDaViaM: model.nrDistanciaDaViaM,
            txOfereceRiscoSistemaCptm: model.txOfereceRiscoSistemaCptm,
            txProprietario: model.txProprietario,
            txObsCadastramento: model.txObsCadastramento,
            dtDataDoCadastramento: model.dtDataDoCadastramento,
            hrHorasDoCadastramento: model.hrHorasDoCadastramento,
            txAutorPjDoCadastro: model.txAutorPjDoCadastro,
            txAutorPfDoCadastro: model.txAutorPfDoCadastro,
            txNmResponsavelCadastro: model.txNmResponsavelCadastro,
            txRpResponsavelCadastro: model.txRpResponsavelCadastro,
            txDrtResponsavelCadastro: model.txDrtResponsavelCadastro,
            txNomePjDaContratada: model.txNomePjDaContratada,
            txNrContratoContratada: model.txNrContratoContratada,
            txNmAreaGestoraCptm: model.txNmAreaGestoraCptm,
            txIdAreaGestoraCptm: model.txIdAreaGestoraCptm,
            txSiglaAreaGestoraCptm: model.txSiglaAreaGestoraCptm,
            txNomePfDaRepresentante: model.txNomePfDaRepresentante,
            txNomePjDaSupervisora: model.txNomePjDaSupervisora,
            txNrContratoSupervisora: model.txNrContratoSupervisora,
            txNmArquivoFdcRelacionado: model.txNmArquivoFdcRelacionado,
            pkCdArquivoFdcRelacionado: model.pkCdArquivoFdcRelacionado,
            txNmArquivoRvtRelacionado: model.txNmArquivoRvtRelacionado,
            pkCdElementoDeMonitorRvt: model.pkCdElementoDeMonitorRvt,
            txNmArquivoDacRelacionado: model.txNmArquivoDacRelacionado,
            pkCdElementoDeMonitorDac: model.pkCdElementoDeMonitorDac,
            txNmArquivoCncRelacionado: model.txNmArquivoCncRelacionado,
            pkCdElementoDeMonitorCnc: model.pkCdElementoDeMonitorCnc,
            pkCdCodigoNoUltimoRra: model.pkCdCodigoNoUltimoRra,
            pkCdCedoc: model.pkCdCedoc,
            txNomeFoto01: model.txNomeFoto01,
            txNomeFoto02: model.txNomeFoto02,
            txNomeFoto03: model.txNomeFoto03,
            txNomeFoto04: model.txNomeFoto04
        );

        private static PT_EFLUENTEDTO MapToDTO(PT_EFLUENTE e) => new PT_EFLUENTEDTO
        {
            pkCdMeioAmbienteCptm = e.pkCdMeioAmbienteCptm,
            txNrElementoMonitoramento = e.txNrElementoMonitoramento,
            txNmElementoMonitoramento = e.txNmElementoMonitoramento,
            txSiglaDeptomMeioAmbiente = e.txSiglaDeptomMeioAmbiente,
            txStatusDoDesvioAmbiental = e.txStatusDoDesvioAmbiental,
            txStatusDoRegistroNoBd = e.txStatusDoRegistroNoBd,
            txMunicipio = e.txMunicipio,
            txLinhaCptm = e.txLinhaCptm,
            txViaCptm = e.txViaCptm,
            txTrechoESentidoCptm = e.txTrechoESentidoCptm,
            txKmPoste = e.txKmPoste,
            txEstacaoCptm = e.txEstacaoCptm,
            nrLatGrauDecimalWgs84 = e.nrLatGrauDecimalWgs84,
            nrLongGrauDecimalWgs84 = e.nrLongGrauDecimalWgs84,
            nrLatMetrosSirgas2000 = e.nrLatMetrosSirgas2000,
            nrLongMetrosSirgas2000 = e.nrLongMetrosSirgas2000,
            txNmLocalEscopoContratual = e.txNmLocalEscopoContratual,
            txTipoDeFormulario = e.txTipoDeFormulario,
            dtDataEmissaoFormulario = e.dtDataEmissaoFormulario,
            nrNumeroDeFormulario = e.nrNumeroDeFormulario,
            txAutorPfDoFormulario = e.txAutorPfDoFormulario,
            txNaturezaDoPga = e.txNaturezaDoPga,
            txNomePjExecutora = e.txNomePjExecutora,
            txTipoAtividadeListada = e.txTipoAtividadeListada,
            txTipoAtividadeNListada = e.txTipoAtividadeNListada,
            txTipoDraListado = e.txTipoDraListado,
            txTipoDraNListado = e.txTipoDraNListado,
            txIdDra = e.txIdDra,
            dtValidadeDra = e.dtValidadeDra,
            txAnaliseCptmAprovacao = e.txAnaliseCptmAprovacao,
            txTipoAtividadeCptm = e.txTipoAtividadeCptm,
            txNmLocalAtiv = e.txNmLocalAtiv,
            txNmLocalAtivComplemento = e.txNmLocalAtivComplemento,
            txOrigemEfluente = e.txOrigemEfluente,
            txFonteGeradora = e.txFonteGeradora,
            nrQuantidadeL = e.nrQuantidadeL,
            txTipoDestinacao = e.txTipoDestinacao,
            txTipoVeiculo = e.txTipoVeiculo,
            txIdVeiculo = e.txIdVeiculo,
            txIdGuiaRemessa = e.txIdGuiaRemessa,
            nrDistanciaDaViaM = e.nrDistanciaDaViaM,
            txOfereceRiscoSistemaCptm = e.txOfereceRiscoSistemaCptm,
            txProprietario = e.txProprietario,
            txObsCadastramento = e.txObsCadastramento,
            dtDataDoCadastramento = e.dtDataDoCadastramento,
            hrHorasDoCadastramento = e.hrHorasDoCadastramento,
            txAutorPjDoCadastro = e.txAutorPjDoCadastro,
            txAutorPfDoCadastro = e.txAutorPfDoCadastro,
            txNmResponsavelCadastro = e.txNmResponsavelCadastro,
            txRpResponsavelCadastro = e.txRpResponsavelCadastro,
            txDrtResponsavelCadastro = e.txDrtResponsavelCadastro,
            txNomePjDaContratada = e.txNomePjDaContratada,
            txNrContratoContratada = e.txNrContratoContratada,
            txNmAreaGestoraCptm = e.txNmAreaGestoraCptm,
            txIdAreaGestoraCptm = e.txIdAreaGestoraCptm,
            txSiglaAreaGestoraCptm = e.txSiglaAreaGestoraCptm,
            txNomePfDaRepresentante = e.txNomePfDaRepresentante,
            txNomePjDaSupervisora = e.txNomePjDaSupervisora,
            txNrContratoSupervisora = e.txNrContratoSupervisora,
            txNmArquivoFdcRelacionado = e.txNmArquivoFdcRelacionado,
            pkCdArquivoFdcRelacionado = e.pkCdArquivoFdcRelacionado,
            txNmArquivoRvtRelacionado = e.txNmArquivoRvtRelacionado,
            pkCdElementoDeMonitorRvt = e.pkCdElementoDeMonitorRvt,
            txNmArquivoDacRelacionado = e.txNmArquivoDacRelacionado,
            pkCdElementoDeMonitorDac = e.pkCdElementoDeMonitorDac,
            txNmArquivoCncRelacionado = e.txNmArquivoCncRelacionado,
            pkCdElementoDeMonitorCnc = e.pkCdElementoDeMonitorCnc,
            pkCdCodigoNoUltimoRra = e.pkCdCodigoNoUltimoRra,
            pkCdCedoc = e.pkCdCedoc,
            txNomeFoto01 = e.txNomeFoto01,
            txNomeFoto02 = e.txNomeFoto02,
            txNomeFoto03 = e.txNomeFoto03,
            txNomeFoto04 = e.txNomeFoto04,
        };
    }
}
