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
    public class GrupoAccesosController : ControllerBase
    {
        private readonly IGrupoAccesosService _GrupoAccesosService;

        public GrupoAccesosController(IGrupoAccesosService GrupoAccesosService)
        {
            _GrupoAccesosService = GrupoAccesosService;
        }

        [HttpGet]
        [Route("LISTA_GRUPO_ACCESOS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaGrupoAccesos()
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaGrupoAccesos = await _GrupoAccesosService.ListarGrupoAccesos();
                    return Ok(ListaGrupoAccesos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        [Route("LISTA_GRUPO_ACCESOS_EMPRESA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaGrupoAccesosEmpresa(int COD_EMPRESA)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaGrupoAccesos = await _GrupoAccesosService.ListarGrupoAccesosEmpresa(COD_EMPRESA);
                    return Ok(ListaGrupoAccesos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("MANTENIMIENTO_GRUPO_ACCESOS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoEdificio([FromBody] MantenimientoGrupoAccesosDTO GRUPO)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _GrupoAccesosService.MantenimientoGrupoAccesos(GRUPO);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
