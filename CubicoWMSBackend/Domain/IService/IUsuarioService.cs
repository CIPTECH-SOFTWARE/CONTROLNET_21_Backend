using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlNetBackend.Domain.Models;

namespace CubicoWMSBackend.Domain.IService

{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);
        Task UpdatePassword(Usuario usuario);

        Task<UsuarioDTO> RecuperarPassword(string COD_USUARIO);
        Task<MensajeResultado> Valida_NuevoUsuario(string COD_USUARIO, string NOM_USUARIO);
    }
}
