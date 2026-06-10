namespace CPTMBack.Domain.DTOs
{
    public class UpdateUsuarioDTO
    {
        public string nmUsuario { get; set; } = string.Empty;
        public string? dsEmail { get; set; }
        public int idPerfil { get; set; }
    }
}
