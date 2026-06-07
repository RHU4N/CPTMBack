using CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_LOCAL_ATIVIDADERepository : ITB_LOCAL_ATIVIDADERepository
    {
        private readonly ConnectContext _context;

        public TB_LOCAL_ATIVIDADERepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_LOCAL_ATIVIDADE entity)
        {
            _context.TB_LOCAL_ATIVIDADE.Add(entity);
            _context.SaveChanges();
        }

        public TB_LOCAL_ATIVIDADE? Get(int id)
        {
            return _context.TB_LOCAL_ATIVIDADE.FirstOrDefault(x => x.idLocalAtividade == id);
        }

        public IEnumerable<TB_LOCAL_ATIVIDADE> GetAll()
        {
            return _context.TB_LOCAL_ATIVIDADE.ToList();
        }

        public bool Update(TB_LOCAL_ATIVIDADE entity)
        {
            try
            {
                _context.TB_LOCAL_ATIVIDADE.Update(entity);
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
                    _context.TB_LOCAL_ATIVIDADE.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
