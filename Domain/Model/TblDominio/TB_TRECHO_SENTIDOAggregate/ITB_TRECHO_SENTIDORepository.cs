namespace CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate
{
    public interface ITB_TRECHO_SENTIDORepository
    {
        void Add(TB_TRECHO_SENTIDO entity);
        TB_TRECHO_SENTIDO? Get(int id);
        IEnumerable<TB_TRECHO_SENTIDO> GetAll();
        bool Update(TB_TRECHO_SENTIDO entity);
        bool Delete(int id);
    }
}
