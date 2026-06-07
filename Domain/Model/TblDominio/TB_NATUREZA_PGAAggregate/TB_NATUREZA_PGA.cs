using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate
{
    [Table("TB_NATUREZA_PGA")]
    public class TB_NATUREZA_PGA
    {
        [Key]
        [Column("ID_NATUREZA")]
        public int idNatureza { get; private set; }

        [Column("DS_NATUREZA")]
        [MaxLength(255)]
        public string dsNatureza { get; private set; }

        public TB_NATUREZA_PGA()
        {
            dsNatureza = string.Empty;
        }

        public TB_NATUREZA_PGA(int idNatureza, string dsNatureza)
        {
            this.idNatureza = idNatureza;
            this.dsNatureza = dsNatureza;
        }
    }
}
