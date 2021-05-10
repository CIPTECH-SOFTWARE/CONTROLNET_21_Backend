using ControlNetBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace CubicoWMSBackend.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);

        Task UpdatePassword(Usuario usuario);

        Task<UsuarioDTO> RecuperarPassword(string COD_USUARIO);

        Task<MensajeResultado> Valida_NuevoUsuario(string COD_USUARIO,string NOM_USUARIO);
        Task<MensajeResultado> Grabar_Usuario_Login(string cod_personal, string nombre_usuario, string email, string cod_usuario, int cod_sede);



        Task<List<UsuarioDTO>> ListarUsuario();
        Task<List<UsuarioDTO>> ListarUsuario_x_perfil(int ID_PERFIL);
        Task<List<UsuarioDTO>> ListarUsuario_Codigo_filtro(string COD_USUARIO);
        Task<MensajeResultado> Cambio_PasswordUsuario(Usuario_PasswordDTO USUARIO);
        Task<MensajeResultado> Grabar_Usuario(UsuarioMantenimientoDTO USUARIO);
        Task<MensajeResultado> Grabar_UsuarioEmpresa(Usuario_EmpresaDTO USUARIO_EMPRESA);


        








    }
}
