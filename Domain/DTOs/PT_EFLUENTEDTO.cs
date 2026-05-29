using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class PT_EFLUENTEDTO
    {
        public string pkCdMeioAmbienteCptm { get; set; } = string.Empty;

        public int idDeptoCampoAmbiente { get; set; }

        public int idStatusDesvio { get; set; }

        public int idStatusRegistro { get; set; }

        public int idMunicipio { get; set; }

        public int idLinha { get; set; }

        public int idVia { get; set; }

        public int idTrecho { get; set; }

        public int idTipoEfluente { get; set; }

        public string? txNrElementoMonitoramento { get; set; }

        public string? txNmElementoMonitoramento { get; set; }

        public string? txKmPoste { get; set; }

        public string? txEndereco { get; set; }

        public decimal? txCoordenadaX { get; set; }

        public decimal? txCoordenadaY { get; set; }

        public DateTime? dtRegistro { get; set; }

        public DateTime? dtAtualizacao { get; set; }

        public string? txNomeTecnicoResponsavel { get; set; }

        public string? txEmailTecnicoResponsavel { get; set; }

        public string? txTelefoneTecnicoResponsavel { get; set; }

        public string? txEmpresaContratada { get; set; }

        public string? txNumeroContrato { get; set; }

        public string? txProcessoAmbiental { get; set; }

        public string? txOrigemEfluente { get; set; }

        public string? txDestinacaoEfluente { get; set; }

        public decimal? txVolumeEfluente { get; set; }

        public string? txUnidadeVolume { get; set; }

        public string? txCorEfluente { get; set; }

        public string? txOdorEfluente { get; set; }

        public decimal? txPh { get; set; }

        public decimal? txTemperatura { get; set; }

        public string? txObservacao { get; set; }

        public string? txLinkMapa { get; set; }

        public string? txNomeFoto01 { get; set; }

        public string? txNomeFoto02 { get; set; }

        public string? txNomeFoto03 { get; set; }

        public string? txNomeFoto04 { get; set; }
    }
}
