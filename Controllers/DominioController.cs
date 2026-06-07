using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate;
using CPTMBack.Infraestrutura;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPTMBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DominioController : ControllerBase
    {
        private readonly ConnectContext _context;

        public DominioController(ConnectContext context)
        {
            _context = context;
        }

        [HttpGet("municipios")]
        public async Task<IActionResult> GetMunicipios()
        {
            var lista = await _context.TB_MUNICIPIO
                .AsNoTracking()
                .OrderBy(x => x.dsMunicipio)
                .Select(x => new DominioItemDTO { id = x.idMunicipio, descricao = x.dsMunicipio })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("linhas")]
        public async Task<IActionResult> GetLinhas()
        {
            var lista = await _context.TB_LINHA_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsLinha)
                .Select(x => new DominioItemDTO { id = x.idLinha, descricao = x.dsLinha })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("status-registro")]
        public async Task<IActionResult> GetStatusRegistro()
        {
            var lista = await _context.TB_STATUS_REGISTRO
                .AsNoTracking()
                .OrderBy(x => x.dsStatus)
                .Select(x => new DominioItemDTO { id = x.idStatus, descricao = x.dsStatus })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("status-desvio")]
        public async Task<IActionResult> GetStatusDesvio()
        {
            var lista = await _context.TB_STATUS_DESVIO_AMBIENTAL
                .AsNoTracking()
                .OrderBy(x => x.dsStatus)
                .Select(x => new DominioItemDTO { id = x.idStatus, descricao = x.dsStatus })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var lista = await _context.TB_DEPTO_MEIO_AMBIENTE
                .AsNoTracking()
                .OrderBy(x => x.dsDepto)
                .Select(x => new DominioItemDTO { id = x.idDepto, descricao = x.dsDepto })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("vias")]
        public async Task<IActionResult> GetVias()
        {
            var lista = await _context.TB_VIA_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsVia)
                .Select(x => new DominioItemDTO { id = x.idVia, descricao = x.dsVia })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("trechos")]
        public async Task<IActionResult> GetTrechos()
        {
            var lista = await _context.TB_TRECHO_SENTIDO
                .AsNoTracking()
                .OrderBy(x => x.dsTrecho)
                .Select(x => new DominioItemDTO { id = x.idTrecho, descricao = x.dsTrecho })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("perfis")]
        public async Task<IActionResult> GetPerfis()
        {
            var lista = await _context.TB_PERFIL_USUARIO
                .AsNoTracking()
                .OrderBy(x => x.dsPerfil)
                .Select(x => new DominioItemDTO { id = x.idPerfil, descricao = x.dsPerfil })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("estacoes")]
        public async Task<IActionResult> GetEstacoes()
        {
            var lista = await _context.TB_ESTACAO_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsEstacao)
                .Select(x => new DominioItemDTO { id = x.idEstacao, descricao = x.dsEstacao })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("naturezas-pga")]
        public async Task<IActionResult> GetNaturezasPga()
        {
            var lista = await _context.TB_NATUREZA_PGA
                .AsNoTracking()
                .OrderBy(x => x.dsNatureza)
                .Select(x => new DominioItemDTO { id = x.idNatureza, descricao = x.dsNatureza })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("areas-gestoras")]
        public async Task<IActionResult> GetAreasGestoras()
        {
            var lista = await _context.TB_AREA_GESTORA_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsAreaGestora)
                .Select(x => new DominioItemDTO { id = x.idAreaGestora, descricao = x.dsAreaGestora })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("proprietarios")]
        public async Task<IActionResult> GetProprietarios()
        {
            var lista = await _context.TB_PROPRIETARIO
                .AsNoTracking()
                .OrderBy(x => x.dsProprietario)
                .Select(x => new DominioItemDTO { id = x.idProprietario, descricao = x.dsProprietario })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("sim-nao")]
        public async Task<IActionResult> GetSimNao()
        {
            var lista = await _context.TB_SIM_NAO
                .AsNoTracking()
                .OrderBy(x => x.dsSimNao)
                .Select(x => new DominioItemDTO { id = x.idSimNao, descricao = x.dsSimNao })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-atividade")]
        public async Task<IActionResult> GetTiposAtividade()
        {
            var lista = await _context.TB_TIPO_ATIVIDADE
                .AsNoTracking()
                .OrderBy(x => x.dsTipoAtividade)
                .Select(x => new DominioItemDTO { id = x.idTipoAtividade, descricao = x.dsTipoAtividade })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-dra")]
        public async Task<IActionResult> GetTiposDra()
        {
            var lista = await _context.TB_TIPO_DRA
                .AsNoTracking()
                .OrderBy(x => x.dsTipoDra)
                .Select(x => new DominioItemDTO { id = x.idTipoDra, descricao = x.dsTipoDra })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-ativ-cptm")]
        public async Task<IActionResult> GetTiposAtivCptm()
        {
            var lista = await _context.TB_TIPO_ATIV_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsTipoAtivCptm)
                .Select(x => new DominioItemDTO { id = x.idTipoAtivCptm, descricao = x.dsTipoAtivCptm })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("locais-atividade")]
        public async Task<IActionResult> GetLocaisAtividade()
        {
            var lista = await _context.TB_LOCAL_ATIVIDADE
                .AsNoTracking()
                .OrderBy(x => x.dsLocalAtividade)
                .Select(x => new DominioItemDTO { id = x.idLocalAtividade, descricao = x.dsLocalAtividade })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("origens-efluente")]
        public async Task<IActionResult> GetOrigensEfluente()
        {
            var lista = await _context.TB_ORIGEM_EFLUENTE
                .AsNoTracking()
                .OrderBy(x => x.dsOrigemEfluente)
                .Select(x => new DominioItemDTO { id = x.idOrigemEfluente, descricao = x.dsOrigemEfluente })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("fontes-geradoras")]
        public async Task<IActionResult> GetFontesGeradoras()
        {
            var lista = await _context.TB_FONTE_GERADORA
                .AsNoTracking()
                .OrderBy(x => x.dsFonteGeradora)
                .Select(x => new DominioItemDTO { id = x.idFonteGeradora, descricao = x.dsFonteGeradora })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-destinacao")]
        public async Task<IActionResult> GetTiposDestinacao()
        {
            var lista = await _context.TB_TIPO_DESTINACAO
                .AsNoTracking()
                .OrderBy(x => x.dsTipoDestinacao)
                .Select(x => new DominioItemDTO { id = x.idTipoDestinacao, descricao = x.dsTipoDestinacao })
                .ToListAsync();
            return Ok(lista);
        }

        [HttpGet("tipos-veiculo")]
        public async Task<IActionResult> GetTiposVeiculo()
        {
            var lista = await _context.TB_TIPO_VEICULO
                .AsNoTracking()
                .OrderBy(x => x.dsTipoVeiculo)
                .Select(x => new DominioItemDTO { id = x.idTipoVeiculo, descricao = x.dsTipoVeiculo })
                .ToListAsync();
            return Ok(lista);
        }
    }
}
