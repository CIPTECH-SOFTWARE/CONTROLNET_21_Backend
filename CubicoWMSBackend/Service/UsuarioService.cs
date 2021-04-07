using CubicoWMSBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.IService;
using CubicoWMSBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Service
{
    public class UsuarioService:IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
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


    }
}
