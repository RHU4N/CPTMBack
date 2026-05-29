using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate
{
    [Table("TB_VIA_CPTM")]
    public class TB_VIA_CPTM
    {
        [Key]
        [Column("ID_VIA")]
        public int idVia { get; private set; }

        [Column("DS_VIA")]
        public string dsVia { get; private set; }

        public TB_VIA_CPTM()
        {
            dsVia = string.Empty;
        }

        public TB_VIA_CPTM(int idVia, string dsVia)
        {
            this.idVia = idVia;
            this.dsVia = dsVia;
        }
    }
}
