namespace CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate
{
    public interface ITB_NATUREZA_PGARepository
    {
        void Add(TB_NATUREZA_PGA entity);
        TB_NATUREZA_PGA? Get(int id);
        IEnumerable<TB_NATUREZA_PGA> GetAll();
        bool Update(TB_NATUREZA_PGA entity);
        bool Delete(int id);
    }
}
