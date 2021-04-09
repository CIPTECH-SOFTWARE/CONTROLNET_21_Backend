using CubicoWMSBackend.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintLabelController : ControllerBase
    {

        [HttpGet]
        public PrintLabelDTO Get()
        {
            PrintLabelDTO printLabelDTO = new PrintLabelDTO();
            printLabelDTO.labelName = "etq";
            printLabelDTO.printerName = "Zebra";
            //
            List<EtiquetaDTO> etiquetaDTOs = new List<EtiquetaDTO>();

            etiquetaDTOs.Add(new EtiquetaDTO() { campo = "abc", valor = "100" });
            etiquetaDTOs.Add(new EtiquetaDTO() { campo = "abc", valor = "100" });
            etiquetaDTOs.Add(new EtiquetaDTO() { campo = "abc", valor = "100" });
            etiquetaDTOs.Add(new EtiquetaDTO() { campo = "abc", valor = "100" });

            printLabelDTO.label = etiquetaDTOs;




            return printLabelDTO;

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PrintLabelDTO printLabelDTO)
        {
            try
            {
                //var validateExistence = await _usuarioService.ValidateExistence(usuario);
                //if (validateExistence)
                //{
                //    return BadRequest(new { message = "¡ El usuario " + usuario.NombreUsuario + " ya existe!" });
                //}
                //usuario.Password = Encriptar.EncriptarPassword(usuario.Password);

                //await _usuarioService.SaveUser(usuario);
                return Ok(new { errNumber=0,
                                mensaje = "¡Usuario registrado con éxito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
