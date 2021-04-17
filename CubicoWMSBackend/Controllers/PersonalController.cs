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





    }
}
