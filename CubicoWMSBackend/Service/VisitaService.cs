using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;

namespace ControlNetBackend.Service
{
    public class VisitaService
    {
        private readonly IVisitaRepository _VisitaRepository;
        public VisitaService(IVisitaRepository VisitaRepository)
        {
            _VisitaRepository = VisitaRepository;
        }
        public async Task<List<VisitaDiaDTO>> ListarCitasProgramadasDia(string COD_PERSONAL, string FECHA)
        {
            return await _VisitaRepository.ListarVisitasDia(COD_PERSONAL, FECHA);
        }



    }
}
