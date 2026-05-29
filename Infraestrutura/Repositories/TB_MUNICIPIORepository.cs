using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_MUNICIPIORepository : ITB_MUNICIPIORepository
    {
        private readonly ConnectContext _context;

        public TB_MUNICIPIORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_MUNICIPIO entity)
        {
            _context.TB_MUNICIPIO.Add(entity);
            _context.SaveChanges();
        }

        public TB_MUNICIPIO? Get(int id)
        {
            return _context.TB_MUNICIPIO.FirstOrDefault(x => x.idMunicipio == id);
        }

        public IEnumerable<TB_MUNICIPIO> GetAll()
        {
            return _context.TB_MUNICIPIO.ToList();
        }

        public bool Update(TB_MUNICIPIO entity)
        {
            try
            {
                _context.TB_MUNICIPIO.Update(entity);
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
                    _context.TB_MUNICIPIO.Remove(entity);
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
