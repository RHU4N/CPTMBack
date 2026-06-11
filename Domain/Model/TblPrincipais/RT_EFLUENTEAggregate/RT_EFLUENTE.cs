using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate
{
    [Table("RT_EFLUENTE")]
    public class RT_EFLUENTE
    {
        [Key]
        [Column("ATTACHMENTID")]
        public int attachmentId { get; private set; }

        [Column("REL_OBJECTID")]
        public string relObjectId { get; private set; }

        [Column("CONTENT_TYPE")]
        public string? contentType { get; private set; }

        [Column("ATT_NAME")]
        public string? attName { get; private set; }

        [Column("DATA_SIZE")]
        public int? dataSize { get; private set; }

        [Column("DATA", TypeName = "BLOB")]
        public byte[]? data { get; private set; }

        public RT_EFLUENTE()
        {
            relObjectId = string.Empty;
        }

        public RT_EFLUENTE(
            int attachmentId,
            string relObjectId,
            string? contentType = null,
            string? attName = null,
            int? dataSize = null,
            byte[]? data = null)
        {
            this.attachmentId = attachmentId;
            this.relObjectId = relObjectId;
            this.contentType = contentType;
            this.attName = attName;
            this.dataSize = dataSize;
            this.data = data;
        }
    }
}
