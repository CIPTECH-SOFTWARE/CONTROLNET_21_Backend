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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _EmpresaService;

        public EmpresaController(IEmpresaService EmpresaService)
        {
            _EmpresaService = EmpresaService;
        }


        [HttpGet]
        [Route("LISTA_USUARIO_EMPRESA")]
        public async Task<IActionResult> GET(int ID_USER)
        {
            try
            {

                var listaUsuarioEmpresa = await _EmpresaService.ListarUsuarioEmpresa(ID_USER);
                return Ok(listaUsuarioEmpresa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
