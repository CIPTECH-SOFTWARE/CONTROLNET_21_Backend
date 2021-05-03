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

   
    public class Grupo_AccesosService : IGrupoAccesosService
    {
        private readonly IGrupoAccesosRepository _GrupoAccesosRepository;
        public async Task<List<GrupoAccesosDTO>> ListarGrupoAccesos()
        {
            return await _GrupoAccesosRepository.ListarGrupoAccesos();
        }

        public async Task<List<GrupoAccesosDTO>> ListarGrupoAccesosEmpresa(int cod_empresa)
        {
            return await _GrupoAccesosRepository.ListarGrupoAccesosEmpresa(cod_empresa);
        }
        public async Task<MensajeResultado> MantenimientoGrupoAccesos(MantenimientoGrupoAccesosDTO grupo)
        {
               return await _GrupoAccesosRepository.MantenimientoGrupoAccesos(grupo);
        }
    }
}
