namespace CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate
{
    public interface ITB_AREA_GESTORA_CPTMRepository
    {
        void Add(TB_AREA_GESTORA_CPTM entity);
        TB_AREA_GESTORA_CPTM? Get(int id);
        IEnumerable<TB_AREA_GESTORA_CPTM> GetAll();
        bool Update(TB_AREA_GESTORA_CPTM entity);
        bool Delete(int id);
    }
}
