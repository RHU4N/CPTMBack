using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate
{
    [Table("TB_TIPO_ATIVIDADE")]
    public class TB_TIPO_ATIVIDADE
    {
        [Key]
        [Column("ID_TIPO_ATIVIDADE")]
        public int idTipoAtividade { get; private set; }

        [Column("DS_TIPO_ATIVIDADE")]
        [MaxLength(255)]
        public string dsTipoAtividade { get; private set; }

        public TB_TIPO_ATIVIDADE()
        {
            dsTipoAtividade = string.Empty;
        }

        public TB_TIPO_ATIVIDADE(int idTipoAtividade, string dsTipoAtividade)
        {
            this.idTipoAtividade = idTipoAtividade;
            this.dsTipoAtividade = dsTipoAtividade;
        }
    }
}
