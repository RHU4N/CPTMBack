using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_LINHA_CPTMDTO
    {
        public int idLinha { get; set; }

        public string dsLinha { get; set; } = string.Empty;
    }
}
