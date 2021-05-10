using ControlNetBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface IAccesoPermisoRepository
    {

        Task<MensajeResultado> MantenimientoUsuario_TipoPersonal(Usuario_TipoPersonalDTO USUARIO_TIPOPERSONAL);
        Task<MensajeResultado> MantenimientoUsuario_CentroCosto(Usuario_CentroCostoDTO USUARIO_CENTROCOSTO);

    }
}
