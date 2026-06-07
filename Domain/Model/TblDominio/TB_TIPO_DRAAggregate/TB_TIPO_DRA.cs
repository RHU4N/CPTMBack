using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate
{
    [Table("TB_TIPO_DRA")]
    public class TB_TIPO_DRA
    {
        [Key]
        [Column("ID_TIPO_DRA")]
        public int idTipoDra { get; private set; }

        [Column("DS_TIPO_DRA")]
        [MaxLength(255)]
        public string dsTipoDra { get; private set; }

        public TB_TIPO_DRA()
        {
            dsTipoDra = string.Empty;
        }

        public TB_TIPO_DRA(int idTipoDra, string dsTipoDra)
        {
            this.idTipoDra = idTipoDra;
            this.dsTipoDra = dsTipoDra;
        }
    }
}
