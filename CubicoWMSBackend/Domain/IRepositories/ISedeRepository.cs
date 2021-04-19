using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Domain.IRepositories
{
    public interface ISedeRepository
    {
        Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER);
        Task<List<UsuarioSedeDTO>> ListarUsuarioSede_activo(int ID_USER);
        Task<List<SedeDTO>> ListarSede_x_Empresa(int COD_EMPRESA);

    }
}
