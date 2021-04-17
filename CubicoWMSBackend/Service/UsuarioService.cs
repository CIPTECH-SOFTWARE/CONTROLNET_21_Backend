using CubicoWMSBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;

namespace CubicoWMSBackend.Service
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO> RecuperarPassword(string COD_USUARIO)
        {
            return await _usuarioRepository.RecuperarPassword(COD_USUARIO);
        }

        public async Task SaveUser(Usuario usuario)
        {
            await _usuarioRepository.SaveUser(usuario);
        }
             

        public async Task UpdatePassword(Usuario usuario)
        {
            await _usuarioRepository.UpdatePassword(usuario);
        }

       

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            return await _usuarioRepository.ValidateExistence(usuario);
        }

       
        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            return await _usuarioRepository.ValidatePassword(idUsuario, passwordAnterior);

        }

        public async Task<MensajeResultado> Valida_NuevoUsuario(string COD_USUARIO, string NOM_USUARIO)
        {
            return await _usuarioRepository.Valida_NuevoUsuario(COD_USUARIO,NOM_USUARIO);
        }

    }
}
