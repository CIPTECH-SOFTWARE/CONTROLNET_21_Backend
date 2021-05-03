using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class TipoPersonalService:ITipoPersonalService
    {
        private readonly ITipoPersonalRepository _TipoPersonalRepository;
        public TipoPersonalService(ITipoPersonalRepository TipoPersonalRepository)
        {
            _TipoPersonalRepository = TipoPersonalRepository;
        }

        public async Task<List<TipoPersonalDTO>> ListarTipoPersonal()
        {
            return await _TipoPersonalRepository.ListarTipoPersonal();
        }

        public async  Task<List<TipoPersonalDTO>> ListarTipoPersonal_X_filtro(string filtro)
        {
            return await _TipoPersonalRepository.ListarTipoPersonal_X_filtro(filtro);
        }

        public async Task<MensajeResultado> MantenimientoTipoPersonal(TipoPersonalMantenimientoDTO TIPO_PERSONAL)
        {
            return await _TipoPersonalRepository.MantenimientoTipoPersonal( TIPO_PERSONAL);
        
        }
    }
}
