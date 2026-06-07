namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate
{
    public interface ITB_TIPO_ATIV_CPTMRepository
    {
        void Add(TB_TIPO_ATIV_CPTM entity);
        TB_TIPO_ATIV_CPTM? Get(int id);
        IEnumerable<TB_TIPO_ATIV_CPTM> GetAll();
        bool Update(TB_TIPO_ATIV_CPTM entity);
        bool Delete(int id);
    }
}
