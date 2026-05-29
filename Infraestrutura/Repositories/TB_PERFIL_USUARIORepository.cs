using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_PERFIL_USUARIORepository : ITB_PERFIL_USUARIORepository
    {
        private readonly ConnectContext _context;

        public TB_PERFIL_USUARIORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_PERFIL_USUARIO entity)
        {
            _context.TB_PERFIL_USUARIO.Add(entity);
            _context.SaveChanges();
        }

        public TB_PERFIL_USUARIO? Get(int id)
        {
            return _context.TB_PERFIL_USUARIO.FirstOrDefault(x => x.idPerfil == id);
        }

        public IEnumerable<TB_PERFIL_USUARIO> GetAll()
        {
            return _context.TB_PERFIL_USUARIO.ToList();
        }

        public bool Update(TB_PERFIL_USUARIO entity)
        {
            try
            {
                _context.TB_PERFIL_USUARIO.Update(entity);
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
                    _context.TB_PERFIL_USUARIO.Remove(entity);
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
    }
}
