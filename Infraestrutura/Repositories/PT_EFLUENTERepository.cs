using CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class PT_EFLUENTERepository : IPT_EFLUENTERepository
    {
        private readonly ConnectContext _context;

        public PT_EFLUENTERepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(PT_EFLUENTE entity)
        {
            _context.PT_EFLUENTE.Add(entity);
            _context.SaveChanges();
        }

        public PT_EFLUENTE? Get(string id)
        {
            return _context.PT_EFLUENTE.FirstOrDefault(x => x.pkCdMeioAmbienteCptm == id);
        }

        public IEnumerable<PT_EFLUENTE> GetAll()
        {
            return _context.PT_EFLUENTE.ToList();
        }

        public bool Update(PT_EFLUENTE entity)
        {
            try
            {
                // Detach any tracked instance with the same PK to avoid EF Core tracking conflict
                var tracked = _context.ChangeTracker.Entries<PT_EFLUENTE>()
                    .FirstOrDefault(e => e.Entity.pkCdMeioAmbienteCptm == entity.pkCdMeioAmbienteCptm);
                if (tracked != null)
                    tracked.State = Microsoft.EntityFrameworkCore.EntityState.Detached;

                _context.PT_EFLUENTE.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var entity = Get(id);
                if (entity != null)
                {
                    _context.PT_EFLUENTE.Remove(entity);
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
