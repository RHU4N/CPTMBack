using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;
using CPTMBack.Infraestrutura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DominioController : ControllerBase
    {
        private readonly ConnectContext _context;
        private readonly ILogger<DominioController> _logger;

        public DominioController(ConnectContext context, ILogger<DominioController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // =========================================================
        // GETs públicos (consulta de domínios para formulários)
        // =========================================================

        [HttpGet("municipios")]
        public async Task<IActionResult> GetMunicipios()
        {
            var lista = await _context.TB_MUNICIPIO.AsNoTracking().OrderBy(x => x.dsMunicipio)
                .Select(x => new DominioItemDTO { id = x.idMunicipio, descricao = x.dsMunicipio }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("linhas")]
        public async Task<IActionResult> GetLinhas()
        {
            var lista = await _context.TB_LINHA_CPTM.AsNoTracking().OrderBy(x => x.dsLinha)
                .Select(x => new DominioItemDTO { id = x.idLinha, descricao = x.dsLinha }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("status-registro")]
        public async Task<IActionResult> GetStatusRegistro()
        {
            var lista = await _context.TB_STATUS_REGISTRO.AsNoTracking().OrderBy(x => x.dsStatus)
                .Select(x => new DominioItemDTO { id = x.idStatus, descricao = x.dsStatus }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("status-desvio")]
        public async Task<IActionResult> GetStatusDesvio()
        {
            var lista = await _context.TB_STATUS_DESVIO_AMBIENTAL.AsNoTracking().OrderBy(x => x.dsStatus)
                .Select(x => new DominioItemDTO { id = x.idStatus, descricao = x.dsStatus }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var lista = await _context.TB_DEPTO_MEIO_AMBIENTE.AsNoTracking().OrderBy(x => x.dsDepto)
                .Select(x => new DominioItemDTO { id = x.idDepto, descricao = x.dsDepto }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("vias")]
        public async Task<IActionResult> GetVias()
        {
            var lista = await _context.TB_VIA_CPTM.AsNoTracking().OrderBy(x => x.dsVia)
                .Select(x => new DominioItemDTO { id = x.idVia, descricao = x.dsVia }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("trechos")]
        public async Task<IActionResult> GetTrechos()
        {
            var lista = await _context.TB_TRECHO_SENTIDO.AsNoTracking().OrderBy(x => x.dsTrecho)
                .Select(x => new DominioItemDTO { id = x.idTrecho, descricao = x.dsTrecho }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("perfis")]
        public async Task<IActionResult> GetPerfis()
        {
            var lista = await _context.TB_PERFIL_USUARIO.AsNoTracking().OrderBy(x => x.dsPerfil)
                .Select(x => new DominioItemDTO { id = x.idPerfil, descricao = x.dsPerfil }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("estacoes")]
        public async Task<IActionResult> GetEstacoes()
        {
            var lista = await _context.TB_ESTACAO_CPTM.AsNoTracking().OrderBy(x => x.dsEstacao)
                .Select(x => new DominioItemDTO { id = x.idEstacao, descricao = x.dsEstacao }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("naturezas-pga")]
        public async Task<IActionResult> GetNaturezasPga()
        {
            var lista = await _context.TB_NATUREZA_PGA.AsNoTracking().OrderBy(x => x.dsNatureza)
                .Select(x => new DominioItemDTO { id = x.idNatureza, descricao = x.dsNatureza }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("areas-gestoras")]
        public async Task<IActionResult> GetAreasGestoras()
        {
            var lista = await _context.TB_AREA_GESTORA_CPTM.AsNoTracking().OrderBy(x => x.dsAreaGestora)
                .Select(x => new DominioItemDTO { id = x.idAreaGestora, descricao = x.dsAreaGestora }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("proprietarios")]
        public async Task<IActionResult> GetProprietarios()
        {
            var lista = await _context.TB_PROPRIETARIO.AsNoTracking().OrderBy(x => x.dsProprietario)
                .Select(x => new DominioItemDTO { id = x.idProprietario, descricao = x.dsProprietario }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("sim-nao")]
        public async Task<IActionResult> GetSimNao()
        {
            var lista = await _context.TB_SIM_NAO.AsNoTracking().OrderBy(x => x.dsSimNao)
                .Select(x => new DominioItemDTO { id = x.idSimNao, descricao = x.dsSimNao }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-atividade")]
        public async Task<IActionResult> GetTiposAtividade()
        {
            var lista = await _context.TB_TIPO_ATIVIDADE.AsNoTracking().OrderBy(x => x.dsTipoAtividade)
                .Select(x => new DominioItemDTO { id = x.idTipoAtividade, descricao = x.dsTipoAtividade }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-dra")]
        public async Task<IActionResult> GetTiposDra()
        {
            var lista = await _context.TB_TIPO_DRA.AsNoTracking().OrderBy(x => x.dsTipoDra)
                .Select(x => new DominioItemDTO { id = x.idTipoDra, descricao = x.dsTipoDra }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-ativ-cptm")]
        public async Task<IActionResult> GetTiposAtivCptm()
        {
            var lista = await _context.TB_TIPO_ATIV_CPTM.AsNoTracking().OrderBy(x => x.dsTipoAtivCptm)
                .Select(x => new DominioItemDTO { id = x.idTipoAtivCptm, descricao = x.dsTipoAtivCptm }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("locais-atividade")]
        public async Task<IActionResult> GetLocaisAtividade()
        {
            var lista = await _context.TB_LOCAL_ATIVIDADE.AsNoTracking().OrderBy(x => x.dsLocalAtividade)
                .Select(x => new DominioItemDTO { id = x.idLocalAtividade, descricao = x.dsLocalAtividade }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("origens-efluente")]
        public async Task<IActionResult> GetOrigensEfluente()
        {
            var lista = await _context.TB_ORIGEM_EFLUENTE.AsNoTracking().OrderBy(x => x.dsOrigemEfluente)
                .Select(x => new DominioItemDTO { id = x.idOrigemEfluente, descricao = x.dsOrigemEfluente }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("fontes-geradoras")]
        public async Task<IActionResult> GetFontesGeradoras()
        {
            var lista = await _context.TB_FONTE_GERADORA.AsNoTracking().OrderBy(x => x.dsFonteGeradora)
                .Select(x => new DominioItemDTO { id = x.idFonteGeradora, descricao = x.dsFonteGeradora }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-destinacao")]
        public async Task<IActionResult> GetTiposDestinacao()
        {
            var lista = await _context.TB_TIPO_DESTINACAO.AsNoTracking().OrderBy(x => x.dsTipoDestinacao)
                .Select(x => new DominioItemDTO { id = x.idTipoDestinacao, descricao = x.dsTipoDestinacao }).ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-veiculo")]
        public async Task<IActionResult> GetTiposVeiculo()
        {
            var lista = await _context.TB_TIPO_VEICULO.AsNoTracking().OrderBy(x => x.dsTipoVeiculo)
                .Select(x => new DominioItemDTO { id = x.idTipoVeiculo, descricao = x.dsTipoVeiculo }).ToListAsync();
            return Ok(lista);
        }

        // =========================================================
        // ADMIN: POST /api/dominio/{tipo}  — Criar item
        // =========================================================

        [HttpPost("{tipo}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(string tipo, [FromBody] DominioItemCreateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto?.descricao))
                return BadRequest(new { mensagem = "Descrição é obrigatória" });

            var desc = dto.descricao.Trim();

            try
            {
                return tipo.ToLower() switch
                {
                    "municipios" => await CriarDominio(_context.TB_MUNICIPIO, x => x.idMunicipio, x => x.dsMunicipio, (id, d) => new TB_MUNICIPIO(id, d), desc),
                    "linhas" => await CriarDominio(_context.TB_LINHA_CPTM, x => x.idLinha, x => x.dsLinha, (id, d) => new TB_LINHA_CPTM(id, d), desc),
                    "vias" => await CriarDominio(_context.TB_VIA_CPTM, x => x.idVia, x => x.dsVia, (id, d) => new TB_VIA_CPTM(id, d), desc),
                    "trechos" => await CriarDominio(_context.TB_TRECHO_SENTIDO, x => x.idTrecho, x => x.dsTrecho, (id, d) => new TB_TRECHO_SENTIDO(id, d), desc),
                    "estacoes" => await CriarDominio(_context.TB_ESTACAO_CPTM, x => x.idEstacao, x => x.dsEstacao, (id, d) => new TB_ESTACAO_CPTM(id, d), desc),
                    "departamentos" => await CriarDominio(_context.TB_DEPTO_MEIO_AMBIENTE, x => x.idDepto, x => x.dsDepto, (id, d) => new TB_DEPTO_MEIO_AMBIENTE(id, d), desc),
                    "status-registro" => await CriarDominio(_context.TB_STATUS_REGISTRO, x => x.idStatus, x => x.dsStatus, (id, d) => new TB_STATUS_REGISTRO(id, d), desc),
                    "status-desvio" => await CriarDominio(_context.TB_STATUS_DESVIO_AMBIENTAL, x => x.idStatus, x => x.dsStatus, (id, d) => new TB_STATUS_DESVIO_AMBIENTAL(id, d), desc),
                    "naturezas-pga" => await CriarDominio(_context.TB_NATUREZA_PGA, x => x.idNatureza, x => x.dsNatureza, (id, d) => new TB_NATUREZA_PGA(id, d), desc),
                    "areas-gestoras" => await CriarDominio(_context.TB_AREA_GESTORA_CPTM, x => x.idAreaGestora, x => x.dsAreaGestora, (id, d) => new TB_AREA_GESTORA_CPTM(id, d), desc),
                    "proprietarios" => await CriarDominio(_context.TB_PROPRIETARIO, x => x.idProprietario, x => x.dsProprietario, (id, d) => new TB_PROPRIETARIO(id, d), desc),
                    "sim-nao" => await CriarDominio(_context.TB_SIM_NAO, x => x.idSimNao, x => x.dsSimNao, (id, d) => new TB_SIM_NAO(id, d), desc),
                    "tipos-atividade" => await CriarDominio(_context.TB_TIPO_ATIVIDADE, x => x.idTipoAtividade, x => x.dsTipoAtividade, (id, d) => new TB_TIPO_ATIVIDADE(id, d), desc),
                    "tipos-dra" => await CriarDominio(_context.TB_TIPO_DRA, x => x.idTipoDra, x => x.dsTipoDra, (id, d) => new TB_TIPO_DRA(id, d), desc),
                    "tipos-ativ-cptm" => await CriarDominio(_context.TB_TIPO_ATIV_CPTM, x => x.idTipoAtivCptm, x => x.dsTipoAtivCptm, (id, d) => new TB_TIPO_ATIV_CPTM(id, d), desc),
                    "locais-atividade" => await CriarDominio(_context.TB_LOCAL_ATIVIDADE, x => x.idLocalAtividade, x => x.dsLocalAtividade, (id, d) => new TB_LOCAL_ATIVIDADE(id, d), desc),
                    "origens-efluente" => await CriarDominio(_context.TB_ORIGEM_EFLUENTE, x => x.idOrigemEfluente, x => x.dsOrigemEfluente, (id, d) => new TB_ORIGEM_EFLUENTE(id, d), desc),
                    "fontes-geradoras" => await CriarDominio(_context.TB_FONTE_GERADORA, x => x.idFonteGeradora, x => x.dsFonteGeradora, (id, d) => new TB_FONTE_GERADORA(id, d), desc),
                    "tipos-destinacao" => await CriarDominio(_context.TB_TIPO_DESTINACAO, x => x.idTipoDestinacao, x => x.dsTipoDestinacao, (id, d) => new TB_TIPO_DESTINACAO(id, d), desc),
                    "tipos-veiculo" => await CriarDominio(_context.TB_TIPO_VEICULO, x => x.idTipoVeiculo, x => x.dsTipoVeiculo, (id, d) => new TB_TIPO_VEICULO(id, d), desc),
                    _ => NotFound(new { mensagem = "Tipo de domínio não encontrado" })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar item de domínio {Tipo}", tipo);
                return StatusCode(500, new { mensagem = "Não foi possível criar o item de domínio. Tente novamente." });
            }
        }

        // =========================================================
        // ADMIN: PUT /api/dominio/{tipo}/{id}  — Atualizar item
        // =========================================================

        [HttpPut("{tipo}/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(string tipo, int id, [FromBody] DominioItemCreateDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto?.descricao))
                return BadRequest(new { mensagem = "Descrição é obrigatória" });

            var desc = dto.descricao.Trim();

            try
            {
                return tipo.ToLower() switch
                {
                    "municipios" => await AtualizarDominio(_context.TB_MUNICIPIO, id, x => x.idMunicipio, x => x.dsMunicipio, (i, d) => new TB_MUNICIPIO(i, d), desc),
                    "linhas" => await AtualizarDominio(_context.TB_LINHA_CPTM, id, x => x.idLinha, x => x.dsLinha, (i, d) => new TB_LINHA_CPTM(i, d), desc),
                    "vias" => await AtualizarDominio(_context.TB_VIA_CPTM, id, x => x.idVia, x => x.dsVia, (i, d) => new TB_VIA_CPTM(i, d), desc),
                    "trechos" => await AtualizarDominio(_context.TB_TRECHO_SENTIDO, id, x => x.idTrecho, x => x.dsTrecho, (i, d) => new TB_TRECHO_SENTIDO(i, d), desc),
                    "estacoes" => await AtualizarDominio(_context.TB_ESTACAO_CPTM, id, x => x.idEstacao, x => x.dsEstacao, (i, d) => new TB_ESTACAO_CPTM(i, d), desc),
                    "departamentos" => await AtualizarDominio(_context.TB_DEPTO_MEIO_AMBIENTE, id, x => x.idDepto, x => x.dsDepto, (i, d) => new TB_DEPTO_MEIO_AMBIENTE(i, d), desc),
                    "status-registro" => await AtualizarDominio(_context.TB_STATUS_REGISTRO, id, x => x.idStatus, x => x.dsStatus, (i, d) => new TB_STATUS_REGISTRO(i, d), desc),
                    "status-desvio" => await AtualizarDominio(_context.TB_STATUS_DESVIO_AMBIENTAL, id, x => x.idStatus, x => x.dsStatus, (i, d) => new TB_STATUS_DESVIO_AMBIENTAL(i, d), desc),
                    "naturezas-pga" => await AtualizarDominio(_context.TB_NATUREZA_PGA, id, x => x.idNatureza, x => x.dsNatureza, (i, d) => new TB_NATUREZA_PGA(i, d), desc),
                    "areas-gestoras" => await AtualizarDominio(_context.TB_AREA_GESTORA_CPTM, id, x => x.idAreaGestora, x => x.dsAreaGestora, (i, d) => new TB_AREA_GESTORA_CPTM(i, d), desc),
                    "proprietarios" => await AtualizarDominio(_context.TB_PROPRIETARIO, id, x => x.idProprietario, x => x.dsProprietario, (i, d) => new TB_PROPRIETARIO(i, d), desc),
                    "sim-nao" => await AtualizarDominio(_context.TB_SIM_NAO, id, x => x.idSimNao, x => x.dsSimNao, (i, d) => new TB_SIM_NAO(i, d), desc),
                    "tipos-atividade" => await AtualizarDominio(_context.TB_TIPO_ATIVIDADE, id, x => x.idTipoAtividade, x => x.dsTipoAtividade, (i, d) => new TB_TIPO_ATIVIDADE(i, d), desc),
                    "tipos-dra" => await AtualizarDominio(_context.TB_TIPO_DRA, id, x => x.idTipoDra, x => x.dsTipoDra, (i, d) => new TB_TIPO_DRA(i, d), desc),
                    "tipos-ativ-cptm" => await AtualizarDominio(_context.TB_TIPO_ATIV_CPTM, id, x => x.idTipoAtivCptm, x => x.dsTipoAtivCptm, (i, d) => new TB_TIPO_ATIV_CPTM(i, d), desc),
                    "locais-atividade" => await AtualizarDominio(_context.TB_LOCAL_ATIVIDADE, id, x => x.idLocalAtividade, x => x.dsLocalAtividade, (i, d) => new TB_LOCAL_ATIVIDADE(i, d), desc),
                    "origens-efluente" => await AtualizarDominio(_context.TB_ORIGEM_EFLUENTE, id, x => x.idOrigemEfluente, x => x.dsOrigemEfluente, (i, d) => new TB_ORIGEM_EFLUENTE(i, d), desc),
                    "fontes-geradoras" => await AtualizarDominio(_context.TB_FONTE_GERADORA, id, x => x.idFonteGeradora, x => x.dsFonteGeradora, (i, d) => new TB_FONTE_GERADORA(i, d), desc),
                    "tipos-destinacao" => await AtualizarDominio(_context.TB_TIPO_DESTINACAO, id, x => x.idTipoDestinacao, x => x.dsTipoDestinacao, (i, d) => new TB_TIPO_DESTINACAO(i, d), desc),
                    "tipos-veiculo" => await AtualizarDominio(_context.TB_TIPO_VEICULO, id, x => x.idTipoVeiculo, x => x.dsTipoVeiculo, (i, d) => new TB_TIPO_VEICULO(i, d), desc),
                    _ => NotFound(new { mensagem = "Tipo de domínio não encontrado" })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar item de domínio {Tipo}/{Id}", tipo, id);
                return StatusCode(500, new { mensagem = "Não foi possível atualizar o item de domínio. Tente novamente." });
            }
        }

        // =========================================================
        // ADMIN: DELETE /api/dominio/{tipo}/{id}  — Excluir item
        // =========================================================

        [HttpDelete("{tipo}/{id:int}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string tipo, int id)
        {
            try
            {
                return tipo.ToLower() switch
                {
                    "municipios" => await ExcluirDominio(_context.TB_MUNICIPIO, id, x => x.idMunicipio),
                    "linhas" => await ExcluirDominio(_context.TB_LINHA_CPTM, id, x => x.idLinha),
                    "vias" => await ExcluirDominio(_context.TB_VIA_CPTM, id, x => x.idVia),
                    "trechos" => await ExcluirDominio(_context.TB_TRECHO_SENTIDO, id, x => x.idTrecho),
                    "estacoes" => await ExcluirDominio(_context.TB_ESTACAO_CPTM, id, x => x.idEstacao),
                    "departamentos" => await ExcluirDominio(_context.TB_DEPTO_MEIO_AMBIENTE, id, x => x.idDepto),
                    "status-registro" => await ExcluirDominio(_context.TB_STATUS_REGISTRO, id, x => x.idStatus),
                    "status-desvio" => await ExcluirDominio(_context.TB_STATUS_DESVIO_AMBIENTAL, id, x => x.idStatus),
                    "naturezas-pga" => await ExcluirDominio(_context.TB_NATUREZA_PGA, id, x => x.idNatureza),
                    "areas-gestoras" => await ExcluirDominio(_context.TB_AREA_GESTORA_CPTM, id, x => x.idAreaGestora),
                    "proprietarios" => await ExcluirDominio(_context.TB_PROPRIETARIO, id, x => x.idProprietario),
                    "sim-nao" => await ExcluirDominio(_context.TB_SIM_NAO, id, x => x.idSimNao),
                    "tipos-atividade" => await ExcluirDominio(_context.TB_TIPO_ATIVIDADE, id, x => x.idTipoAtividade),
                    "tipos-dra" => await ExcluirDominio(_context.TB_TIPO_DRA, id, x => x.idTipoDra),
                    "tipos-ativ-cptm" => await ExcluirDominio(_context.TB_TIPO_ATIV_CPTM, id, x => x.idTipoAtivCptm),
                    "locais-atividade" => await ExcluirDominio(_context.TB_LOCAL_ATIVIDADE, id, x => x.idLocalAtividade),
                    "origens-efluente" => await ExcluirDominio(_context.TB_ORIGEM_EFLUENTE, id, x => x.idOrigemEfluente),
                    "fontes-geradoras" => await ExcluirDominio(_context.TB_FONTE_GERADORA, id, x => x.idFonteGeradora),
                    "tipos-destinacao" => await ExcluirDominio(_context.TB_TIPO_DESTINACAO, id, x => x.idTipoDestinacao),
                    "tipos-veiculo" => await ExcluirDominio(_context.TB_TIPO_VEICULO, id, x => x.idTipoVeiculo),
                    _ => NotFound(new { mensagem = "Tipo de domínio não encontrado" })
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir item de domínio {Tipo}/{Id}", tipo, id);
                return StatusCode(500, new { mensagem = "Não foi possível excluir o item de domínio. Tente novamente." });
            }
        }

        // =========================================================
        // Helpers genéricos
        // =========================================================

        private async Task<IActionResult> CriarDominio<T>(
            DbSet<T> dbSet,
            Func<T, int> getId,
            Func<T, string> getDesc,
            Func<int, string, T> factory,
            string descricao) where T : class
        {
            var all = await dbSet.AsNoTracking().ToListAsync();

            if (all.Any(x => getDesc(x).Equals(descricao, StringComparison.OrdinalIgnoreCase)))
                return Conflict(new { mensagem = "Já existe um item com essa descrição" });

            var nextId = all.Any() ? all.Max(getId) + 1 : 1;
            var entity = factory(nextId, descricao);
            dbSet.Add(entity);
            await _context.SaveChangesAsync();

            return StatusCode(201, new { sucesso = true, dados = new DominioItemDTO { id = nextId, descricao = descricao } });
        }

        private async Task<IActionResult> AtualizarDominio<T>(
            DbSet<T> dbSet,
            int id,
            Func<T, int> getId,
            Func<T, string> getDesc,
            Func<int, string, T> factory,
            string descricao) where T : class
        {
            var all = await dbSet.AsNoTracking().ToListAsync();

            if (!all.Any(x => getId(x) == id))
                return NotFound(new { mensagem = "Registro não encontrado" });

            if (all.Any(x => getId(x) != id && getDesc(x).Equals(descricao, StringComparison.OrdinalIgnoreCase)))
                return Conflict(new { mensagem = "Já existe outro item com essa descrição" });

            var entity = factory(id, descricao);
            dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return Ok(new { sucesso = true, dados = new DominioItemDTO { id = id, descricao = descricao } });
        }

        private async Task<IActionResult> ExcluirDominio<T>(
            DbSet<T> dbSet,
            int id,
            Func<T, int> getId) where T : class
        {
            var all = await dbSet.AsNoTracking().ToListAsync();
            var entity = all.FirstOrDefault(x => getId(x) == id);

            if (entity == null)
                return NotFound(new { mensagem = "Registro não encontrado" });

            dbSet.Attach(entity);
            dbSet.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok(new { sucesso = true, mensagem = "Registro excluído com sucesso" });
        }
    }
}
