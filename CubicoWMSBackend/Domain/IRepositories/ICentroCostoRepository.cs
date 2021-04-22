using ControlNetBackend.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlNetBackend.Domain.Models;
namespace ControlNetBackend.Domain.IRepositories
{
   public  interface ICentroCostoRepository
    {

        Task<List<CentroCostoDTO>> ListarCentroCosto();
        Task<List<CentroCostoDTO>> ListarCentroCosto_x_Empresa(int COD_EMPRESA);
        Task<MensajeResultado> MantenimientoCentroCosto(CentroCostoMantenimientoDTO CENTRO_COSTO);



    }
}
