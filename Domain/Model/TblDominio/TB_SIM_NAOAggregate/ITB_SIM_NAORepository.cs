namespace CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate
{
    public interface ITB_SIM_NAORepository
    {
        void Add(TB_SIM_NAO entity);
        TB_SIM_NAO? Get(int id);
        IEnumerable<TB_SIM_NAO> GetAll();
        bool Update(TB_SIM_NAO entity);
        bool Delete(int id);
    }
}
