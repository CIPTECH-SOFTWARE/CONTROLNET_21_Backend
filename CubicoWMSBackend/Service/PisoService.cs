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
    public class PisoService:IPisoService
    {
        private readonly IPisoRepository _PisoRepository;

        public async Task<List<PisoDTO>> ListarPiso()
        {
            return await _PisoRepository.ListarPiso();
        }

        public async Task<List<PisoArbolDTO>> ListarPiso_Arbol()
        {
            return await _PisoRepository.ListarPiso_Arbol();
        }

        public async Task<List<PisoEdificioDTO>> ListarPiso_X_Edificio(int COD_EDIFICIO)
        {
            return await _PisoRepository.ListarPiso_X_Edificio(COD_EDIFICIO);
        }

        public async Task<MensajeResultado> MantenimientoPiso(PisoMantenimientoDTO PISO)
        {
            return await _PisoRepository.MantenimientoPiso(PISO);
        }
    }
}
