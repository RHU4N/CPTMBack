using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_TIPO_EFLUENTEDTO
    {
        public int idTipoEfluente { get; set; }

        public string dsTipoEfluente { get; set; } = string.Empty;
    }
}
