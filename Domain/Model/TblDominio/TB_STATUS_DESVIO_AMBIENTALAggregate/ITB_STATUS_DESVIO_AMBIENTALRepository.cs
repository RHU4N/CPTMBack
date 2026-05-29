namespace CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate
{
    public interface ITB_STATUS_DESVIO_AMBIENTALRepository
    {
        void Add(TB_STATUS_DESVIO_AMBIENTAL entity);
        TB_STATUS_DESVIO_AMBIENTAL? Get(int id);
        IEnumerable<TB_STATUS_DESVIO_AMBIENTAL> GetAll();
        bool Update(TB_STATUS_DESVIO_AMBIENTAL entity);
        bool Delete(int id);
    }
}
