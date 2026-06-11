using CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class RT_EFLUENTERepository : IRT_EFLUENTERepository
    {
        private readonly ConnectContext _context;

        public RT_EFLUENTERepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(RT_EFLUENTE entity)
        {
            _context.RT_EFLUENTE.Add(entity);
            _context.SaveChanges();
        }

        public RT_EFLUENTE? Get(int id)
        {
            return _context.RT_EFLUENTE.FirstOrDefault(x => x.attachmentId == id);
        }

        public IEnumerable<RT_EFLUENTE> GetAll()
        {
            return _context.RT_EFLUENTE.ToList();
        }

        public IEnumerable<RT_EFLUENTE> GetByRelObjectId(string relObjectId)
        {
            return _context.RT_EFLUENTE.Where(x => x.relObjectId == relObjectId).ToList();
        }

        public bool Update(RT_EFLUENTE entity)
        {
            try
            {
                _context.RT_EFLUENTE.Update(entity);
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
                    _context.RT_EFLUENTE.Remove(entity);
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

        public int GetNextId()
        {
            var all = _context.RT_EFLUENTE.ToList();
            return all.Any() ? all.Max(a => a.attachmentId) + 1 : 1;
        }
    }
}
