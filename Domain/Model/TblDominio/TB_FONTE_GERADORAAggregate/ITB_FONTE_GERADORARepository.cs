namespace CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate
{
    public interface ITB_FONTE_GERADORARepository
    {
        void Add(TB_FONTE_GERADORA entity);
        TB_FONTE_GERADORA? Get(int id);
        IEnumerable<TB_FONTE_GERADORA> GetAll();
        bool Update(TB_FONTE_GERADORA entity);
        bool Delete(int id);
    }
}
