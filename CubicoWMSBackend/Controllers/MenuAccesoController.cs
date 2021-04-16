using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using CubicoWMSBackend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ControlNetBackend.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace ControlNetBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuAccesoController : ControllerBase
    {
        private readonly IMenuAccesoService _MenuAccesoService;

        public MenuAccesoController(IMenuAccesoService MenuAccesoService)
        {
            _MenuAccesoService = MenuAccesoService;
        }



        [HttpGet]
        [Route("LISTA_MENU_ACCESO_PERFIL")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GET(int ID_PERFIL)
        {
            try
            {
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var listaMenuAccesoPerfil = await _MenuAccesoService.ListarMenuAccesoPerfil(ID_PERFIL);
                    return Ok(listaMenuAccesoPerfil);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
