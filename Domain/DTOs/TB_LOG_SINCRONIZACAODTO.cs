using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_LOG_SINCRONIZACAODTO
    {
        public int idLog { get; set; }

        public int idUsuario { get; set; }

        public DateTime dtSincronizacao { get; set; }

        public string dsStatus { get; set; } = string.Empty;

        public string? dsMensagem { get; set; }
    }
}
