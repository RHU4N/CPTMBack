namespace CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate
{
    public interface ITB_PROPRIETARIORepository
    {
        void Add(TB_PROPRIETARIO entity);
        TB_PROPRIETARIO? Get(int id);
        IEnumerable<TB_PROPRIETARIO> GetAll();
        bool Update(TB_PROPRIETARIO entity);
        bool Delete(int id);
    }
}
