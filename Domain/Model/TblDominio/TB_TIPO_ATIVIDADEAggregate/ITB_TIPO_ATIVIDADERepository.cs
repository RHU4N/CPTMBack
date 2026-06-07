namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate
{
    public interface ITB_TIPO_ATIVIDADERepository
    {
        void Add(TB_TIPO_ATIVIDADE entity);
        TB_TIPO_ATIVIDADE? Get(int id);
        IEnumerable<TB_TIPO_ATIVIDADE> GetAll();
        bool Update(TB_TIPO_ATIVIDADE entity);
        bool Delete(int id);
    }
}
