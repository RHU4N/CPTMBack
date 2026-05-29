namespace CPTMBack.Application.ViewModels
{
    public class RegisterViewModel
    {
        public string nmUsuario { get; set; } = string.Empty;

        public string dsLogin { get; set; } = string.Empty;

        public string dsEmail { get; set; } = string.Empty;

        public string dsSenha { get; set; } = string.Empty;

        public string dsSenhaConfirm { get; set; } = string.Empty;

        public int idPerfil { get; set; } = 2; // Default to operator role
    }
}
