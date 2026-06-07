namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate
{
    public interface ITB_TIPO_DESTINACAORepository
    {
        void Add(TB_TIPO_DESTINACAO entity);
        TB_TIPO_DESTINACAO? Get(int id);
        IEnumerable<TB_TIPO_DESTINACAO> GetAll();
        bool Update(TB_TIPO_DESTINACAO entity);
        bool Delete(int id);
    }
}
