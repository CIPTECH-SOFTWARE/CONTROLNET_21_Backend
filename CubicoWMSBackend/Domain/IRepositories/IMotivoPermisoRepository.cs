using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface IMotivoPermisoRepository
    {

        Task<List<Motivo_PermisoDTO>> ListarPermisos();

    }
}
