namespace CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate
{
    public interface ITB_PERFIL_USUARIORepository
    {
        void Add(TB_PERFIL_USUARIO entity);
        TB_PERFIL_USUARIO? Get(int id);
        IEnumerable<TB_PERFIL_USUARIO> GetAll();
        bool Update(TB_PERFIL_USUARIO entity);
        bool Delete(int id);
    }
}
