using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_STATUS_REGISTRORepository : ITB_STATUS_REGISTRORepository
    {
        private readonly ConnectContext _context;

        public TB_STATUS_REGISTRORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_STATUS_REGISTRO entity)
        {
            _context.TB_STATUS_REGISTRO.Add(entity);
            _context.SaveChanges();
        }

        public TB_STATUS_REGISTRO? Get(int id)
        {
            return _context.TB_STATUS_REGISTRO.FirstOrDefault(x => x.idStatus == id);
        }

        public IEnumerable<TB_STATUS_REGISTRO> GetAll()
        {
            return _context.TB_STATUS_REGISTRO.ToList();
        }

        public bool Update(TB_STATUS_REGISTRO entity)
        {
            try
            {
                _context.TB_STATUS_REGISTRO.Update(entity);
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
                    _context.TB_STATUS_REGISTRO.Remove(entity);
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
