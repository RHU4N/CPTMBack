using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate
{
    [Table("TB_AREA_GESTORA_CPTM")]
    public class TB_AREA_GESTORA_CPTM
    {
        [Key]
        [Column("ID_AREA_GESTORA")]
        public int idAreaGestora { get; private set; }

        [Column("DS_AREA_GESTORA")]
        [MaxLength(500)]
        public string dsAreaGestora { get; private set; }

        public TB_AREA_GESTORA_CPTM()
        {
            dsAreaGestora = string.Empty;
        }

        public TB_AREA_GESTORA_CPTM(int idAreaGestora, string dsAreaGestora)
        {
            this.idAreaGestora = idAreaGestora;
            this.dsAreaGestora = dsAreaGestora;
        }
    }
}
