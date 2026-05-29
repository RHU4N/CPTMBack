using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_TRECHO_SENTIDODTO
    {
        public int idTrecho { get; set; }

        public string dsTrecho { get; set; } = string.Empty;

        public string? dsSentido { get; set; }
    }
}
