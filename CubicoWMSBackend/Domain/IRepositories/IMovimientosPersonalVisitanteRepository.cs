using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IRepositories
{
   public interface IMovimientosPersonalVisitanteRepository
    {

        Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_DHAS(int TIPO,int COD_EMPRESA,int COD_SEDE);
        Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_Top_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE);
        Task<string> TotalCantidades_Movimiento_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO,int COD_EMPRESA,int COD_SEDE);
    }
}
