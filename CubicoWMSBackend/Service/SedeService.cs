using ControlNetBackend.Domain.IService;
using ControlNetBackend.DTO;
using ControlNetBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.IService;
using CubicoWMSBackend.Domain.Models;
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
        public async Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER)
        {
            return  await _SedeRepository.ListarUsuarioSede(ID_USER);
        }
    }
}
