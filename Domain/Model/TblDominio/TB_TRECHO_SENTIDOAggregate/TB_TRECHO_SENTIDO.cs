using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate
{
    [Table("TB_TRECHO_SENTIDO")]
    public class TB_TRECHO_SENTIDO
    {
        [Key]
        [Column("ID_TRECHO")]
        public int idTrecho { get; private set; }

        [Column("DS_TRECHO")]
        public string dsTrecho { get; private set; }

        public TB_TRECHO_SENTIDO()
        {
            dsTrecho = string.Empty;
        }

        public TB_TRECHO_SENTIDO(int idTrecho, string dsTrecho)
        {
            this.idTrecho = idTrecho;
            this.dsTrecho = dsTrecho;
        }
    }
}
