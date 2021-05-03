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
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilService _PerfilService;

        public PerfilController(IPerfilService PerfilService)
        {
            _PerfilService = PerfilService;
        } 


        [HttpGet]
        [Route("LISTA_PERFIL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarPisoGET()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _PerfilService.ListarPerfil();
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         

        [HttpPost]
        [Route("MANTENIMIENTO_PERFIL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoEdificio([FromBody] PerfilMantenimientoDTO PERFIL)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _PerfilService.MantenimientoPerfil(PERFIL);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






    }
}
