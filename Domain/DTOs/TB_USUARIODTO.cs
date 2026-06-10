namespace CPTMBack.Domain.DTOs
{
    public class TB_USUARIODTO
    {
        public int idUsuario { get; set; }
        public string nmUsuario { get; set; } = string.Empty;
        public string dsLogin { get; set; } = string.Empty;
        public string? dsEmail { get; set; }
        public int idPerfil { get; set; }
        public string dsPerfil { get; set; } = string.Empty;
        public bool flAtivo { get; set; }
        public bool flPrimeiroAcesso { get; set; }
        public DateTime? dtUltimaTrocaSenha { get; set; }
        public DateTime dtCadastro { get; set; }
        public DateTime dtAtualizacao { get; set; }
    }
}
