using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Domain.IRepositories
{
    public interface ISedeRepository
    {
        Task<List<SedeDTO>> ListarSede();
        Task<List<SedeConsultaDTO>> ListarSedeConsulta(int cod_sede);
        Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER);
        Task<List<UsuarioSedeDTO>> ListarUsuarioSede_activo(int ID_USER);
        Task<List<SedeDTO>> ListarSede_x_Empresa(int COD_EMPRESA);
        Task<MensajeResultado> MantenimientoSede(SedeMantenimientoDTO SEDE);

    }
}
