using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
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
        public async Task<List<SedeDTO>> ListarSede()
        {
            return await _SedeRepository.ListarSede();
        }
        public async Task<List<SedeConsultaDTO>> ListarSedeConsulta(int cod_sede)
        {
            return await _SedeRepository.ListarSedeConsulta(cod_sede);
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
        public async Task<MensajeResultado> MantenimientoSede(SedeMantenimientoDTO SEDE)
        {
            return await _SedeRepository.MantenimientoSede(SEDE);
        }

       
    }
}
