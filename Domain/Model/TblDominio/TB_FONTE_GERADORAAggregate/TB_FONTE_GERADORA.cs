using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate
{
    [Table("TB_FONTE_GERADORA")]
    public class TB_FONTE_GERADORA
    {
        [Key]
        [Column("ID_FONTE_GERADORA")]
        public int idFonteGeradora { get; private set; }

        [Column("DS_FONTE_GERADORA")]
        [MaxLength(255)]
        public string dsFonteGeradora { get; private set; }

        public TB_FONTE_GERADORA()
        {
            dsFonteGeradora = string.Empty;
        }

        public TB_FONTE_GERADORA(int idFonteGeradora, string dsFonteGeradora)
        {
            this.idFonteGeradora = idFonteGeradora;
            this.dsFonteGeradora = dsFonteGeradora;
        }
    }
}
