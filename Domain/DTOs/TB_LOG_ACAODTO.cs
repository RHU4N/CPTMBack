using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_LOG_ACAODTO
    {
        public int idLog { get; set; }

        public int idUsuario { get; set; }

        public string dsAcao { get; set; } = string.Empty;

        public string nmTabela { get; set; } = string.Empty;

        public string idRegistro { get; set; } = string.Empty;

        public DateTime dtAcao { get; set; }

        public string? dsIp { get; set; }
    }
}
