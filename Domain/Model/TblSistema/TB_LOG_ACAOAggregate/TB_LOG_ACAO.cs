using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate
{
    [Table("TB_LOG_ACAO")]
    public class TB_LOG_ACAO
    {
        [Key]
        [Column("ID_LOG")]
        public int idLog { get; private set; }

        [Column("ID_USUARIO")]
        public int idUsuario { get; private set; }

        [Column("DS_ACAO")]
        public string dsAcao { get; private set; }

        [Column("NM_TABELA")]
        public string nmTabela { get; private set; }

        [Column("ID_REGISTRO")]
        public string? idRegistro { get; private set; }

        [Column("DT_ACAO")]
        public DateTime dtAcao { get; private set; }

        [Column("DS_IP")]
        public string? dsIp { get; private set; }

        public TB_LOG_ACAO()
        {
            dsAcao = string.Empty;
            nmTabela = string.Empty;
        }

        public TB_LOG_ACAO(
            int idLog,
            int idUsuario,
            string dsAcao,
            string nmTabela,
            string? idRegistro = null,
            DateTime? dtAcao = null,
            string? dsIp = null)
        {
            this.idLog = idLog;
            this.idUsuario = idUsuario;
            this.dsAcao = dsAcao;
            this.nmTabela = nmTabela;
            this.idRegistro = idRegistro;
            this.dtAcao = dtAcao ?? DateTime.Now;
            this.dsIp = dsIp;
        }
    }
}
