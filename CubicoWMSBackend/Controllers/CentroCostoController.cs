using ControlNetBackend.Domain.IService;
using ControlNetBackend.DTO;
using CubicoWMSBackend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ControlNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroCostoController : ControllerBase
    {
        private readonly ICentroCostoService _CentroCostoService;

        public CentroCostoController(ICentroCostoService CentroCostoService)
        {
            _CentroCostoService = CentroCostoService;
        }

        [HttpGet]
        [Route("LISTA_CENTROCOSTO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarEmpresaGET()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var listaCentroCosto = await _CentroCostoService.ListarCentroCosto();
                return Ok(listaCentroCosto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("LISTA_CENTROCOSTO_EMPRESA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaCentroCosto_Empresa(int COD_EMPRESA)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var listaCentroCostoEmpresa = await _CentroCostoService.ListarCentroCosto_x_Empresa(COD_EMPRESA);
                return Ok(listaCentroCostoEmpresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("MANTENIMIENTO_CENTROCOSTO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoEmpresa([FromBody] CentroCostoMantenimientoDTO CENTRO_COSTO)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _CentroCostoService.MantenimientoCentroCosto(CENTRO_COSTO);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
