using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IService
{
   public interface IEmpresaService
    {
        IEnumerable<UsuarioEmpresaDTO> ListarUsuarioEmpresa(int ID_USER);

    }
}
