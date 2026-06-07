using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate
{
    [Table("TB_LOCAL_ATIVIDADE")]
    public class TB_LOCAL_ATIVIDADE
    {
        [Key]
        [Column("ID_LOCAL_ATIVIDADE")]
        public int idLocalAtividade { get; private set; }

        [Column("DS_LOCAL_ATIVIDADE")]
        [MaxLength(255)]
        public string dsLocalAtividade { get; private set; }

        public TB_LOCAL_ATIVIDADE()
        {
            dsLocalAtividade = string.Empty;
        }

        public TB_LOCAL_ATIVIDADE(int idLocalAtividade, string dsLocalAtividade)
        {
            this.idLocalAtividade = idLocalAtividade;
            this.dsLocalAtividade = dsLocalAtividade;
        }
    }
}
