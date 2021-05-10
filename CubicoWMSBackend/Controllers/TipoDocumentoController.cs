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
    public class TipoDocumentoController : ControllerBase
    {

        private readonly ITipoDocumentoService _TipoDocumentoService;

        public TipoDocumentoController(ITipoDocumentoService TipoDocumentoService)
        {
            _TipoDocumentoService = TipoDocumentoService;
        }

        [HttpGet]
        [Route("LISTAR_TIPO_DOCUMENTO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListarPersonal()
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var tipoDocumento = await _TipoDocumentoService.ListarTipoDocumento();
                    return Ok(tipoDocumento);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("MANTENIMIENTO_TIPO_DOCUMENTO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoPersonal(TipoDocumentoMantenimientoDTO TIPO_DOCUMENTO)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var mensaje = await _TipoDocumentoService.MantenimientoTipoDocumento(TIPO_DOCUMENTO);
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
