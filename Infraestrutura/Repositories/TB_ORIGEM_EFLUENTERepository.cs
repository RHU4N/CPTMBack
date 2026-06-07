using CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_ORIGEM_EFLUENTERepository : ITB_ORIGEM_EFLUENTERepository
    {
        private readonly ConnectContext _context;

        public TB_ORIGEM_EFLUENTERepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_ORIGEM_EFLUENTE entity)
        {
            _context.TB_ORIGEM_EFLUENTE.Add(entity);
            _context.SaveChanges();
        }

        public TB_ORIGEM_EFLUENTE? Get(int id)
        {
            return _context.TB_ORIGEM_EFLUENTE.FirstOrDefault(x => x.idOrigemEfluente == id);
        }

        public IEnumerable<TB_ORIGEM_EFLUENTE> GetAll()
        {
            return _context.TB_ORIGEM_EFLUENTE.ToList();
        }

        public bool Update(TB_ORIGEM_EFLUENTE entity)
        {
            try
            {
                _context.TB_ORIGEM_EFLUENTE.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = Get(id);
                if (entity != null)
                {
                    _context.TB_ORIGEM_EFLUENTE.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
