using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate
{
    [Table("TB_ESTACAO_CPTM")]
    public class TB_ESTACAO_CPTM
    {
        [Key]
        [Column("ID_ESTACAO")]
        public int idEstacao { get; private set; }

        [Column("DS_ESTACAO")]
        [MaxLength(255)]
        public string dsEstacao { get; private set; }

        public TB_ESTACAO_CPTM()
        {
            dsEstacao = string.Empty;
        }

        public TB_ESTACAO_CPTM(int idEstacao, string dsEstacao)
        {
            this.idEstacao = idEstacao;
            this.dsEstacao = dsEstacao;
        }
    }
}
