using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate
{
    [Table("TB_STATUS_DESVIO_AMBIENTAL")]
    public class TB_STATUS_DESVIO_AMBIENTAL
    {
        [Key]
        [Column("ID_STATUS")]
        public int idStatus { get; private set; }

        [Column("DS_STATUS")]
        public string dsStatus { get; private set; }

        public TB_STATUS_DESVIO_AMBIENTAL()
        {
            dsStatus = string.Empty;
        }

        public TB_STATUS_DESVIO_AMBIENTAL(int idStatus, string dsStatus)
        {
            this.idStatus = idStatus;
            this.dsStatus = dsStatus;
        }
    }
}
