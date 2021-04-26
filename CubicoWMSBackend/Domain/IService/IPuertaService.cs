using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Domain.IService
{
   public  interface IPuertaService
    {

        Task<List<PuertaDTO>> ListarPuerta();
        Task<List<PuertaPisoDTO>> ListarPuerta_X_Piso(int COD_PISO);
        Task<List<PuertaArbolDTO>> ListarPuerta_Arbol();
        Task<List<PuertaArbol_extDTO>> ListarPuerta_ArbolExt();
        Task<MensajeResultado> MantenimientoPuerta(PuertaMantenimientoDTO PUERTA);


    }
}
