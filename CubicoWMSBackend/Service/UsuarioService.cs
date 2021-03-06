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
        public async Task<MensajeResultado> Grabar_Usuario_Login(string cod_personal, string nombre_usuario, string email, string cod_usuario, int cod_sede)
        {     
        return await _usuarioRepository.Grabar_Usuario_Login(cod_personal,nombre_usuario,email,cod_usuario,cod_sede);
        }



              
        public async Task<List<UsuarioDTO>> ListarUsuario()
        {
            return await _usuarioRepository.ListarUsuario();
        }

        public async Task<List<UsuarioDTO>> ListarUsuario_x_perfil(int ID_PERFIL)
        {
            return await _usuarioRepository.ListarUsuario_x_perfil(ID_PERFIL);
        }

        public async Task<List<UsuarioDTO>> ListarUsuario_Codigo_filtro(string COD_USUARIO)
        {
            return await _usuarioRepository.ListarUsuario_Codigo_filtro(COD_USUARIO);
        }

        public async Task<MensajeResultado> Cambio_PasswordUsuario(Usuario_PasswordDTO USUARIO)
        {
            return await _usuarioRepository.Cambio_PasswordUsuario(USUARIO);
        }

        public async Task<MensajeResultado> Grabar_Usuario(UsuarioMantenimientoDTO USUARIO)
        {
            return await _usuarioRepository.Grabar_Usuario(USUARIO);
        }

        public async Task<MensajeResultado> Grabar_UsuarioEmpresa(Usuario_EmpresaDTO USUARIO_EMPRESA)
        {
            return await _usuarioRepository.Grabar_UsuarioEmpresa(USUARIO_EMPRESA);
        }



    }
}
