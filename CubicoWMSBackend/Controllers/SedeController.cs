using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using CubicoWMSBackend.Domain.Models;
using CubicoWMSBackend.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ControlNetBackend.DTO;
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
        [Route("LISTA_USUARIO_SEDE")]
        public async Task<IActionResult> GET(int ID_USER)
        {
            try
            {

                var listaUsuarioSede = await _SedeService.ListarUsuarioSede(ID_USER);
                return Ok(listaUsuarioSede);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
