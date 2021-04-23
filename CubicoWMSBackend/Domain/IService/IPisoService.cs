﻿using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlNetBackend.Domain.IService
{
   public interface IPisoService
    {
        Task<List<PisoDTO>> ListarPiso();
        Task<List<PisoEdificioDTO>> ListarPiso_X_Edificio(int COD_EDIFICIO);
        Task<List<PisoArbolDTO>> ListarPiso_Arbol();
        Task<MensajeResultado> MantenimientoPiso(PisoMantenimientoDTO PISO);



    }
}
