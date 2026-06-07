using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate
{
    [Table("TB_SIM_NAO")]
    public class TB_SIM_NAO
    {
        [Key]
        [Column("ID_SIM_NAO")]
        public int idSimNao { get; private set; }

        [Column("DS_SIM_NAO")]
        [MaxLength(255)]
        public string dsSimNao { get; private set; }

        public TB_SIM_NAO()
        {
            dsSimNao = string.Empty;
        }

        public TB_SIM_NAO(int idSimNao, string dsSimNao)
        {
            this.idSimNao = idSimNao;
            this.dsSimNao = dsSimNao;
        }
    }
}
