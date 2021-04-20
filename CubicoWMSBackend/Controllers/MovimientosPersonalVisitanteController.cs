using ControlNetBackend.Domain.IService;
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
    public class MovimientosPersonalVisitanteController : ControllerBase
    {

        private readonly IMovimientosPersonalVisitanteService _MovimientosPersonalVisitanteService;

        public MovimientosPersonalVisitanteController(IMovimientosPersonalVisitanteService SedeService)
        {
            _MovimientosPersonalVisitanteService = SedeService;
        }

        [HttpGet]
        [Route("LISTAR_INGRESO_SEDE_DHAS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarIngresoSede_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaIngresoSede = await _MovimientosPersonalVisitanteService.ListarIngresoSede_DHAS(TIPO,COD_EMPRESA,COD_SEDE);
                    return Ok(listaIngresoSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("LISTAR_INGRESO_SEDE_TOP_DHAS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarIngresoSede_TOP_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaIngresoSede = await _MovimientosPersonalVisitanteService.ListarIngresoSede_Top_DHAS(TIPO, COD_EMPRESA, COD_SEDE);
                    return Ok(listaIngresoSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("CANTIDAD_INGRESO_SEDE_DHAS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETTotalIngresoSede_DHAS(string FECHA_INICIO,string FECHA_FIN,int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var CantidadIngresoSede = await _MovimientosPersonalVisitanteService.TotalCantidades_Movimiento_DHAS(FECHA_INICIO,FECHA_FIN,TIPO, COD_EMPRESA, COD_SEDE);
                    return Ok(CantidadIngresoSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("TOTAL_VISITANTE_EXCESO_TIEMPO_DHAS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETTotalVisitanteExcesoTiempo_DHAS(int COD_EMPRESA, int COD_SEDE)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var CantidadVisitantes = await _MovimientosPersonalVisitanteService.Total_Visitante_Tiempo_Exceso_DHAS(COD_EMPRESA, COD_SEDE);
                    return Ok(CantidadVisitantes);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("LISTAR_VISITAS_TIEMPO_EXCESO_DHAS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarVisitanteTiempoEscesoSede_DHAS(int COD_EMPRESA, int COD_SEDE)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaVisitaExcesoTiempoSede = await _MovimientosPersonalVisitanteService.ListarVisitasTiempoExceso_DHAS( COD_EMPRESA, COD_SEDE);
                    return Ok(listaVisitaExcesoTiempoSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("LISTAR_INGRESO_VISITA_GRAFICA_DHAS")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarIngresoVisitaGrafica_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaIngresoVisitaGrafica = await _MovimientosPersonalVisitanteService.ListarVisitasTiempoExceso_DHAS(COD_EMPRESA, COD_SEDE);
                    return Ok(listaIngresoVisitaGrafica);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
