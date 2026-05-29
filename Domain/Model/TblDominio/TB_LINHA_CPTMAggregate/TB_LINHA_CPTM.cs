using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate
{
    [Table("TB_LINHA_CPTM")]
    public class TB_LINHA_CPTM
    {
        [Key]
        [Column("ID_LINHA")]
        public int idLinha { get; private set; }

        [Column("DS_LINHA")]
        public string dsLinha { get; private set; }

        public TB_LINHA_CPTM()
        {
            dsLinha = string.Empty;
        }

        public TB_LINHA_CPTM(int idLinha, string dsLinha)
        {
            this.idLinha = idLinha;
            this.dsLinha = dsLinha;
        }
    }
}
