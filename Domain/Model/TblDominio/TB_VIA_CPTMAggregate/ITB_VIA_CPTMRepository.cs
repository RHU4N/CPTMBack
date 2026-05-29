namespace CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate
{
    public interface ITB_VIA_CPTMRepository
    {
        void Add(TB_VIA_CPTM entity);
        TB_VIA_CPTM? Get(int id);
        IEnumerable<TB_VIA_CPTM> GetAll();
        bool Update(TB_VIA_CPTM entity);
        bool Delete(int id);
    }
}
