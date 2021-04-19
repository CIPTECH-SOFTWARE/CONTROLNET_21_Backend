using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Domain.IService
{
   public interface IEmpresaService
    {
        Task<List<EmpresaDTO>> ListarEmpresa();
        Task<List<EmpresaDTO>> ListarEmpresa_activa(int COD_EMPRESA);
        Task<List<UsuarioEmpresaDTO>> ListarUsuarioEmpresa(int ID_USER);
        
    }
}
