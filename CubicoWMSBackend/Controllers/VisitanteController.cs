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
    public class VisitanteController : ControllerBase
    {
        private readonly IVisitanteService _VisitanteService;

        public VisitanteController(IVisitanteService VisitanteService)
        {
            _VisitanteService = VisitanteService;
        }


        [HttpGet]
        [Route("LISTA_VISITANTE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTarjetaAccesoGET(string filtro)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _VisitanteService.ListarVisitante(filtro);
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("LISTA_VISITANTE_CODIGO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarVisitanteCodigoGET(int cod_visitante)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _VisitanteService.ListarVisitante_X_Codigo(cod_visitante);
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        [HttpPost]
        [Route("MANTENIMIENTO_VISITANTE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoTarjetaAcceso([FromBody] VisitanteMantenimientoDTO VISITANTE)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _VisitanteService.MantenimientoVisitante(VISITANTE);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
