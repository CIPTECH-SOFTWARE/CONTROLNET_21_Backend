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
    public class VisitaController : ControllerBase
    {
        private readonly IVisitaService _VisitaService;

        public VisitaController(IVisitaService VisitaService)
        {
            _VisitaService = VisitaService;
        }

        [HttpGet]
        [Route("LISTA_VISITAS_DIA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaVisitasDia(string COD_PERSONAL, string FECHA)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaVisitasDia = await _VisitaService.ListarVisitasDia(COD_PERSONAL, FECHA);
                    return Ok(listaVisitasDia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




    }
}
