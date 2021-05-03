using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class VisitanteService:IVisitanteService
    {
        private readonly IVisitanteRepository _VisitanteRepository;
        public VisitanteService(IVisitanteRepository VisitanteRepository)
        {
            _VisitanteRepository = VisitanteRepository;
        }

      

        public async Task<List<VisitanteDTO>> ListarVisitante(string filtro)
        {
            return await _VisitanteRepository.ListarVisitante(filtro);
        }

        public async Task<List<VisitanteDTO>> ListarVisitante_X_Codigo(int cod_visitante)
        {
            return await _VisitanteRepository.ListarVisitante_X_Codigo(cod_visitante);
        }

        public async Task<MensajeResultado> MantenimientoVisitante(VisitanteMantenimientoDTO VISITANTE)
        {
            return await _VisitanteRepository.MantenimientoVisitante(VISITANTE);
        }
    }
}
