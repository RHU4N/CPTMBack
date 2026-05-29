using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate
{
    [Table("TB_USUARIO")]
    public class TB_USUARIO
    {
        [Key]
        [Column("ID_USUARIO")]
        public int idUsuario { get; private set; }

        [Column("NM_USUARIO")]
        public string nmUsuario { get; private set; }

        [Column("DS_LOGIN")]
        public string dsLogin { get; private set; }

        [Column("DS_EMAIL")]
        public string? dsEmail { get; private set; }

        [Column("DS_SENHA_HASH")]
        public string dsSenhaHash { get; private set; }

        [Column("ID_PERFIL")]
        public int idPerfil { get; private set; }

        [Column("FL_ATIVO")]
        public bool flAtivo { get; private set; }

        [Column("DT_CADASTRO")]
        public DateTime dtCadastro { get; private set; }

        [Column("DT_ATUALIZACAO")]
        public DateTime dtAtualizacao { get; private set; }

        public TB_USUARIO()
        {
            nmUsuario = string.Empty;
            dsLogin = string.Empty;
            dsSenhaHash = string.Empty;
        }

        public TB_USUARIO(
            int idUsuario,
            string nmUsuario,
            string dsLogin,
            string dsSenhaHash,
            int idPerfil,
            string? dsEmail = null,
            bool flAtivo = true,
            DateTime? dtCadastro = null,
            DateTime? dtAtualizacao = null)
        {
            this.idUsuario = idUsuario;
            this.nmUsuario = nmUsuario;
            this.dsLogin = dsLogin;
            this.dsEmail = dsEmail;
            this.dsSenhaHash = dsSenhaHash;
            this.idPerfil = idPerfil;
            this.flAtivo = flAtivo;
            this.dtCadastro = dtCadastro ?? DateTime.Now;
            this.dtAtualizacao = dtAtualizacao ?? DateTime.Now;
        }

        // ===== Public Methods =====

        public void UpdatePassword(string newPasswordHash)
        {
            dsSenhaHash = newPasswordHash;
            dtAtualizacao = DateTime.Now;
        }

        public void SetActive(bool isActive)
        {
            flAtivo = isActive;
            dtAtualizacao = DateTime.Now;
        }

        public void UpdateInfo(string nmUsuario, string? dsEmail)
        {
            this.nmUsuario = nmUsuario;
            this.dsEmail = dsEmail;
            dtAtualizacao = DateTime.Now;
        }
    }
}
