using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface ITipoVisitanteRepository
    {
        Task<List<TipoVisitanteDTO>> ListarTipoVisitante();
        Task<MensajeResultado> MantenimientoTipoVisitante(TipoVisitanteMantenimientoDTO TIPO_VISITANTE);





    }
}
