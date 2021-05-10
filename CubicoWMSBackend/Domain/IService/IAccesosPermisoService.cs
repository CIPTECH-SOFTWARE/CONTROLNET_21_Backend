using ControlNetBackend.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlNetBackend.Domain.Models;

namespace ControlNetBackend.Domain.IService
{
    public interface IAccesosPermisoService
    {
        Task<MensajeResultado> MantenimientoUsuario_TipoPersonal(Usuario_TipoPersonalDTO USUARIO_TIPOPERSONAL);
        Task<MensajeResultado> MantenimientoUsuario_CentroCosto(Usuario_CentroCostoDTO USUARIO_CENTROCOSTO);

    }
}
