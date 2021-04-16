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
    public class ConfiguracionParametrosController : ControllerBase
    {
        private readonly IConfiguracionParametrosService _ConfiguracionParametrosService;

        public ConfiguracionParametrosController(IConfiguracionParametrosService ConfiguracionParametrosService)
        {
            _ConfiguracionParametrosService = ConfiguracionParametrosService;
        }


        [HttpGet]
        [Route("PARAMETROS_EMAIL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETParametrosEmail()
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var ParametrosEmail = await _ConfiguracionParametrosService.ParametrosConfiguracionEmail();
                    return Ok(ParametrosEmail);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }








    }
}
