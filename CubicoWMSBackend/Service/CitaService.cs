using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;

namespace ControlNetBackend.Service
{
    public class CitaService : ICitaService
    {

        private readonly ICitaRepository _CitaRepository;
        public CitaService(ICitaRepository CitaRepository)
        {
            _CitaRepository = CitaRepository;
        }

        public async Task<List<CitaProgramadaDiaDTO>> ListarCitasProgramadasDia(string COD_PERSONAL, string FECHA)
        {
            return await _CitaRepository.ListarCitasProgramadasDia(COD_PERSONAL,FECHA );
        }
    }
}
