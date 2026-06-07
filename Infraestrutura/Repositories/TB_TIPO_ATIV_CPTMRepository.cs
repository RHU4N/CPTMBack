using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_TIPO_ATIV_CPTMRepository : ITB_TIPO_ATIV_CPTMRepository
    {
        private readonly ConnectContext _context;

        public TB_TIPO_ATIV_CPTMRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_TIPO_ATIV_CPTM entity)
        {
            _context.TB_TIPO_ATIV_CPTM.Add(entity);
            _context.SaveChanges();
        }

        public TB_TIPO_ATIV_CPTM? Get(int id)
        {
            return _context.TB_TIPO_ATIV_CPTM.FirstOrDefault(x => x.idTipoAtivCptm == id);
        }

        public IEnumerable<TB_TIPO_ATIV_CPTM> GetAll()
        {
            return _context.TB_TIPO_ATIV_CPTM.ToList();
        }

        public bool Update(TB_TIPO_ATIV_CPTM entity)
        {
            try
            {
                _context.TB_TIPO_ATIV_CPTM.Update(entity);
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
                    _context.TB_TIPO_ATIV_CPTM.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
