using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CubicoWMSBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using CubicoWMSBackend.DTO;
using CubicoWMSBackend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CubicoWMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                var validateExistence = await _usuarioService.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "¡ El usuario " + usuario.NombreUsuario + " ya existe!" });
                }
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);

                await _usuarioService.SaveUser(usuario);
                return Ok(new { message = "¡Usuario registrado con éxito!" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

        // /api/Usuario/CambiarPassword
        [Route("CambiarPassword")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPasswordDTO)
        {
            try
            {
                var identity=HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);
                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPasswordDTO.passwordAnterior);
                var usuario = await _usuarioService.ValidatePassword(idUsuario, passwordEncriptado);
                if (usuario == null)
                {
                    return BadRequest(new { message = "¡Contraseña incorrecta!" });
                }
                usuario.Password = Encriptar.EncriptarPassword(cambiarPasswordDTO.nuevaPassword);
                await _usuarioService.UpdatePassword(usuario);
                return  Ok(new { message = "¡La contraseña fue actualizado con éxito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("RECUPERAR_PASSWORD")]
       /// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETRecuperarContraseña(String COD_USUARIO)
        {
            try
            {
                {
                    //var identity = HttpContext.User.Identity as ClaimsIdentity;
                    //int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var user = await _usuarioService.RecuperarPassword(COD_USUARIO);
                    return Ok(user);
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("VALIDAR_NUEVOUSUARIO_LOGIN")]
        /// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETValidar_NuevoUsuario(String COD_USUARIO,string NOM_USUARIO)
        {
            try
            {
                {
                    //var identity = HttpContext.User.Identity as ClaimsIdentity;
                    //int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var MENSAJE = await _usuarioService.Valida_NuevoUsuario(COD_USUARIO,NOM_USUARIO);
                    return Ok(MENSAJE);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("GRABAR_NUEVOUSUARIO_LOGIN")]
        /// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GETGrabar_Usuario_Login(string cod_personal, string nombre_usuario, string email, string cod_usuario, int cod_sede)
        {
            try
            {
                {
                    //var identity = HttpContext.User.Identity as ClaimsIdentity;
                    //int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                    var MENSAJE = await _usuarioService.Grabar_Usuario_Login(cod_personal, nombre_usuario, email, cod_usuario, cod_sede);
                    return Ok(MENSAJE);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
