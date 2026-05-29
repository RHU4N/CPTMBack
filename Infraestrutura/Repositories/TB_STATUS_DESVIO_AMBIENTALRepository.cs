using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_STATUS_DESVIO_AMBIENTALRepository : ITB_STATUS_DESVIO_AMBIENTALRepository
    {
        private readonly ConnectContext _context;

        public TB_STATUS_DESVIO_AMBIENTALRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_STATUS_DESVIO_AMBIENTAL entity)
        {
            _context.TB_STATUS_DESVIO_AMBIENTAL.Add(entity);
            _context.SaveChanges();
        }

        public TB_STATUS_DESVIO_AMBIENTAL? Get(int id)
        {
            return _context.TB_STATUS_DESVIO_AMBIENTAL.FirstOrDefault(x => x.idStatus == id);
        }

        public IEnumerable<TB_STATUS_DESVIO_AMBIENTAL> GetAll()
        {
            return _context.TB_STATUS_DESVIO_AMBIENTAL.ToList();
        }

        public bool Update(TB_STATUS_DESVIO_AMBIENTAL entity)
        {
            try
            {
                _context.TB_STATUS_DESVIO_AMBIENTAL.Update(entity);
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
                    _context.TB_STATUS_DESVIO_AMBIENTAL.Remove(entity);
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
