using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IService
{
    public interface ISedeService
    {
        Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER);

    }
}
