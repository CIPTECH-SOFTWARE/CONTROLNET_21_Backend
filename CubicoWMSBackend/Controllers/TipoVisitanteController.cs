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
    public class TipoVisitanteController : ControllerBase
    {
        private readonly ITipoVisitanteService _TipoVisitanteService;

        public TipoVisitanteController(ITipoVisitanteService TipoVisitanteService)
        {
            _TipoVisitanteService = TipoVisitanteService;
        }

        [HttpGet]
        [Route("LISTA_TIPO_VISITANTE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTarjetaAccesoGET()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TipoVisitanteService.ListarTipoVisitante();
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("MANTENIMIENTO_TIPO_VISITANTE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoTipoVisitante([FromBody] TipoVisitanteMantenimientoDTO TIPO)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _TipoVisitanteService.MantenimientoTipoVisitante(TIPO);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
