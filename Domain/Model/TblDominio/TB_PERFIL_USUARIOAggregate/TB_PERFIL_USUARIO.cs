using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate
{
    [Table("TB_PERFIL_USUARIO")]
    public class TB_PERFIL_USUARIO
    {
        [Key]
        [Column("ID_PERFIL")]
        public int idPerfil { get; private set; }

        [Column("DS_PERFIL")]
        public string dsPerfil { get; private set; }

        public TB_PERFIL_USUARIO()
        {
            dsPerfil = string.Empty;
        }

        public TB_PERFIL_USUARIO(int idPerfil, string dsPerfil)
        {
            this.idPerfil = idPerfil;
            this.dsPerfil = dsPerfil;
        }
    }
}
