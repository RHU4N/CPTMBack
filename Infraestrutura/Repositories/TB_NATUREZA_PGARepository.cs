using CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_NATUREZA_PGARepository : ITB_NATUREZA_PGARepository
    {
        private readonly ConnectContext _context;

        public TB_NATUREZA_PGARepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_NATUREZA_PGA entity)
        {
            _context.TB_NATUREZA_PGA.Add(entity);
            _context.SaveChanges();
        }

        public TB_NATUREZA_PGA? Get(int id)
        {
            return _context.TB_NATUREZA_PGA.FirstOrDefault(x => x.idNatureza == id);
        }

        public IEnumerable<TB_NATUREZA_PGA> GetAll()
        {
            return _context.TB_NATUREZA_PGA.ToList();
        }

        public bool Update(TB_NATUREZA_PGA entity)
        {
            try
            {
                _context.TB_NATUREZA_PGA.Update(entity);
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
                    _context.TB_NATUREZA_PGA.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
