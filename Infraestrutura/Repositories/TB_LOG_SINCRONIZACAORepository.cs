using CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_LOG_SINCRONIZACAORepository : ITB_LOG_SINCRONIZACAORepository
    {
        private readonly ConnectContext _context;

        public TB_LOG_SINCRONIZACAORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_LOG_SINCRONIZACAO entity)
        {
            _context.TB_LOG_SINCRONIZACAO.Add(entity);
            _context.SaveChanges();
        }

        public TB_LOG_SINCRONIZACAO? Get(int id)
        {
            return _context.TB_LOG_SINCRONIZACAO.FirstOrDefault(x => x.idLog == id);
        }

        public IEnumerable<TB_LOG_SINCRONIZACAO> GetByUsuario(int idUsuario)
        {
            return _context.TB_LOG_SINCRONIZACAO.Where(x => x.idUsuario == idUsuario).ToList();
        }

        public IEnumerable<TB_LOG_SINCRONIZACAO> GetAll()
        {
            return _context.TB_LOG_SINCRONIZACAO.ToList();
        }

        public bool Update(TB_LOG_SINCRONIZACAO entity)
        {
            try
            {
                _context.TB_LOG_SINCRONIZACAO.Update(entity);
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
                    _context.TB_LOG_SINCRONIZACAO.Remove(entity);
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
