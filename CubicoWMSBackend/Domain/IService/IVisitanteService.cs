using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlNetBackend.Domain.IService
{
   public interface IVisitanteService
    {
      
        Task<List<VisitanteDTO>> ListarVisitante(string filtro);
        Task<List<VisitanteDTO>> ListarVisitante_X_Codigo(int cod_visitante);
        Task<MensajeResultado> MantenimientoVisitante(VisitanteMantenimientoDTO VISITANTE);




    }
}
