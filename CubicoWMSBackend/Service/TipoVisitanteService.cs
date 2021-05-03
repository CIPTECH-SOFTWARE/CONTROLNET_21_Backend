using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class TipoVisitanteService:ITipoVisitanteService
    {
        private readonly ITipoVisitanteRepository _TipoVisitanteRepository;
        public TipoVisitanteService(ITipoVisitanteRepository TipoVisitanteRepository)
        {
            _TipoVisitanteRepository = TipoVisitanteRepository;
        }

        public async Task<List<TipoVisitanteDTO>> ListarTipoVisitante()
        {
            return await _TipoVisitanteRepository.ListarTipoVisitante();
        }

        public async Task<MensajeResultado> MantenimientoTipoVisitante(TipoVisitanteMantenimientoDTO TIPO_VISITANTE)
        {
            return await _TipoVisitanteRepository.MantenimientoTipoVisitante( TIPO_VISITANTE);
        }
    }
}
