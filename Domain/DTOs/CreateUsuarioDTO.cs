namespace CPTMBack.Domain.DTOs
{
    public class CreateUsuarioDTO
    {
        public string nmUsuario { get; set; } = string.Empty;
        public string dsEmail { get; set; } = string.Empty;
        public string dsLogin { get; set; } = string.Empty;
        public int idPerfil { get; set; }
        public string dsSenha { get; set; } = string.Empty;
        public bool flAtivo { get; set; } = true;
    }
}
