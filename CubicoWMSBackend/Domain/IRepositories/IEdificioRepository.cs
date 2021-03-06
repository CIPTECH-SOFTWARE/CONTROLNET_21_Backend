using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface IEdificioRepository
    {
        Task<List<EdificioDTO>> ListarEdificio();
        Task<List<EdificioDTO>> ListarEdificio_X_Sede(int cod_sede);
        Task<MensajeResultado> MantenimientoEdificio(EdificioMantenimientoDTO EDIFICIO);





    }
}
