namespace CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate
{
    public interface ITB_TIPO_VEICULORepository
    {
        void Add(TB_TIPO_VEICULO entity);
        TB_TIPO_VEICULO? Get(int id);
        IEnumerable<TB_TIPO_VEICULO> GetAll();
        bool Update(TB_TIPO_VEICULO entity);
        bool Delete(int id);
    }
}
