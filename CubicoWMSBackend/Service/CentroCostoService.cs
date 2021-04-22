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
    public class CentroCostoService:ICentroCostoService
    {
        private readonly ICentroCostoRepository _CentroCostoRepository;

        public CentroCostoService(ICentroCostoRepository CentroCostoRepository)
        {
            _CentroCostoRepository = CentroCostoRepository;
        }
        public async Task<List<CentroCostoDTO>> ListarCentroCosto()
        {
            return await _CentroCostoRepository.ListarCentroCosto();
        }
        public async Task<List<CentroCostoDTO>> ListarCentroCosto_x_Empresa(int COD_EMPRESA)
        {
            return await _CentroCostoRepository.ListarCentroCosto_x_Empresa(COD_EMPRESA);
        }
        public async Task<MensajeResultado> MantenimientoCentroCosto(CentroCostoMantenimientoDTO CENTRO_COSTO)
        {
            return await _CentroCostoRepository.MantenimientoCentroCosto(CENTRO_COSTO);
        }
    }
}
