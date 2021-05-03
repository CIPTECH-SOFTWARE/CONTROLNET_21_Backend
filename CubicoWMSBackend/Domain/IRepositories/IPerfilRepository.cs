using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface IPerfilRepository
    {

        Task<List<PerfilDTO>> ListarPerfil();
       // Task<List<PerfilDTO>> ListarPerfil_X_Edificio(int COD_EDIFICIO);
        Task<MensajeResultado> MantenimientoPerfil(PerfilMantenimientoDTO perfil);



    }
}
