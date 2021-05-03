using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class VisitanteNoDeseadoService:IVisitanteNoDeseadoService
    {
        private readonly IVisitanteNoDeseadoRepository _VisitanteNoDeseadoRepository;
        public VisitanteNoDeseadoService(IVisitanteNoDeseadoRepository VisitanteNoDeseadoRepository)
        {
            _VisitanteNoDeseadoRepository = VisitanteNoDeseadoRepository;
        }

        public async Task<List<VisitanteDTO>> ListarVisitanteNoDeseado()
        {
            return await _VisitanteNoDeseadoRepository.ListarVisitanteNoDeseado();
        }

        public async Task<MensajeResultado> MantenimientoVisitanteNoDeseado(VisitanteMantenimientoDTO visitanteMantenimientoDTO)
        {
            return await _VisitanteNoDeseadoRepository.MantenimientoVisitanteNoDeseado(visitanteMantenimientoDTO);
        }
    }
}
