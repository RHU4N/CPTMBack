using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_STATUS_REGISTRODTO
    {
        public int idStatus { get; set; }

        public string dsStatus { get; set; } = string.Empty;
    }
}
