using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_TIPO_DESTINACAORepository : ITB_TIPO_DESTINACAORepository
    {
        private readonly ConnectContext _context;

        public TB_TIPO_DESTINACAORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_TIPO_DESTINACAO entity)
        {
            _context.TB_TIPO_DESTINACAO.Add(entity);
            _context.SaveChanges();
        }

        public TB_TIPO_DESTINACAO? Get(int id)
        {
            return _context.TB_TIPO_DESTINACAO.FirstOrDefault(x => x.idTipoDestinacao == id);
        }

        public IEnumerable<TB_TIPO_DESTINACAO> GetAll()
        {
            return _context.TB_TIPO_DESTINACAO.ToList();
        }

        public bool Update(TB_TIPO_DESTINACAO entity)
        {
            try
            {
                _context.TB_TIPO_DESTINACAO.Update(entity);
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
                    _context.TB_TIPO_DESTINACAO.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
