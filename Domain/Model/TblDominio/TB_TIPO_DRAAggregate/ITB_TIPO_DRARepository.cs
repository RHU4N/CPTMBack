namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate
{
    public interface ITB_TIPO_DRARepository
    {
        void Add(TB_TIPO_DRA entity);
        TB_TIPO_DRA? Get(int id);
        IEnumerable<TB_TIPO_DRA> GetAll();
        bool Update(TB_TIPO_DRA entity);
        bool Delete(int id);
    }
}
