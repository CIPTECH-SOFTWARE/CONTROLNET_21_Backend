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
    public class PuertaService : IPuertaService
    {
        private readonly IPuertaRepository _PuertaRepository;
        public async Task<List<PuertaDTO>> ListarPuerta()
        {
            return await _PuertaRepository.ListarPuerta();    
        }

        public async Task<List<PuertaArbolDTO>> ListarPuerta_Arbol()
        {
            return await _PuertaRepository.ListarPuerta_Arbol();
        }

        public async Task<List<PuertaArbol_extDTO>> ListarPuerta_ArbolExt()
        {
            return await _PuertaRepository.ListarPuerta_ArbolExt();
        }

        public async Task<List<PuertaPisoDTO>> ListarPuerta_X_Piso(int COD_PISO)
        {
            return await _PuertaRepository.ListarPuerta_X_Piso(COD_PISO);
        }

        public async Task<MensajeResultado> MantenimientoPuerta(PuertaMantenimientoDTO PUERTA)
        {
            return await _PuertaRepository.MantenimientoPuerta(PUERTA);
        }
    }
}
