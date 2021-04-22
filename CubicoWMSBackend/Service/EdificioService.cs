using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;

namespace ControlNetBackend.Service
{
    public class EdificioService : IEdificioService
    {

        private readonly IEdificioRepository _EdificioRepository;
        public EdificioService(IEdificioRepository EdificioRepository)
        {
            _EdificioRepository = EdificioRepository;
        }
        public async Task<List<EdificioDTO>> ListarEdificio()
        {
            return await _EdificioRepository.ListarEdificio();
        }
        public async Task<List<EdificioDTO>> ListarEdificio_X_Sede(int cod_sede)
        {
            return await _EdificioRepository.ListarEdificio_X_Sede(cod_sede);
        }
        public async Task<MensajeResultado> MantenimientoEdificio(EdificioMantenimientoDTO EDIFICIO)
        {
            return await _EdificioRepository.MantenimientoEdificio(EDIFICIO);
        }
    }
}
