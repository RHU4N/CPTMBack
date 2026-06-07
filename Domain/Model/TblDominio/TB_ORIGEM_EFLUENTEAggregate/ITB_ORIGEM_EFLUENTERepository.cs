namespace CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate
{
    public interface ITB_ORIGEM_EFLUENTERepository
    {
        void Add(TB_ORIGEM_EFLUENTE entity);
        TB_ORIGEM_EFLUENTE? Get(int id);
        IEnumerable<TB_ORIGEM_EFLUENTE> GetAll();
        bool Update(TB_ORIGEM_EFLUENTE entity);
        bool Delete(int id);
    }
}
