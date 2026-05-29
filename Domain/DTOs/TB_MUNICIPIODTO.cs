using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_MUNICIPIODTO
    {
        public int idMunicipio { get; set; }

        public string nmMunicipio { get; set; } = string.Empty;

        public string? sgUf { get; set; }
    }
}
