using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;

namespace ControlNetBackend.Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _EmpresaRepository;

        public EmpresaService(IEmpresaRepository EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }

        public async Task<List<UsuarioEmpresaDTO>> ListarUsuarioEmpresa(int ID_USER)
        {
            return await _EmpresaRepository.ListarUsuarioEmpresa(ID_USER);
        }
    }
}
