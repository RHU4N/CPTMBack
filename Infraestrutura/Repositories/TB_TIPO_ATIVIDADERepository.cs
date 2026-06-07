using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_TIPO_ATIVIDADERepository : ITB_TIPO_ATIVIDADERepository
    {
        private readonly ConnectContext _context;

        public TB_TIPO_ATIVIDADERepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_TIPO_ATIVIDADE entity)
        {
            _context.TB_TIPO_ATIVIDADE.Add(entity);
            _context.SaveChanges();
        }

        public TB_TIPO_ATIVIDADE? Get(int id)
        {
            return _context.TB_TIPO_ATIVIDADE.FirstOrDefault(x => x.idTipoAtividade == id);
        }

        public IEnumerable<TB_TIPO_ATIVIDADE> GetAll()
        {
            return _context.TB_TIPO_ATIVIDADE.ToList();
        }

        public bool Update(TB_TIPO_ATIVIDADE entity)
        {
            try
            {
                _context.TB_TIPO_ATIVIDADE.Update(entity);
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
                    _context.TB_TIPO_ATIVIDADE.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
