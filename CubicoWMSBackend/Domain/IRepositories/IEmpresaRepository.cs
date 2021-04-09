using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IRepositories
{
   public  interface IEmpresaRepository
    {
        IEnumerable<UsuarioEmpresaDTO> ListarUsuarioEmpresa(int ID_USER);
    }
}
