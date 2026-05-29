using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_EFLUENTEAggregate
{
    [Table("TB_TIPO_EFLUENTE")]
    public class TB_TIPO_EFLUENTE
    {
        [Key]
        [Column("ID_TIPO_EFLUENTE")]
        public int idTipoEfluente { get; private set; }

        [Column("DS_TIPO_EFLUENTE")]
        public string dsTipoEfluente { get; private set; }

        public TB_TIPO_EFLUENTE()
        {
            dsTipoEfluente = string.Empty;
        }

        public TB_TIPO_EFLUENTE(int idTipoEfluente, string dsTipoEfluente)
        {
            this.idTipoEfluente = idTipoEfluente;
            this.dsTipoEfluente = dsTipoEfluente;
        }
    }
}
