using CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_FONTE_GERADORARepository : ITB_FONTE_GERADORARepository
    {
        private readonly ConnectContext _context;

        public TB_FONTE_GERADORARepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_FONTE_GERADORA entity)
        {
            _context.TB_FONTE_GERADORA.Add(entity);
            _context.SaveChanges();
        }

        public TB_FONTE_GERADORA? Get(int id)
        {
            return _context.TB_FONTE_GERADORA.FirstOrDefault(x => x.idFonteGeradora == id);
        }

        public IEnumerable<TB_FONTE_GERADORA> GetAll()
        {
            return _context.TB_FONTE_GERADORA.ToList();
        }

        public bool Update(TB_FONTE_GERADORA entity)
        {
            try
            {
                _context.TB_FONTE_GERADORA.Update(entity);
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
                    _context.TB_FONTE_GERADORA.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
