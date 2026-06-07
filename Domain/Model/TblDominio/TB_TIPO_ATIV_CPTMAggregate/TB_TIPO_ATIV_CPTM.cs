using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate
{
    [Table("TB_TIPO_ATIV_CPTM")]
    public class TB_TIPO_ATIV_CPTM
    {
        [Key]
        [Column("ID_TIPO_ATIV_CPTM")]
        public int idTipoAtivCptm { get; private set; }

        [Column("DS_TIPO_ATIV_CPTM")]
        [MaxLength(255)]
        public string dsTipoAtivCptm { get; private set; }

        public TB_TIPO_ATIV_CPTM()
        {
            dsTipoAtivCptm = string.Empty;
        }

        public TB_TIPO_ATIV_CPTM(int idTipoAtivCptm, string dsTipoAtivCptm)
        {
            this.idTipoAtivCptm = idTipoAtivCptm;
            this.dsTipoAtivCptm = dsTipoAtivCptm;
        }
    }
}
