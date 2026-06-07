using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate
{
    [Table("TB_PROPRIETARIO")]
    public class TB_PROPRIETARIO
    {
        [Key]
        [Column("ID_PROPRIETARIO")]
        public int idProprietario { get; private set; }

        [Column("DS_PROPRIETARIO")]
        [MaxLength(255)]
        public string dsProprietario { get; private set; }

        public TB_PROPRIETARIO()
        {
            dsProprietario = string.Empty;
        }

        public TB_PROPRIETARIO(int idProprietario, string dsProprietario)
        {
            this.idProprietario = idProprietario;
            this.dsProprietario = dsProprietario;
        }
    }
}
