using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate
{
    [Table("TB_TIPO_DESTINACAO")]
    public class TB_TIPO_DESTINACAO
    {
        [Key]
        [Column("ID_TIPO_DESTINACAO")]
        public int idTipoDestinacao { get; private set; }

        [Column("DS_TIPO_DESTINACAO")]
        [MaxLength(255)]
        public string dsTipoDestinacao { get; private set; }

        public TB_TIPO_DESTINACAO()
        {
            dsTipoDestinacao = string.Empty;
        }

        public TB_TIPO_DESTINACAO(int idTipoDestinacao, string dsTipoDestinacao)
        {
            this.idTipoDestinacao = idTipoDestinacao;
            this.dsTipoDestinacao = dsTipoDestinacao;
        }
    }
}
