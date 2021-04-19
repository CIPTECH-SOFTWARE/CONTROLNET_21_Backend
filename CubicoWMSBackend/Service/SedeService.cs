﻿using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Service
{
    public class SedeService : ISedeService
    {
        private readonly ISedeRepository _SedeRepository;
        public SedeService(ISedeRepository SedeRepository)
        {
            _SedeRepository = SedeRepository;
        }

        public async Task<List<SedeDTO>> ListarSede_x_Empresa(int COD_EMPRESA)
        {
            return await _SedeRepository.ListarSede_x_Empresa(COD_EMPRESA);
        }

        public async Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER)
        {
            return  await _SedeRepository.ListarUsuarioSede(ID_USER);
        }
        public async Task<List<UsuarioSedeDTO>> ListarUsuarioSede_activo(int ID_USER)
        {
            return await _SedeRepository.ListarUsuarioSede_activo(ID_USER);
        }
    }
}
