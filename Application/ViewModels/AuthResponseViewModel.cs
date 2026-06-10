namespace CPTMBack.Application.ViewModels
{
    public class AuthResponseViewModel
    {
        public bool sucesso { get; set; }
        public string? mensagem { get; set; }
        public string? token { get; set; }
        public int? idUsuario { get; set; }
        public string? nmUsuario { get; set; }
        public string? dsLogin { get; set; }
        public string? dsEmail { get; set; }
        public int? idPerfil { get; set; }
        public bool primeiroAcesso { get; set; }
    }
}
