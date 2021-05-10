using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
   public interface ITipoDocumentoService
    {
        Task<List<TipoDocumentoDTO>> ListarTipoDocumento();

        Task<MensajeResultado> MantenimientoTipoDocumento(TipoDocumentoMantenimientoDTO TIPO_DOCUMENTO);

    }
}
