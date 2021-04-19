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



    public class CitaController : ControllerBase
    {

        private readonly ICitaService _CitaService;

        public CitaController(ICitaService CitaService)
        {
            _CitaService = CitaService;
        }

        [HttpGet]
        [Route("LISTA_CITA_PROGRAMADA_DIA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaSede(string COD_PERSONAL,string FECHA)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaCitaProgramadaDia = await _CitaService.ListarCitasProgramadasDia(COD_PERSONAL,FECHA);
                    return Ok(listaCitaProgramadaDia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
