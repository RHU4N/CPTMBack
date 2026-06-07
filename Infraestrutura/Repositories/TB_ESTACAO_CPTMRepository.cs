using CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_ESTACAO_CPTMRepository : ITB_ESTACAO_CPTMRepository
    {
        private readonly ConnectContext _context;

        public TB_ESTACAO_CPTMRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_ESTACAO_CPTM entity)
        {
            _context.TB_ESTACAO_CPTM.Add(entity);
            _context.SaveChanges();
        }

        public TB_ESTACAO_CPTM? Get(int id)
        {
            return _context.TB_ESTACAO_CPTM.FirstOrDefault(x => x.idEstacao == id);
        }

        public IEnumerable<TB_ESTACAO_CPTM> GetAll()
        {
            return _context.TB_ESTACAO_CPTM.ToList();
        }

        public bool Update(TB_ESTACAO_CPTM entity)
        {
            try
            {
                _context.TB_ESTACAO_CPTM.Update(entity);
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
                    _context.TB_ESTACAO_CPTM.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
