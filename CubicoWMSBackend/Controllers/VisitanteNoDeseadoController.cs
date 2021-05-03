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
    public class VisitanteNoDeseadoController : ControllerBase
    {
        private readonly IVisitanteNoDeseadoService _VisitanteNoDeseadoService;

        public VisitanteNoDeseadoController(IVisitanteNoDeseadoService VisitanteNoDeseadoService)
        {
            _VisitanteNoDeseadoService = VisitanteNoDeseadoService;
        }

        [HttpGet]
        [Route("LISTA_VISITANTE_NO_DESEADO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarVisitanteNoDeseadoGET()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _VisitanteNoDeseadoService.ListarVisitanteNoDeseado();
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("MANTENIMIENTO_VISITANTE_NO_DESEADO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoTarjetaAcceso([FromBody] VisitanteMantenimientoDTO VISITANTE)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _VisitanteNoDeseadoService.MantenimientoVisitanteNoDeseado(VISITANTE);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
