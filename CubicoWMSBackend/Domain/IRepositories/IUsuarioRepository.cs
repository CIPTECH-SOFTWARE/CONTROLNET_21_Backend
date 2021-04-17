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
    }
}
