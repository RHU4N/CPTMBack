using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_STATUS_DESVIO_AMBIENTALDTO
    {
        public int idStatusDesvio { get; set; }

        public string dsStatusDesvio { get; set; } = string.Empty;
    }
}
