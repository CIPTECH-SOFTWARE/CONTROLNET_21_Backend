using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class MovimientosPersonalVisitanteService:IMovimientosPersonalVisitanteService
    {
        private readonly IMovimientosPersonalVisitanteRepository _MovimientosPersonalVisitanteRepository;

        public MovimientosPersonalVisitanteService(IMovimientosPersonalVisitanteRepository MovimientosPersonalVisitanteRepository)
        {
            _MovimientosPersonalVisitanteRepository = MovimientosPersonalVisitanteRepository;
        }

        public async Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            return await _MovimientosPersonalVisitanteRepository.ListarIngresoSede_DHAS(TIPO,COD_EMPRESA,COD_SEDE);
        }

        public async Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_Top_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            return await _MovimientosPersonalVisitanteRepository.ListarIngresoSede_Top_DHAS(TIPO, COD_EMPRESA, COD_SEDE);
        }

        public async Task<string> TotalCantidades_Movimiento_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            return await _MovimientosPersonalVisitanteRepository.TotalCantidades_Movimiento_DHAS(FECHA_INICIO,FECHA_FIN,TIPO, COD_EMPRESA, COD_SEDE);
        }
    }
}
