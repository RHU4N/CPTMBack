namespace CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate
{
    public interface ITB_LOG_SINCRONIZACAORepository
    {
        void Add(TB_LOG_SINCRONIZACAO entity);
        TB_LOG_SINCRONIZACAO? Get(int id);
        IEnumerable<TB_LOG_SINCRONIZACAO> GetByUsuario(int idUsuario);
        IEnumerable<TB_LOG_SINCRONIZACAO> GetAll();
        bool Update(TB_LOG_SINCRONIZACAO entity);
        bool Delete(int id);
    }
}
