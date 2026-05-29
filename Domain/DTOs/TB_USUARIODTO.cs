using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_USUARIODTO
    {
        public int idUsuario { get; set; }

        public string nmUsuario { get; set; } = string.Empty;

        public string dsLogin { get; set; } = string.Empty;

        public string? dsEmail { get; set; }

        public int idPerfil { get; set; }

        public bool flAtivo { get; set; }

        public DateTime dtCadastro { get; set; }
    }
}
