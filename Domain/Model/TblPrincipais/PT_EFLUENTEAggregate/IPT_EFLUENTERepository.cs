namespace CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate
{
    public interface IPT_EFLUENTERepository
    {
        void Add(PT_EFLUENTE entity);
        PT_EFLUENTE? Get(string id);
        IEnumerable<PT_EFLUENTE> GetAll();
        bool Update(PT_EFLUENTE entity);
        bool Delete(string id);
    }
}
