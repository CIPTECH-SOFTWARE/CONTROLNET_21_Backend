using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;


namespace ControlNetBackend.Service
{
    public class AccesosPermisoService : IAccesosPermisoService

    {
        private readonly IAccesoPermisoRepository _AccesoPermisoRepository;

        public AccesosPermisoService(IAccesoPermisoRepository AccesoPermisoRepository)
        {
           _AccesoPermisoRepository = AccesoPermisoRepository;
        }

        public async  Task<MensajeResultado> MantenimientoUsuario_CentroCosto(Usuario_CentroCostoDTO USUARIO_CENTROCOSTO)
        {
            return await _AccesoPermisoRepository.MantenimientoUsuario_CentroCosto(USUARIO_CENTROCOSTO);
        }

        public async Task<MensajeResultado> MantenimientoUsuario_TipoPersonal(Usuario_TipoPersonalDTO USUARIO_TIPOPERSONAL)
        {
            return await _AccesoPermisoRepository.MantenimientoUsuario_TipoPersonal(USUARIO_TIPOPERSONAL);
        }
    }
}
