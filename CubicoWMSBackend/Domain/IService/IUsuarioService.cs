using CubicoWMSBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Domain.IService
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior);

        Task UpdatePassword(Usuario usuario);
    }
}
