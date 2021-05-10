using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
    public interface ITipoPersonalRepository
    {
        Task<List<TipoPersonalDTO>> ListarTipoPersonal();
        Task<List<TipoPersonalDTO>> ListarTipoPersonal_x_usuario(int ID_USER);
        Task<List<TipoPersonalDTO>> ListarTipoPersonal_X_filtro(string  filtro);
        Task<MensajeResultado> MantenimientoTipoPersonal(TipoPersonalMantenimientoDTO TIPO_PERSONAL);



    }
}
