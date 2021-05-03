using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlNetBackend.Domain.IService
{
   public  interface IPersonalService
    {
        Task<PersonalLoginDTO> Personal_login(string COD_PERSONAL);
        Task<List<PersonalDTO>> ListarPersonal();
        Task<List<PersonalDTO>> ListarPersonal_CentroCosto(int COD_CENTRO_COSTO);
        Task<List<PersonalDTO>> ListarPersonal_Empresa_filtro(int COD_EMPRESA, int ID_USER);
        Task<List<PersonalDTO>> ListarPersonal_Empresa(int cod_empresa);
        Task<List<PersonalDTO>> ListarPersonal_GAP(int COD_GAP);
        Task<List<PersonalDTO>> ListarPersonal_Empresa_tree(int COD_EMPRESA);
        Task<List<PersonalDTO>> ListarPersonal_Codigo(string COD_PERSONAL);
        Task<List<PersonalDTO>> ListarPersonal_Codigo_login(string COD_PERSONAL);
        Task<MensajeResultado> MantenimientoPersonal(PersonalMantenimientoDTO PERSONAL);
    }
}
