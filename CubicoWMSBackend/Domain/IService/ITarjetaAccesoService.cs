using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
   public  interface ITarjetaAccesoService
    {
        Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso();
        Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_X_Empresa(int cod_empresa);
        Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_Filtro(string filtro, int cod_grupo_acceso);
        Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_GA(int cod_empresa, int cod_grupoAcceso);
        Task<MensajeResultado> MantenimientTarjetaAcceso(TarjetaAccesoMantenimientoDTO TARJETA);


    }
}
