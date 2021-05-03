using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
   public interface IVisitanteNoDeseadoService
    {
        Task<List<VisitanteDTO>> ListarVisitanteNoDeseado();
        Task<MensajeResultado> MantenimientoVisitanteNoDeseado(VisitanteMantenimientoDTO visitanteMantenimientoDTO);

    }
}
