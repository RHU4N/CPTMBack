using CPTMBack.Domain.DTOs;
using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;
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
                .Select(x => new DominioItemDTO
                {
                    id = x.idMunicipio,
                    descricao = x.dsMunicipio
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("linhas")]
        public async Task<IActionResult> GetLinhas()
        {
            var lista = await _context.TB_LINHA_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsLinha)
                .Select(x => new DominioItemDTO
                {
                    id = x.idLinha,
                    descricao = x.dsLinha
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("status-registro")]
        public async Task<IActionResult> GetStatusRegistro()
        {
            var lista = await _context.TB_STATUS_REGISTRO
                .AsNoTracking()
                .OrderBy(x => x.dsStatus)
                .Select(x => new DominioItemDTO
                {
                    id = x.idStatus,
                    descricao = x.dsStatus
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("status-desvio")]
        public async Task<IActionResult> GetStatusDesvio()
        {
            var lista = await _context.TB_STATUS_DESVIO_AMBIENTAL
                .AsNoTracking()
                .OrderBy(x => x.dsStatus)
                .Select(x => new DominioItemDTO
                {
                    id = x.idStatus,
                    descricao = x.dsStatus
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("tipos-efluente")]
        public async Task<IActionResult> GetTiposEfluente()
        {
            var lista = await _context.TB_TIPO_EFLUENTE
                .AsNoTracking()
                .OrderBy(x => x.dsTipoEfluente)
                .Select(x => new DominioItemDTO
                {
                    id = x.idTipoEfluente,
                    descricao = x.dsTipoEfluente
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var lista = await _context.TB_DEPTO_MEIO_AMBIENTE
                .AsNoTracking()
                .OrderBy(x => x.dsDepto)
                .Select(x => new DominioItemDTO
                {
                    id = x.idDepto,
                    descricao = x.dsDepto
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("vias")]
        public async Task<IActionResult> GetVias()
        {
            var lista = await _context.TB_VIA_CPTM
                .AsNoTracking()
                .OrderBy(x => x.dsVia)
                .Select(x => new DominioItemDTO
                {
                    id = x.idVia,
                    descricao = x.dsVia
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("trechos")]
        public async Task<IActionResult> GetTrechos()
        {
            var lista = await _context.TB_TRECHO_SENTIDO
                .AsNoTracking()
                .OrderBy(x => x.dsTrecho)
                .Select(x => new DominioItemDTO
                {
                    id = x.idTrecho,
                    descricao = x.dsTrecho
                })
                .ToListAsync();

            return Ok(lista);
        }

        [HttpGet("perfis")]
        public async Task<IActionResult> GetPerfis()
        {
            var lista = await _context.TB_PERFIL_USUARIO
                .AsNoTracking()
                .OrderBy(x => x.dsPerfil)
                .Select(x => new DominioItemDTO
                {
                    id = x.idPerfil,
                    descricao = x.dsPerfil
                })
                .ToListAsync();

            return Ok(lista);
        }
    }
}
