using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
  public   interface ITipoPersonalService
    {
        Task<List<TipoPersonalDTO>> ListarTipoPersonal();
        Task<List<TipoPersonalDTO>> ListarTipoPersonal_X_filtro(string FILTRO);
        Task<MensajeResultado> MantenimientoTipoPersonal(TipoPersonalMantenimientoDTO TIPO_PERSONAL);

    }
}
