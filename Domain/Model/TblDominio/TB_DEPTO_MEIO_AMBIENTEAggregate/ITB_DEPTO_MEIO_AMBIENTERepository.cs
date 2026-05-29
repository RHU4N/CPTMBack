namespace CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate
{
    public interface ITB_DEPTO_MEIO_AMBIENTERepository
    {
        void Add(TB_DEPTO_MEIO_AMBIENTE entity);
        TB_DEPTO_MEIO_AMBIENTE? Get(int id);
        IEnumerable<TB_DEPTO_MEIO_AMBIENTE> GetAll();
        bool Update(TB_DEPTO_MEIO_AMBIENTE entity);
        bool Delete(int id);
    }
}
