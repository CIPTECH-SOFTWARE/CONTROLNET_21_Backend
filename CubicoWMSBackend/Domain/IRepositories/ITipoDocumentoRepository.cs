using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface ITipoDocumentoRepository
    {
        Task<List<TipoDocumentoDTO>> ListarTipoDocumento();

        Task<MensajeResultado> MantenimientoTipoDocumento(TipoDocumentoMantenimientoDTO TIPO_DOCUMENTO);


    }
}
