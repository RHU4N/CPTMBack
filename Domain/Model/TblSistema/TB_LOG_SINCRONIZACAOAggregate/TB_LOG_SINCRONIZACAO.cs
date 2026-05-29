using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate
{
    [Table("TB_LOG_SINCRONIZACAO")]
    public class TB_LOG_SINCRONIZACAO
    {
        [Key]
        [Column("ID_LOG")]
        public int idLog { get; private set; }

        [Column("ID_USUARIO")]
        public int idUsuario { get; private set; }

        [Column("DT_SINCRONIZACAO")]
        public DateTime dtSincronizacao { get; private set; }

        [Column("DS_STATUS")]
        public string dsStatus { get; private set; }

        [Column("DS_MENSAGEM")]
        public string? dsMensagem { get; private set; }

        public TB_LOG_SINCRONIZACAO()
        {
            dsStatus = string.Empty;
        }

        public TB_LOG_SINCRONIZACAO(
            int idLog,
            int idUsuario,
            string dsStatus,
            DateTime? dtSincronizacao = null,
            string? dsMensagem = null)
        {
            this.idLog = idLog;
            this.idUsuario = idUsuario;
            this.dsStatus = dsStatus;
            this.dtSincronizacao = dtSincronizacao ?? DateTime.Now;
            this.dsMensagem = dsMensagem;
        }
    }
}
