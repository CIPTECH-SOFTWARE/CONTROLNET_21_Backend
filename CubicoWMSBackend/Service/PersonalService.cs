using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class PersonalService: IPersonalService
    {

        private readonly IPersonalRepository _PersonalRepository;
        public PersonalService(IPersonalRepository PersonalRepository)
        {
            _PersonalRepository = PersonalRepository;
        }

        public async Task<List<PersonalDTO>> ListarPersonal()
        {
            return await _PersonalRepository.ListarPersonal();
        }

        public async Task<List<PersonalDTO>> ListarPersonal_CentroCosto(int COD_CENTRO_COSTO)
        {
            return await _PersonalRepository.ListarPersonal_CentroCosto(COD_CENTRO_COSTO);
        }

        public async  Task<List<PersonalDTO>> ListarPersonal_Codigo(string COD_PERSONAL)
        {
            return await _PersonalRepository.ListarPersonal_Codigo(COD_PERSONAL);
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Codigo_login(string COD_PERSONAL)
        {
            return await _PersonalRepository.ListarPersonal_Codigo_login(COD_PERSONAL);
        }

        public async  Task<List<PersonalDTO>> ListarPersonal_Empresa(int cod_empresa)
        {
            return await _PersonalRepository.ListarPersonal_Empresa(cod_empresa);
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Empresa_filtro(int COD_EMPRESA, int ID_USER)
        {
            return await _PersonalRepository.ListarPersonal_Empresa_filtro(COD_EMPRESA, ID_USER);
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Empresa_tree(int COD_EMPRESA)
        {
            return await _PersonalRepository.ListarPersonal_Empresa_tree(COD_EMPRESA);
        }

        public async Task<List<PersonalDTO>> ListarPersonal_GAP(int COD_GAP)
        {
            return await _PersonalRepository.ListarPersonal_GAP(COD_GAP);
        }

        public async Task<MensajeResultado> MantenimientoPersonal(PersonalMantenimientoDTO PERSONAL)
        {
            return await _PersonalRepository.MantenimientoPersonal(PERSONAL);
        }

        public async Task<PersonalLoginDTO> Personal_login(string COD_PERSONAL)
        {
            return await _PersonalRepository.Personal_login(COD_PERSONAL);
        }
    }
}
