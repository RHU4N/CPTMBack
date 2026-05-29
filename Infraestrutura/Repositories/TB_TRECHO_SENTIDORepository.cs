using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_TRECHO_SENTIDORepository : ITB_TRECHO_SENTIDORepository
    {
        private readonly ConnectContext _context;

        public TB_TRECHO_SENTIDORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_TRECHO_SENTIDO entity)
        {
            _context.TB_TRECHO_SENTIDO.Add(entity);
            _context.SaveChanges();
        }

        public TB_TRECHO_SENTIDO? Get(int id)
        {
            return _context.TB_TRECHO_SENTIDO.FirstOrDefault(x => x.idTrecho == id);
        }

        public IEnumerable<TB_TRECHO_SENTIDO> GetAll()
        {
            return _context.TB_TRECHO_SENTIDO.ToList();
        }

        public bool Update(TB_TRECHO_SENTIDO entity)
        {
            try
            {
                _context.TB_TRECHO_SENTIDO.Update(entity);
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
                    _context.TB_TRECHO_SENTIDO.Remove(entity);
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
