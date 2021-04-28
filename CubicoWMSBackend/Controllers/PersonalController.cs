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
    public class PersonalController : ControllerBase
    {

        private readonly IPersonalService _PersonalService;

        public PersonalController(IPersonalService PersonalService)
        {
            _PersonalService = PersonalService;
        }


        [HttpGet]
        [Route("PERSONAL_LOGIN")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETPersonalLogin(string COD_PERSONAL)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var personal = await _PersonalService.Personal_login(COD_PERSONAL);
                    return Ok(personal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("LISTAR_PERSONAL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetListarPersonal()
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var personal = await _PersonalService.ListarPersonal();
                    return Ok(personal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        [Route("LISTA_PERSONAL_CC")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETPersonalLogin(int CENTRO_COSTO)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var Listapersonal = await _PersonalService.ListarPersonal_CentroCosto(CENTRO_COSTO);
                    return Ok(Listapersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpGet]
        [Route("LISTAR_PERSONAL_CODIGO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarPersonalCodigo(string COD_PERSONAL)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var personal = await _PersonalService.ListarPersonal_Codigo(COD_PERSONAL);
                    return Ok(personal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }




        [HttpGet]
        [Route("LISTAR_PERSONAL_CODIGO_LOGIN")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarPersonaCodigolLogin(string COD_PERSONAL)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaPersonal = await _PersonalService.ListarPersonal_Codigo_login(COD_PERSONAL);
                    return Ok(ListaPersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet]
        [Route("LISTA_PERSONAL_EMPRESA")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarPersonalEmpresa(int COD_EMPRESA)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaPersonal = await _PersonalService.ListarPersonal_Empresa(COD_EMPRESA);
                    return Ok(ListaPersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet]
        [Route("LISTA_PERSONAL_EMPRESA_FILTRO")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListarPersonalEmpresaFiltro(int COD_EMPRESA,int ID_USER)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaPersonal = await _PersonalService.ListarPersonal_Empresa_filtro(COD_EMPRESA,ID_USER);
                    return Ok(ListaPersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet]
        [Route("LISTA_PERSONAL_EMPRESA_TREE")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaPersonalEmpresaTree(int COD_EMPRESA)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaPersonal = await _PersonalService.ListarPersonal_Empresa_tree(COD_EMPRESA);
                    return Ok(ListaPersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet]
        [Route("LISTAR_PERSONAL_GAP")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETListaPersonalGAP(int COD_GAP)
        {
            try                                                    
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ListaPersonal = await _PersonalService.ListarPersonal_GAP(COD_GAP);
                    return Ok(ListaPersonal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("MANTENIMIENTO_PERSONAL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> POST_MantenimientoPersonal(PersonalMantenimientoDTO PERSONAL)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var Personal = await _PersonalService.MantenimientoPersonal(PERSONAL);
                    return Ok(Personal);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
