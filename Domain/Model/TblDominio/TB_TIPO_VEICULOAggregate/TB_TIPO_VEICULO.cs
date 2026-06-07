using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate
{
    [Table("TB_TIPO_VEICULO")]
    public class TB_TIPO_VEICULO
    {
        [Key]
        [Column("ID_TIPO_VEICULO")]
        public int idTipoVeiculo { get; private set; }

        [Column("DS_TIPO_VEICULO")]
        [MaxLength(255)]
        public string dsTipoVeiculo { get; private set; }

        public TB_TIPO_VEICULO()
        {
            dsTipoVeiculo = string.Empty;
        }

        public TB_TIPO_VEICULO(int idTipoVeiculo, string dsTipoVeiculo)
        {
            this.idTipoVeiculo = idTipoVeiculo;
            this.dsTipoVeiculo = dsTipoVeiculo;
        }
    }
}
