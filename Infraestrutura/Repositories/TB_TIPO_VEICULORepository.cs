using CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate;

namespace CPTMBack.Infraestrutura.Repositories
{
    public class TB_TIPO_VEICULORepository : ITB_TIPO_VEICULORepository
    {
        private readonly ConnectContext _context;

        public TB_TIPO_VEICULORepository(ConnectContext context)
        {
            _context = context;
        }

        public void Add(TB_TIPO_VEICULO entity)
        {
            _context.TB_TIPO_VEICULO.Add(entity);
            _context.SaveChanges();
        }

        public TB_TIPO_VEICULO? Get(int id)
        {
            return _context.TB_TIPO_VEICULO.FirstOrDefault(x => x.idTipoVeiculo == id);
        }

        public IEnumerable<TB_TIPO_VEICULO> GetAll()
        {
            return _context.TB_TIPO_VEICULO.ToList();
        }

        public bool Update(TB_TIPO_VEICULO entity)
        {
            try
            {
                _context.TB_TIPO_VEICULO.Update(entity);
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
                    _context.TB_TIPO_VEICULO.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch { return false; }
        }
    }
}
