using System.Text.Json.Serialization;

namespace CPTMBack.Domain.DTOs
{
    public class TB_PERFIL_USUARIODTO
    {
        public int idPerfil { get; set; }

        public string dsPerfil { get; set; } = string.Empty;
    }
}
