using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CubicoWMSBackend.Domain.IService;
using CubicoWMSBackend.Domain.Models;
using CubicoWMSBackend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CubicoWMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration config)
        {
            _config = config;
            _loginService = loginService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {

            try
            {
               // usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);

                if (user == null)
                {
                   return BadRequest(new { message = "Usuario o contraseña invalido" });
                }
                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { token = tokenString });

               // return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
