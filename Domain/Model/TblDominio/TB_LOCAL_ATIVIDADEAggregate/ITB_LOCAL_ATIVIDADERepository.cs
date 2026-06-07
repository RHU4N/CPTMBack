namespace CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate
{
    public interface ITB_LOCAL_ATIVIDADERepository
    {
        void Add(TB_LOCAL_ATIVIDADE entity);
        TB_LOCAL_ATIVIDADE? Get(int id);
        IEnumerable<TB_LOCAL_ATIVIDADE> GetAll();
        bool Update(TB_LOCAL_ATIVIDADE entity);
        bool Delete(int id);
    }
}
