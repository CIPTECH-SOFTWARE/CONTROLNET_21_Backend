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


namespace ControlNetBackend.Service
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccesosPermisoController : ControllerBase
    {

        private readonly IAccesosPermisoService _AccesosPermisoService;

        public AccesosPermisoController(IAccesosPermisoService AccesosPermisoService)
        {
            _AccesosPermisoService = AccesosPermisoService;
        }


        [HttpPost]
        [Route("MANTENIMIENTO_USUARIO_CENTRO_COSTO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoMailing(Usuario_CentroCostoDTO USUARIO)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var mensaje = await _AccesosPermisoService.MantenimientoUsuario_CentroCosto(USUARIO);
                    return Ok(mensaje);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        [Route("MANTENIMIENTO_USUARIO_TIPO_PERSONAL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoMailing(Usuario_TipoPersonalDTO USUARIO)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var mensaje = await _AccesosPermisoService.MantenimientoUsuario_TipoPersonal(USUARIO);
                    return Ok(mensaje);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
