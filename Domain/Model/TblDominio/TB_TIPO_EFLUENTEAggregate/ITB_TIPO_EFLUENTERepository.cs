namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_EFLUENTEAggregate
{
    public interface ITB_TIPO_EFLUENTERepository
    {
        void Add(TB_TIPO_EFLUENTE entity);
        TB_TIPO_EFLUENTE? Get(int id);
        IEnumerable<TB_TIPO_EFLUENTE> GetAll();
        bool Update(TB_TIPO_EFLUENTE entity);
        bool Delete(int id);
    }
}
