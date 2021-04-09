using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IRepositories
{
   public interface ISedeRepository
    {
        IEnumerable<UsuarioSedeDTO> ListarUsuarioSede(int ID_USER);

    }
}
