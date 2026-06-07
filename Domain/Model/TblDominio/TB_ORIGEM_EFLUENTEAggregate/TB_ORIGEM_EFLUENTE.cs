using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate
{
    [Table("TB_ORIGEM_EFLUENTE")]
    public class TB_ORIGEM_EFLUENTE
    {
        [Key]
        [Column("ID_ORIGEM_EFLUENTE")]
        public int idOrigemEfluente { get; private set; }

        [Column("DS_ORIGEM_EFLUENTE")]
        [MaxLength(255)]
        public string dsOrigemEfluente { get; private set; }

        public TB_ORIGEM_EFLUENTE()
        {
            dsOrigemEfluente = string.Empty;
        }

        public TB_ORIGEM_EFLUENTE(int idOrigemEfluente, string dsOrigemEfluente)
        {
            this.idOrigemEfluente = idOrigemEfluente;
            this.dsOrigemEfluente = dsOrigemEfluente;
        }
    }
}
