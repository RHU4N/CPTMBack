using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate
{
    [Table("TB_MUNICIPIO")]
    public class TB_MUNICIPIO
    {
        [Key]
        [Column("ID_MUNICIPIO")]
        public int idMunicipio { get; private set; }

        [Column("DS_MUNICIPIO")]
        public string dsMunicipio { get; private set; }

        public TB_MUNICIPIO()
        {
            dsMunicipio = string.Empty;
        }

        public TB_MUNICIPIO(int idMunicipio, string dsMunicipio)
        {
            this.idMunicipio = idMunicipio;
            this.dsMunicipio = dsMunicipio;
        }
    }
}
