using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate
{
    [Table("PT_EFLUENTE")]
    public class PT_EFLUENTE
    {
        [Key]
        [Column("PK_CD_MEIO_AMBIENTE_CPTM")]
        public string pkCdMeioAmbienteCptm { get; private set; }

        [Column("ID_DEPTO_MEIO_AMBIENTE")]
        public int idDeptoCampoAmbiente { get; private set; }

        [Column("ID_STATUS_DESVIO")]
        public int idStatusDesvio { get; private set; }

        [Column("ID_STATUS_REGISTRO")]
        public int idStatusRegistro { get; private set; }

        [Column("ID_MUNICIPIO")]
        public int idMunicipio { get; private set; }

        [Column("ID_LINHA")]
        public int idLinha { get; private set; }

        [Column("ID_VIA")]
        public int idVia { get; private set; }

        [Column("ID_TRECHO")]
        public int idTrecho { get; private set; }

        [Column("ID_TIPO_EFLUENTE")]
        public int idTipoEfluente { get; private set; }

        [Column("TX_NR_ELEMENTO_MONITORAMENTO")]
        public string? txNrElementoMonitoramento { get; private set; }

        [Column("TX_NM_ELEMENTO_MONITORAMENTO")]
        public string? txNmElementoMonitoramento { get; private set; }

        [Column("TX_KM_POSTE")]
        public string? txKmPoste { get; private set; }

        [Column("TX_ENDERECO")]
        public string? txEndereco { get; private set; }

        [Column("TX_COORDENADA_X")]
        public decimal? txCoordenadaX { get; private set; }

        [Column("TX_COORDENADA_Y")]
        public decimal? txCoordenadaY { get; private set; }

        [Column("DT_REGISTRO")]
        public DateTime? dtRegistro { get; private set; }

        [Column("DT_ATUALIZACAO")]
        public DateTime? dtAtualizacao { get; private set; }

        [Column("TX_NOME_TECNICO_RESPONSAVEL")]
        public string? txNomeTecnicoResponsavel { get; private set; }

        [Column("TX_EMAIL_TECNICO_RESPONSAVEL")]
        public string? txEmailTecnicoResponsavel { get; private set; }

        [Column("TX_TELEFONE_TECNICO_RESPONSAVEL")]
        public string? txTelefoneTecnicoResponsavel { get; private set; }

        [Column("TX_EMPRESA_CONTRATADA")]
        public string? txEmpresaContratada { get; private set; }

        [Column("TX_NUMERO_CONTRATO")]
        public string? txNumeroContrato { get; private set; }

        [Column("TX_PROCESSO_AMBIENTAL")]
        public string? txProcessoAmbiental { get; private set; }

        [Column("TX_ORIGEM_EFLUENTE")]
        public string? txOrigemEfluente { get; private set; }

        [Column("TX_DESTINACAO_EFLUENTE")]
        public string? txDestinacaoEfluente { get; private set; }

        [Column("TX_VOLUME_EFLUENTE")]
        public decimal? txVolumeEfluente { get; private set; }

        [Column("TX_UNIDADE_VOLUME")]
        public string? txUnidadeVolume { get; private set; }

        [Column("TX_COR_EFLUENTE")]
        public string? txCorEfluente { get; private set; }

        [Column("TX_ODOR_EFLUENTE")]
        public string? txOdorEfluente { get; private set; }

        [Column("TX_PH")]
        public decimal? txPh { get; private set; }

        [Column("TX_TEMPERATURA")]
        public decimal? txTemperatura { get; private set; }

        [Column("TX_OBSERVACAO")]
        public string? txObservacao { get; private set; }

        [Column("TX_LINK_MAPA")]
        public string? txLinkMapa { get; private set; }

        [Column("TX_NOME_FOTO_01")]
        public string? txNomeFoto01 { get; private set; }

        [Column("TX_NOME_FOTO_02")]
        public string? txNomeFoto02 { get; private set; }

        [Column("TX_NOME_FOTO_03")]
        public string? txNomeFoto03 { get; private set; }

        [Column("TX_NOME_FOTO_04")]
        public string? txNomeFoto04 { get; private set; }

        public PT_EFLUENTE()
        {
            pkCdMeioAmbienteCptm = string.Empty;
        }

        public PT_EFLUENTE(
            string pkCdMeioAmbienteCptm,
            int idDeptoCampoAmbiente,
            int idStatusDesvio,
            int idStatusRegistro,
            int idMunicipio,
            int idLinha,
            int idVia,
            int idTrecho,
            int idTipoEfluente,
            string? txNrElementoMonitoramento = null,
            string? txNmElementoMonitoramento = null,
            string? txKmPoste = null,
            string? txEndereco = null,
            decimal? txCoordenadaX = null,
            decimal? txCoordenadaY = null,
            DateTime? dtRegistro = null,
            DateTime? dtAtualizacao = null,
            string? txNomeTecnicoResponsavel = null,
            string? txEmailTecnicoResponsavel = null,
            string? txTelefoneTecnicoResponsavel = null,
            string? txEmpresaContratada = null,
            string? txNumeroContrato = null,
            string? txProcessoAmbiental = null,
            string? txOrigemEfluente = null,
            string? txDestinacaoEfluente = null,
            decimal? txVolumeEfluente = null,
            string? txUnidadeVolume = null,
            string? txCorEfluente = null,
            string? txOdorEfluente = null,
            decimal? txPh = null,
            decimal? txTemperatura = null,
            string? txObservacao = null,
            string? txLinkMapa = null,
            string? txNomeFoto01 = null,
            string? txNomeFoto02 = null,
            string? txNomeFoto03 = null,
            string? txNomeFoto04 = null)
        {
            this.pkCdMeioAmbienteCptm = pkCdMeioAmbienteCptm;
            this.idDeptoCampoAmbiente = idDeptoCampoAmbiente;
            this.idStatusDesvio = idStatusDesvio;
            this.idStatusRegistro = idStatusRegistro;
            this.idMunicipio = idMunicipio;
            this.idLinha = idLinha;
            this.idVia = idVia;
            this.idTrecho = idTrecho;
            this.idTipoEfluente = idTipoEfluente;
            this.txNrElementoMonitoramento = txNrElementoMonitoramento;
            this.txNmElementoMonitoramento = txNmElementoMonitoramento;
            this.txKmPoste = txKmPoste;
            this.txEndereco = txEndereco;
            this.txCoordenadaX = txCoordenadaX;
            this.txCoordenadaY = txCoordenadaY;
            this.dtRegistro = dtRegistro;
            this.dtAtualizacao = dtAtualizacao;
            this.txNomeTecnicoResponsavel = txNomeTecnicoResponsavel;
            this.txEmailTecnicoResponsavel = txEmailTecnicoResponsavel;
            this.txTelefoneTecnicoResponsavel = txTelefoneTecnicoResponsavel;
            this.txEmpresaContratada = txEmpresaContratada;
            this.txNumeroContrato = txNumeroContrato;
            this.txProcessoAmbiental = txProcessoAmbiental;
            this.txOrigemEfluente = txOrigemEfluente;
            this.txDestinacaoEfluente = txDestinacaoEfluente;
            this.txVolumeEfluente = txVolumeEfluente;
            this.txUnidadeVolume = txUnidadeVolume;
            this.txCorEfluente = txCorEfluente;
            this.txOdorEfluente = txOdorEfluente;
            this.txPh = txPh;
            this.txTemperatura = txTemperatura;
            this.txObservacao = txObservacao;
            this.txLinkMapa = txLinkMapa;
            this.txNomeFoto01 = txNomeFoto01;
            this.txNomeFoto02 = txNomeFoto02;
            this.txNomeFoto03 = txNomeFoto03;
            this.txNomeFoto04 = txNomeFoto04;
        }
    }
}
