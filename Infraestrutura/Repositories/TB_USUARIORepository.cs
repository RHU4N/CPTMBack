using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_USUARIORepository : ITB_USUARIORepository
    {
        private readonly ConnectContext _context;

        public TB_USUARIORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_USUARIO entity)
        {
            _context.TB_USUARIO.Add(entity);
            _context.SaveChanges();
        }

        public TB_USUARIO? Get(int id)
        {
            return _context.TB_USUARIO.FirstOrDefault(x => x.idUsuario == id);
        }

        public TB_USUARIO? GetByLogin(string login)
        {
            return _context.TB_USUARIO.FirstOrDefault(x => x.dsLogin.ToLower() == login.ToLower());
        }

        public TB_USUARIO? GetByEmail(string email)
        {
            return _context.TB_USUARIO.FirstOrDefault(x => x.dsEmail != null && x.dsEmail.ToLower() == email.ToLower());
        }

        public IEnumerable<TB_USUARIO> GetAll()
        {
            return _context.TB_USUARIO.ToList();
        }

        public bool Update(TB_USUARIO entity)
        {
            try
            {
                _context.TB_USUARIO.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = Get(id);
                if (entity != null)
                {
                    _context.TB_USUARIO.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public int GetNextId()
        {
            var all = _context.TB_USUARIO.ToList();
            return all.Any() ? all.Max(u => u.idUsuario) + 1 : 1;
        }
    }
}
