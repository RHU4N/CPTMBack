using CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_PROPRIETARIORepository : ITB_PROPRIETARIORepository
    {
        private readonly ConnectContext _context;

        public TB_PROPRIETARIORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_PROPRIETARIO entity)
        {
            _context.TB_PROPRIETARIO.Add(entity);
            _context.SaveChanges();
        }

        public TB_PROPRIETARIO? Get(int id)
        {
            return _context.TB_PROPRIETARIO.FirstOrDefault(x => x.idProprietario == id);
        }

        public IEnumerable<TB_PROPRIETARIO> GetAll()
        {
            return _context.TB_PROPRIETARIO.ToList();
        }

        public bool Update(TB_PROPRIETARIO entity)
        {
            try
            {
                _context.TB_PROPRIETARIO.Update(entity);
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
                    _context.TB_PROPRIETARIO.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
