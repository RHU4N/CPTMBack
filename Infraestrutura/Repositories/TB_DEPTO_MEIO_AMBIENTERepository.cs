using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_DEPTO_MEIO_AMBIENTERepository : ITB_DEPTO_MEIO_AMBIENTERepository
    {
        private readonly ConnectContext _context;

        public TB_DEPTO_MEIO_AMBIENTERepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_DEPTO_MEIO_AMBIENTE entity)
        {
            _context.TB_DEPTO_MEIO_AMBIENTE.Add(entity);
            _context.SaveChanges();
        }

        public TB_DEPTO_MEIO_AMBIENTE? Get(int id)
        {
            return _context.TB_DEPTO_MEIO_AMBIENTE.FirstOrDefault(x => x.idDepto == id);
        }

        public IEnumerable<TB_DEPTO_MEIO_AMBIENTE> GetAll()
        {
            return _context.TB_DEPTO_MEIO_AMBIENTE.ToList();
        }

        public bool Update(TB_DEPTO_MEIO_AMBIENTE entity)
        {
            try
            {
                _context.TB_DEPTO_MEIO_AMBIENTE.Update(entity);
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
                    _context.TB_DEPTO_MEIO_AMBIENTE.Remove(entity);
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
