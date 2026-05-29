namespace CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate
{
    public interface ITB_LOG_ACAORepository
    {
        void Add(TB_LOG_ACAO entity);
        TB_LOG_ACAO? Get(int id);
        IEnumerable<TB_LOG_ACAO> GetByUsuario(int idUsuario);
        IEnumerable<TB_LOG_ACAO> GetAll();
        bool Update(TB_LOG_ACAO entity);
        bool Delete(int id);
    }
}
