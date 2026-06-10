namespace CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate
{
    public interface ITB_USUARIORepository
    {
        void Add(TB_USUARIO entity);
        TB_USUARIO? Get(int id);
        TB_USUARIO? GetByLogin(string login);
        TB_USUARIO? GetByEmail(string email);
        IEnumerable<TB_USUARIO> GetAll();
        bool Update(TB_USUARIO entity);
        bool Delete(int id);
        int GetNextId();
    }
}
