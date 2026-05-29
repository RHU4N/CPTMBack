using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_LINHA_CPTMRepository : ITB_LINHA_CPTMRepository
    {
        private readonly ConnectContext _context;

        public TB_LINHA_CPTMRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_LINHA_CPTM entity)
        {
            _context.TB_LINHA_CPTM.Add(entity);
            _context.SaveChanges();
        }

        public TB_LINHA_CPTM? Get(int id)
        {
            return _context.TB_LINHA_CPTM.FirstOrDefault(x => x.idLinha == id);
        }

        public IEnumerable<TB_LINHA_CPTM> GetAll()
        {
            return _context.TB_LINHA_CPTM.ToList();
        }

        public bool Update(TB_LINHA_CPTM entity)
        {
            try
            {
                _context.TB_LINHA_CPTM.Update(entity);
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
                    _context.TB_LINHA_CPTM.Remove(entity);
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
