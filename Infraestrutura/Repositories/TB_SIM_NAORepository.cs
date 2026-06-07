using CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_SIM_NAORepository : ITB_SIM_NAORepository
    {
        private readonly ConnectContext _context;

        public TB_SIM_NAORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_SIM_NAO entity)
        {
            _context.TB_SIM_NAO.Add(entity);
            _context.SaveChanges();
        }

        public TB_SIM_NAO? Get(int id)
        {
            return _context.TB_SIM_NAO.FirstOrDefault(x => x.idSimNao == id);
        }

        public IEnumerable<TB_SIM_NAO> GetAll()
        {
            return _context.TB_SIM_NAO.ToList();
        }

        public bool Update(TB_SIM_NAO entity)
        {
            try
            {
                _context.TB_SIM_NAO.Update(entity);
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
                    _context.TB_SIM_NAO.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
