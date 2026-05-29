namespace CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate
{
    public interface ITB_MUNICIPIORepository
    {
        void Add(TB_MUNICIPIO entity);
        TB_MUNICIPIO? Get(int id);
        IEnumerable<TB_MUNICIPIO> GetAll();
        bool Update(TB_MUNICIPIO entity);
        bool Delete(int id);
    }
}
