using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate
{
    [Table("PT_EFLUENTE")]
    public class PT_EFLUENTE
    {
        // === 1. Chave Primária ===
        [Key]
        [Column("PK_CD_MEIO_AMBIENTE_CPTM")]
        [MaxLength(255)]
        public string pkCdMeioAmbienteCptm { get; private set; }

        // === 2-3. Elemento de Monitoramento ===
        [Column("TX_NR_ELEMENTO_MONITORAMENTO")]
        [MaxLength(255)]
        public string? txNrElementoMonitoramento { get; private set; }

        [Column("TX_NM_ELEMENTO_MONITORAMENTO")]
        [MaxLength(255)]
        public string? txNmElementoMonitoramento { get; private set; }

        // === 4-6. Domínios institucionais (texto direto, conforme Excel BD_01) ===
        [Column("TX_SIGLA_DEPTO_MEIO_AMBIENTE")]
        [MaxLength(255)]
        public string? txSiglaDeptomMeioAmbiente { get; private set; }

        [Column("TX_STATUS_DO_DESVIO_AMBIENTAL")]
        [MaxLength(255)]
        public string? txStatusDoDesvioAmbiental { get; private set; }

        [Column("TX_STATUS_DO_REGISTRO_NO_BD")]
        [MaxLength(255)]
        public string? txStatusDoRegistroNoBd { get; private set; }

        // === 7-12. Localização CPTM (domínios texto) ===
        [Column("TX_MUNICIPIO")]
        [MaxLength(255)]
        public string? txMunicipio { get; private set; }

        [Column("TX_LINHA_CPTM")]
        [MaxLength(255)]
        public string? txLinhaCptm { get; private set; }

        [Column("TX_VIA_CPTM")]
        [MaxLength(255)]
        public string? txViaCptm { get; private set; }

        [Column("TX_TRECHO_E_SENTIDO_CPTM")]
        [MaxLength(255)]
        public string? txTrechoESentidoCptm { get; private set; }

        [Column("TX_KM_POSTE")]
        [MaxLength(255)]
        public string? txKmPoste { get; private set; }

        [Column("TX_ESTACAO_CPTM")]
        [MaxLength(255)]
        public string? txEstacaoCptm { get; private set; }

        // === 13-16. Coordenadas geográficas ===
        [Column("NR_LAT_GRAU_DECIMAL_WGS84")]
        public decimal? nrLatGrauDecimalWgs84 { get; private set; }

        [Column("NR_LONG_GRAU_DECIMAL_WGS84")]
        public decimal? nrLongGrauDecimalWgs84 { get; private set; }

        [Column("NR_LAT_METROS_SIRGAS2000")]
        public decimal? nrLatMetrosSirgas2000 { get; private set; }

        [Column("NR_LONG_METROS_SIRGAS2000")]
        public decimal? nrLongMetrosSirgas2000 { get; private set; }

        // === 17. Local do escopo contratual ===
        [Column("TX_NM_LOCAL_ESCOPO_CONTRATUAL")]
        [MaxLength(255)]
        public string? txNmLocalEscopoContratual { get; private set; }

        // === 18-21. Identificação do formulário ===
        [Column("TX_TIPO_DE_FORMULARIO")]
        [MaxLength(255)]
        public string? txTipoDeFormulario { get; private set; }

        [Column("DT_DATA_EMISSAO_FORMULARIO")]
        public DateTime? dtDataEmissaoFormulario { get; private set; }

        [Column("NR_NUMERO_DE_FORMULARIO")]
        public int? nrNumeroDeFormulario { get; private set; }

        [Column("TX_AUTOR_PF_DO_FORMULARIO")]
        [MaxLength(255)]
        public string? txAutorPfDoFormulario { get; private set; }

        // === 22-23. Natureza e empresa executora ===
        [Column("TX_NATUREZA_DO_PGA")]
        [MaxLength(255)]
        public string? txNaturezaDoPga { get; private set; }

        [Column("TX_NOME_PJ_EXECUTORA")]
        [MaxLength(255)]
        public string? txNomePjExecutora { get; private set; }

        // === 24-30. Regulamentação ambiental (DRA) ===
        [Column("TX_TIPO_ATIVIDADE_LISTADA")]
        [MaxLength(255)]
        public string? txTipoAtividadeListada { get; private set; }

        [Column("TX_TIPO_ATIVIDADE_N_LISTADA")]
        [MaxLength(255)]
        public string? txTipoAtividadeNListada { get; private set; }

        [Column("TX_TIPO_DRA_LISTADO")]
        [MaxLength(255)]
        public string? txTipoDraListado { get; private set; }

        [Column("TX_TIPO_DRA_N_LISTADO")]
        [MaxLength(255)]
        public string? txTipoDraNListado { get; private set; }

        [Column("TX_ID_DRA")]
        [MaxLength(255)]
        public string? txIdDra { get; private set; }

        [Column("DT_VALIDADE_DRA")]
        public DateTime? dtValidadeDra { get; private set; }

        [Column("TX_ANALISE_CPTM_APROVACAO")]
        [MaxLength(255)]
        public string? txAnaliseCptmAprovacao { get; private set; }

        // === 31-35. Detalhamento ===
        [Column("TX_TIPO_ATIVIDADE_CPTM")]
        [MaxLength(255)]
        public string? txTipoAtividadeCptm { get; private set; }

        [Column("TX_NM_LOCAL_ATIV")]
        [MaxLength(255)]
        public string? txNmLocalAtiv { get; private set; }

        [Column("TX_NM_LOCAL_ATIV_COMPLEMENTO")]
        [MaxLength(255)]
        public string? txNmLocalAtivComplemento { get; private set; }

        [Column("TX_ORIGEM_EFLUENTE")]
        [MaxLength(255)]
        public string? txOrigemEfluente { get; private set; }

        [Column("TX_FONTE_GERADORA")]
        [MaxLength(255)]
        public string? txFonteGeradora { get; private set; }

        // === 36-40. Volume, destinação e transporte ===
        [Column("NR_QUANTIDADE_L")]
        public decimal? nrQuantidadeL { get; private set; }

        [Column("TX_TIPO_DESTINACAO")]
        [MaxLength(255)]
        public string? txTipoDestinacao { get; private set; }

        [Column("TX_TIPO_VEICULO")]
        [MaxLength(255)]
        public string? txTipoVeiculo { get; private set; }

        [Column("TX_ID_VEICULO")]
        [MaxLength(255)]
        public string? txIdVeiculo { get; private set; }

        [Column("TX_ID_GUIA_REMESSA")]
        [MaxLength(255)]
        public string? txIdGuiaRemessa { get; private set; }

        // === 41-43. Risco e domínio territorial ===
        [Column("NR_DISTANCIA_DA_VIA_M")]
        public decimal? nrDistanciaDaViaM { get; private set; }

        [Column("TX_OFERECE_RISCO_SISTEMA_CPTM")]
        [MaxLength(255)]
        public string? txOfereceRiscoSistemaCptm { get; private set; }

        [Column("TX_PROPRIETARIO")]
        [MaxLength(255)]
        public string? txProprietario { get; private set; }

        // === 44-46. Observações e data/hora do cadastro ===
        [Column("TX_OBS_CADASTRAMENTO")]
        [MaxLength(2000)]
        public string? txObsCadastramento { get; private set; }

        [Column("DT_DATA_DO_CADASTRAMENTO")]
        public DateTime? dtDataDoCadastramento { get; private set; }

        [Column("HR_HORA_DO_CADASTRAMENTO")]
        [MaxLength(5)]
        public string? hrHorasDoCadastramento { get; private set; }

        // === 47-51. Autores e responsável técnico do cadastro ===
        [Column("TX_AUTOR_PJ_DO_CADASTRO")]
        [MaxLength(255)]
        public string? txAutorPjDoCadastro { get; private set; }

        [Column("TX_AUTOR_PF_DO_CADASTRO")]
        [MaxLength(255)]
        public string? txAutorPfDoCadastro { get; private set; }

        [Column("TX_NM_RESPONSAVEL_CADASTRO")]
        [MaxLength(255)]
        public string? txNmResponsavelCadastro { get; private set; }

        [Column("TX_RP_RESPONSAVEL_CADASTRO")]
        [MaxLength(255)]
        public string? txRpResponsavelCadastro { get; private set; }

        [Column("TX_DRT_RESPONSAVEL_CADASTRO")]
        [MaxLength(255)]
        public string? txDrtResponsavelCadastro { get; private set; }

        // === 52-60. Dados da contratada, área gestora e supervisora ===
        [Column("TX_NOME_PJ_DA_CONTRATADA")]
        [MaxLength(255)]
        public string? txNomePjDaContratada { get; private set; }

        [Column("TX_NR_CONTRATO_CONTRATADA")]
        [MaxLength(255)]
        public string? txNrContratoContratada { get; private set; }

        [Column("TX_NM_AREA_GESTORA_CPTM")]
        [MaxLength(255)]
        public string? txNmAreaGestoraCptm { get; private set; }

        [Column("TX_ID_AREA_GESTORA_CPTM")]
        [MaxLength(255)]
        public string? txIdAreaGestoraCptm { get; private set; }

        [Column("TX_SIGLA_AREA_GESTORA_CPTM")]
        [MaxLength(255)]
        public string? txSiglaAreaGestoraCptm { get; private set; }

        [Column("TX_NOME_PF_DA_REPRESENTANTE")]
        [MaxLength(255)]
        public string? txNomePfDaRepresentante { get; private set; }

        [Column("TX_NOME_PJ_DA_SUPERVISORA")]
        [MaxLength(255)]
        public string? txNomePjDaSupervisora { get; private set; }

        [Column("TX_NR_CONTRATO_SUPERVISORA")]
        [MaxLength(255)]
        public string? txNrContratoSupervisora { get; private set; }

        // === 60-69. Arquivos relacionados ===
        [Column("TX_NM_ARQUIVO_FDC_RELACIONADO")]
        [MaxLength(255)]
        public string? txNmArquivoFdcRelacionado { get; private set; }

        [Column("PK_CD_ARQUIVO_FDC_RELACIONADO")]
        [MaxLength(255)]
        public string? pkCdArquivoFdcRelacionado { get; private set; }

        [Column("TX_NM_ARQUIVO_RVT_RELACIONADO")]
        [MaxLength(255)]
        public string? txNmArquivoRvtRelacionado { get; private set; }

        [Column("PK_CD_ELEMENTO_DE_MONITOR_RVT")]
        [MaxLength(255)]
        public string? pkCdElementoDeMonitorRvt { get; private set; }

        [Column("TX_NM_ARQUIVO_DAC_RELACIONADO")]
        [MaxLength(255)]
        public string? txNmArquivoDacRelacionado { get; private set; }

        [Column("PK_CD_ELEMENTO_DE_MONITOR_DAC")]
        [MaxLength(255)]
        public string? pkCdElementoDeMonitorDac { get; private set; }

        [Column("TX_NM_ARQUIVO_CNC_RELACIONADO")]
        [MaxLength(255)]
        public string? txNmArquivoCncRelacionado { get; private set; }

        [Column("PK_CD_ELEMENTO_DE_MONITOR_CNC")]
        [MaxLength(255)]
        public string? pkCdElementoDeMonitorCnc { get; private set; }

        [Column("PK_CD_CODIGO_NO_ULTIMO_RRA")]
        [MaxLength(255)]
        public string? pkCdCodigoNoUltimoRra { get; private set; }

        [Column("PK_CD_CEDOC")]
        [MaxLength(255)]
        public string? pkCdCedoc { get; private set; }

        // === 70-73. Nomes das fotos ===
        [Column("TX_NOME_FOTO_01")]
        [MaxLength(255)]
        public string? txNomeFoto01 { get; private set; }

        [Column("TX_NOME_FOTO_02")]
        [MaxLength(255)]
        public string? txNomeFoto02 { get; private set; }

        [Column("TX_NOME_FOTO_03")]
        [MaxLength(255)]
        public string? txNomeFoto03 { get; private set; }

        [Column("TX_NOME_FOTO_04")]
        [MaxLength(255)]
        public string? txNomeFoto04 { get; private set; }

        public PT_EFLUENTE()
        {
            pkCdMeioAmbienteCptm = string.Empty;
        }

        public PT_EFLUENTE(
            string pkCdMeioAmbienteCptm,
            string? txNrElementoMonitoramento = null,
            string? txNmElementoMonitoramento = null,
            string? txSiglaDeptomMeioAmbiente = null,
            string? txStatusDoDesvioAmbiental = null,
            string? txStatusDoRegistroNoBd = null,
            string? txMunicipio = null,
            string? txLinhaCptm = null,
            string? txViaCptm = null,
            string? txTrechoESentidoCptm = null,
            string? txKmPoste = null,
            string? txEstacaoCptm = null,
            decimal? nrLatGrauDecimalWgs84 = null,
            decimal? nrLongGrauDecimalWgs84 = null,
            decimal? nrLatMetrosSirgas2000 = null,
            decimal? nrLongMetrosSirgas2000 = null,
            string? txNmLocalEscopoContratual = null,
            string? txTipoDeFormulario = null,
            DateTime? dtDataEmissaoFormulario = null,
            int? nrNumeroDeFormulario = null,
            string? txAutorPfDoFormulario = null,
            string? txNaturezaDoPga = null,
            string? txNomePjExecutora = null,
            string? txTipoAtividadeListada = null,
            string? txTipoAtividadeNListada = null,
            string? txTipoDraListado = null,
            string? txTipoDraNListado = null,
            string? txIdDra = null,
            DateTime? dtValidadeDra = null,
            string? txAnaliseCptmAprovacao = null,
            string? txTipoAtividadeCptm = null,
            string? txNmLocalAtiv = null,
            string? txNmLocalAtivComplemento = null,
            string? txOrigemEfluente = null,
            string? txFonteGeradora = null,
            decimal? nrQuantidadeL = null,
            string? txTipoDestinacao = null,
            string? txTipoVeiculo = null,
            string? txIdVeiculo = null,
            string? txIdGuiaRemessa = null,
            decimal? nrDistanciaDaViaM = null,
            string? txOfereceRiscoSistemaCptm = null,
            string? txProprietario = null,
            string? txObsCadastramento = null,
            DateTime? dtDataDoCadastramento = null,
            string? hrHorasDoCadastramento = null,
            string? txAutorPjDoCadastro = null,
            string? txAutorPfDoCadastro = null,
            string? txNmResponsavelCadastro = null,
            string? txRpResponsavelCadastro = null,
            string? txDrtResponsavelCadastro = null,
            string? txNomePjDaContratada = null,
            string? txNrContratoContratada = null,
            string? txNmAreaGestoraCptm = null,
            string? txIdAreaGestoraCptm = null,
            string? txSiglaAreaGestoraCptm = null,
            string? txNomePfDaRepresentante = null,
            string? txNomePjDaSupervisora = null,
            string? txNrContratoSupervisora = null,
            string? txNmArquivoFdcRelacionado = null,
            string? pkCdArquivoFdcRelacionado = null,
            string? txNmArquivoRvtRelacionado = null,
            string? pkCdElementoDeMonitorRvt = null,
            string? txNmArquivoDacRelacionado = null,
            string? pkCdElementoDeMonitorDac = null,
            string? txNmArquivoCncRelacionado = null,
            string? pkCdElementoDeMonitorCnc = null,
            string? pkCdCodigoNoUltimoRra = null,
            string? pkCdCedoc = null,
            string? txNomeFoto01 = null,
            string? txNomeFoto02 = null,
            string? txNomeFoto03 = null,
            string? txNomeFoto04 = null)
        {
            this.pkCdMeioAmbienteCptm = pkCdMeioAmbienteCptm;
            this.txNrElementoMonitoramento = txNrElementoMonitoramento;
            this.txNmElementoMonitoramento = txNmElementoMonitoramento;
            this.txSiglaDeptomMeioAmbiente = txSiglaDeptomMeioAmbiente;
            this.txStatusDoDesvioAmbiental = txStatusDoDesvioAmbiental;
            this.txStatusDoRegistroNoBd = txStatusDoRegistroNoBd;
            this.txMunicipio = txMunicipio;
            this.txLinhaCptm = txLinhaCptm;
            this.txViaCptm = txViaCptm;
            this.txTrechoESentidoCptm = txTrechoESentidoCptm;
            this.txKmPoste = txKmPoste;
            this.txEstacaoCptm = txEstacaoCptm;
            this.nrLatGrauDecimalWgs84 = nrLatGrauDecimalWgs84;
            this.nrLongGrauDecimalWgs84 = nrLongGrauDecimalWgs84;
            this.nrLatMetrosSirgas2000 = nrLatMetrosSirgas2000;
            this.nrLongMetrosSirgas2000 = nrLongMetrosSirgas2000;
            this.txNmLocalEscopoContratual = txNmLocalEscopoContratual;
            this.txTipoDeFormulario = txTipoDeFormulario;
            this.dtDataEmissaoFormulario = dtDataEmissaoFormulario;
            this.nrNumeroDeFormulario = nrNumeroDeFormulario;
            this.txAutorPfDoFormulario = txAutorPfDoFormulario;
            this.txNaturezaDoPga = txNaturezaDoPga;
            this.txNomePjExecutora = txNomePjExecutora;
            this.txTipoAtividadeListada = txTipoAtividadeListada;
            this.txTipoAtividadeNListada = txTipoAtividadeNListada;
            this.txTipoDraListado = txTipoDraListado;
            this.txTipoDraNListado = txTipoDraNListado;
            this.txIdDra = txIdDra;
            this.dtValidadeDra = dtValidadeDra;
            this.txAnaliseCptmAprovacao = txAnaliseCptmAprovacao;
            this.txTipoAtividadeCptm = txTipoAtividadeCptm;
            this.txNmLocalAtiv = txNmLocalAtiv;
            this.txNmLocalAtivComplemento = txNmLocalAtivComplemento;
            this.txOrigemEfluente = txOrigemEfluente;
            this.txFonteGeradora = txFonteGeradora;
            this.nrQuantidadeL = nrQuantidadeL;
            this.txTipoDestinacao = txTipoDestinacao;
            this.txTipoVeiculo = txTipoVeiculo;
            this.txIdVeiculo = txIdVeiculo;
            this.txIdGuiaRemessa = txIdGuiaRemessa;
            this.nrDistanciaDaViaM = nrDistanciaDaViaM;
            this.txOfereceRiscoSistemaCptm = txOfereceRiscoSistemaCptm;
            this.txProprietario = txProprietario;
            this.txObsCadastramento = txObsCadastramento;
            this.dtDataDoCadastramento = dtDataDoCadastramento;
            this.hrHorasDoCadastramento = hrHorasDoCadastramento;
            this.txAutorPjDoCadastro = txAutorPjDoCadastro;
            this.txAutorPfDoCadastro = txAutorPfDoCadastro;
            this.txNmResponsavelCadastro = txNmResponsavelCadastro;
            this.txRpResponsavelCadastro = txRpResponsavelCadastro;
            this.txDrtResponsavelCadastro = txDrtResponsavelCadastro;
            this.txNomePjDaContratada = txNomePjDaContratada;
            this.txNrContratoContratada = txNrContratoContratada;
            this.txNmAreaGestoraCptm = txNmAreaGestoraCptm;
            this.txIdAreaGestoraCptm = txIdAreaGestoraCptm;
            this.txSiglaAreaGestoraCptm = txSiglaAreaGestoraCptm;
            this.txNomePfDaRepresentante = txNomePfDaRepresentante;
            this.txNomePjDaSupervisora = txNomePjDaSupervisora;
            this.txNrContratoSupervisora = txNrContratoSupervisora;
            this.txNmArquivoFdcRelacionado = txNmArquivoFdcRelacionado;
            this.pkCdArquivoFdcRelacionado = pkCdArquivoFdcRelacionado;
            this.txNmArquivoRvtRelacionado = txNmArquivoRvtRelacionado;
            this.pkCdElementoDeMonitorRvt = pkCdElementoDeMonitorRvt;
            this.txNmArquivoDacRelacionado = txNmArquivoDacRelacionado;
            this.pkCdElementoDeMonitorDac = pkCdElementoDeMonitorDac;
            this.txNmArquivoCncRelacionado = txNmArquivoCncRelacionado;
            this.pkCdElementoDeMonitorCnc = pkCdElementoDeMonitorCnc;
            this.pkCdCodigoNoUltimoRra = pkCdCodigoNoUltimoRra;
            this.pkCdCedoc = pkCdCedoc;
            this.txNomeFoto01 = txNomeFoto01;
            this.txNomeFoto02 = txNomeFoto02;
            this.txNomeFoto03 = txNomeFoto03;
            this.txNomeFoto04 = txNomeFoto04;
        }
    }
}
