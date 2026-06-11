namespace CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate
{
    public interface IRT_EFLUENTERepository
    {
        void Add(RT_EFLUENTE entity);
        RT_EFLUENTE? Get(int id);
        IEnumerable<RT_EFLUENTE> GetAll();
        IEnumerable<RT_EFLUENTE> GetByRelObjectId(string relObjectId);
        bool Update(RT_EFLUENTE entity);
        bool Delete(int id);
        int GetNextId();
    }
}
