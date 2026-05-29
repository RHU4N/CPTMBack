using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_VIA_CPTMRepository : ITB_VIA_CPTMRepository
    {
        private readonly ConnectContext _context;

        public TB_VIA_CPTMRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_VIA_CPTM entity)
        {
            _context.TB_VIA_CPTM.Add(entity);
            _context.SaveChanges();
        }

        public TB_VIA_CPTM? Get(int id)
        {
            return _context.TB_VIA_CPTM.FirstOrDefault(x => x.idVia == id);
        }

        public IEnumerable<TB_VIA_CPTM> GetAll()
        {
            return _context.TB_VIA_CPTM.ToList();
        }

        public bool Update(TB_VIA_CPTM entity)
        {
            try
            {
                _context.TB_VIA_CPTM.Update(entity);
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
                    _context.TB_VIA_CPTM.Remove(entity);
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
