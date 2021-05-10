using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
   public interface ICentroCostoService
    {
      
        Task<List<CentroCostoDTO>> ListarCentroCosto();
        Task<List<CentroCosto_usuarioDTO>> ListarCentroCosto_x_Usuario(int ID_USER);
        Task<List<CentroCostoDTO>> ListarCentroCosto_x_Filtro(string FILTRO, int COD_EMPRESA);
        Task<List<CentroCostoDTO>> ListarCentroCosto_x_Empresa(int COD_EMPRESA);
        Task<MensajeResultado> MantenimientoCentroCosto(CentroCostoMantenimientoDTO CENTRO_COSTO);
    }
}
