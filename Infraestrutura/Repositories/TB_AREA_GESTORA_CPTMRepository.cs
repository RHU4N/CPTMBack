using CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_AREA_GESTORA_CPTMRepository : ITB_AREA_GESTORA_CPTMRepository
    {
        private readonly ConnectContext _context;

        public TB_AREA_GESTORA_CPTMRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_AREA_GESTORA_CPTM entity)
        {
            _context.TB_AREA_GESTORA_CPTM.Add(entity);
            _context.SaveChanges();
        }

        public TB_AREA_GESTORA_CPTM? Get(int id)
        {
            return _context.TB_AREA_GESTORA_CPTM.FirstOrDefault(x => x.idAreaGestora == id);
        }

        public IEnumerable<TB_AREA_GESTORA_CPTM> GetAll()
        {
            return _context.TB_AREA_GESTORA_CPTM.ToList();
        }

        public bool Update(TB_AREA_GESTORA_CPTM entity)
        {
            try
            {
                _context.TB_AREA_GESTORA_CPTM.Update(entity);
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
                    _context.TB_AREA_GESTORA_CPTM.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
