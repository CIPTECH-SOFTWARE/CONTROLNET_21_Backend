using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IService
{
    public interface IMovimientosPersonalVisitanteService
    {
        Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede(int TIPO, int COD_EMPRESA, int COD_SEDE);
        Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_Top(int TIPO, int COD_EMPRESA, int COD_SEDE);

    }
}
