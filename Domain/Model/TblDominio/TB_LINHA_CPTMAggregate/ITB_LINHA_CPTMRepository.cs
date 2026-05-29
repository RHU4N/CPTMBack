namespace CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate
{
    public interface ITB_LINHA_CPTMRepository
    {
        void Add(TB_LINHA_CPTM entity);
        TB_LINHA_CPTM? Get(int id);
        IEnumerable<TB_LINHA_CPTM> GetAll();
        bool Update(TB_LINHA_CPTM entity);
        bool Delete(int id);
    }
}
