namespace CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate
{
    public interface ITB_STATUS_REGISTRORepository
    {
        void Add(TB_STATUS_REGISTRO entity);
        TB_STATUS_REGISTRO? Get(int id);
        IEnumerable<TB_STATUS_REGISTRO> GetAll();
        bool Update(TB_STATUS_REGISTRO entity);
        bool Delete(int id);
    }
}
