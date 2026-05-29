using CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_LOG_ACAORepository : ITB_LOG_ACAORepository
    {
        private readonly ConnectContext _context;

        public TB_LOG_ACAORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_LOG_ACAO entity)
        {
            _context.TB_LOG_ACAO.Add(entity);
            _context.SaveChanges();
        }

        public TB_LOG_ACAO? Get(int id)
        {
            return _context.TB_LOG_ACAO.FirstOrDefault(x => x.idLog == id);
        }

        public IEnumerable<TB_LOG_ACAO> GetByUsuario(int idUsuario)
        {
            return _context.TB_LOG_ACAO.Where(x => x.idUsuario == idUsuario).ToList();
        }

        public IEnumerable<TB_LOG_ACAO> GetAll()
        {
            return _context.TB_LOG_ACAO.ToList();
        }

        public bool Update(TB_LOG_ACAO entity)
        {
            try
            {
                _context.TB_LOG_ACAO.Update(entity);
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
                    _context.TB_LOG_ACAO.Remove(entity);
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
