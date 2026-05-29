using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate
{
    [Table("TB_STATUS_REGISTRO")]
    public class TB_STATUS_REGISTRO
    {
        [Key]
        [Column("ID_STATUS")]
        public int idStatus { get; private set; }

        [Column("DS_STATUS")]
        public string dsStatus { get; private set; }

        public TB_STATUS_REGISTRO()
        {
            dsStatus = string.Empty;
        }

        public TB_STATUS_REGISTRO(int idStatus, string dsStatus)
        {
            this.idStatus = idStatus;
            this.dsStatus = dsStatus;
        }
    }
}
