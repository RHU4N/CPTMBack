using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_TIPO_DRARepository : ITB_TIPO_DRARepository
    {
        private readonly ConnectContext _context;

        public TB_TIPO_DRARepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_TIPO_DRA entity)
        {
            _context.TB_TIPO_DRA.Add(entity);
            _context.SaveChanges();
        }

        public TB_TIPO_DRA? Get(int id)
        {
            return _context.TB_TIPO_DRA.FirstOrDefault(x => x.idTipoDra == id);
        }

        public IEnumerable<TB_TIPO_DRA> GetAll()
        {
            return _context.TB_TIPO_DRA.ToList();
        }

        public bool Update(TB_TIPO_DRA entity)
        {
            try
            {
                _context.TB_TIPO_DRA.Update(entity);
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
                    _context.TB_TIPO_DRA.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
