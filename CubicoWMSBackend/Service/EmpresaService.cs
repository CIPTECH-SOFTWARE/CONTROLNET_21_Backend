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
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }
       
        public async Task<List<EmpresaDTO>> ListarEmpresa()
        {
            return await _EmpresaRepository.ListarEmpresa();
        }
        public async Task<List<EmpresaDTO>> ListarEmpresa_activa(int COD_EMPRESA)
        {
            return await _EmpresaRepository.ListarEmpresa_activa(COD_EMPRESA);
        }
        public async Task<List<UsuarioEmpresaDTO>> ListarUsuarioEmpresa(int ID_USER)
        {
            return await _EmpresaRepository.ListarUsuarioEmpresa(ID_USER);
        }
        public async Task<MensajeResultado> MantenimientoEmpresa(EmpresaMantenimientoDTO EMPRESA)
        {
            return await _EmpresaRepository.MantenimientoEmpresa(EMPRESA);
        }
    }
}
