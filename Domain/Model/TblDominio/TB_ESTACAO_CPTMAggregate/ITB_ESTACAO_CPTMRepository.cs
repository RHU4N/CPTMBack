namespace CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate
{
    public interface ITB_ESTACAO_CPTMRepository
    {
        void Add(TB_ESTACAO_CPTM entity);
        TB_ESTACAO_CPTM? Get(int id);
        IEnumerable<TB_ESTACAO_CPTM> GetAll();
        bool Update(TB_ESTACAO_CPTM entity);
        bool Delete(int id);
    }
}
