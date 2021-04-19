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
    public class SedeController : ControllerBase
    {
        private readonly ISedeService _SedeService;

        public SedeController(ISedeService SedeService)
        {
           _SedeService = SedeService;
        }

        [HttpGet]
        [Route("LISTA_SEDE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaSede(int COD_EMPRESA)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaSede = await _SedeService.ListarSede_x_Empresa(COD_EMPRESA);
                    return Ok(listaSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("LISTA_USUARIO_SEDE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GET(int ID_USER)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaUsuarioSede = await _SedeService.ListarUsuarioSede(ID_USER);
                return Ok(listaUsuarioSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("LISTA_USUARIO_SEDE_ACTIVO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GET_ListaUsuarioSedeActivo(int ID_USER)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaUsuarioSede = await _SedeService.ListarUsuarioSede_activo(ID_USER);
                    return Ok(listaUsuarioSede);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


      
    }
}
