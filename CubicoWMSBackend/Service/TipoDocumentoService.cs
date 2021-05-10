using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class TipoDocumentoService : ITipoDocumentoService
    {

        private readonly ITipoDocumentoRepository _TipoDocumentoRepository;
        public TipoDocumentoService(ITipoDocumentoRepository TipoDocumentoRepository)
        {
            _TipoDocumentoRepository = TipoDocumentoRepository;
        }

        public async  Task<List<TipoDocumentoDTO>> ListarTipoDocumento()
        {
            return await _TipoDocumentoRepository.ListarTipoDocumento();
        }

        public async Task<MensajeResultado> MantenimientoTipoDocumento(TipoDocumentoMantenimientoDTO TIPO_DOCUMENTO)
        {
            return await _TipoDocumentoRepository.MantenimientoTipoDocumento(TIPO_DOCUMENTO);
        }
    }
}
