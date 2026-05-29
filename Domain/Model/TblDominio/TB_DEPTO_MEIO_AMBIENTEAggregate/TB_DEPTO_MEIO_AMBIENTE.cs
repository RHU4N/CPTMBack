using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate
{
    [Table("TB_DEPTO_MEIO_AMBIENTE")]
    public class TB_DEPTO_MEIO_AMBIENTE
    {
        [Key]
        [Column("ID_DEPTO")]
        public int idDepto { get; private set; }

        [Column("DS_DEPTO")]
        public string dsDepto { get; private set; }

        public TB_DEPTO_MEIO_AMBIENTE()
        {
            dsDepto = string.Empty;
        }

        public TB_DEPTO_MEIO_AMBIENTE(int idDepto, string dsDepto)
        {
            this.idDepto = idDepto;
            this.dsDepto = dsDepto;
        }
    }
}
