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
    public class TarjetaAccesoController : ControllerBase
    {
        private readonly ITarjetaAccesoService _TarjetaAccesoService;
        public TarjetaAccesoController(ITarjetaAccesoService TarjetaAccesoService)
        {
            _TarjetaAccesoService = TarjetaAccesoService;
        }
         

        [HttpGet]
        [Route("LISTA_TARJETA_ACCESO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTarjetaAccesoGET()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TarjetaAccesoService.ListarTarjetaAcceso();
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("LISTA_TARJETA_ACCESO_FILTRO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTarjetaAcceso_filtroGET(string filtro,int cod_grupo_acceso)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TarjetaAccesoService.ListarTarjetaAcceso_Filtro(filtro,cod_grupo_acceso);
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("LISTA_TARJETA_ACCESO_GA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTarjetaAcceso_GAGET(int cod_empresa,int cod_grupo_acceso)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TarjetaAccesoService.ListarTarjetaAcceso_GA(cod_empresa,cod_grupo_acceso);
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("LISTA_TARJETA_ACCESO_EMPRESA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListarTarjetaAcceso_GAGET(int cod_empresa)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var LISTA = await _TarjetaAccesoService.ListarTarjetaAcceso_X_Empresa(cod_empresa);
                return Ok(LISTA);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        [Route("MANTENIMIENTO_TARJETA_ACCESO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoTarjetaAcceso([FromBody] TarjetaAccesoMantenimientoDTO TARJETA)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var mensaje = await _TarjetaAccesoService.MantenimientTarjetaAcceso(TARJETA);
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
