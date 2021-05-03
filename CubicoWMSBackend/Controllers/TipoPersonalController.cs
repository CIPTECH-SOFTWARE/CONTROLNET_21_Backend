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
    public class TipoPersonalController : ControllerBase
    {
        private readonly ITipoPersonalService _TipoPersonalService;

        public TipoPersonalController(ITipoPersonalService TipoPersonalService)
        {
            _TipoPersonalService = TipoPersonalService;
        }


        [HttpGet]
        [Route("LISTA_TIPO_PERSONAL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTipoPersonalGET()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TipoPersonalService.ListarTipoPersonal();
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("LISTA_TIPO_PERSONAL_FILTRO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTipoPersonal_FiltroGET(string filtro)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TipoPersonalService.ListarTipoPersonal_X_filtro(filtro);
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("MANTENIMIENTO_TIPO_PERSONAL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoTipoPersonal([FromBody] TipoPersonalMantenimientoDTO TIPO)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _TipoPersonalService.MantenimientoTipoPersonal(TIPO);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
