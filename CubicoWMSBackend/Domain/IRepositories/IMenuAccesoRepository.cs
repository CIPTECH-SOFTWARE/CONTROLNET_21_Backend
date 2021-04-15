using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
namespace ControlNetBackend.Domain.IRepositories
{
   public interface IMenuAccesoRepository
    {
        Task<List<MenuAccesoPerfilDTO>> ListarMenuAccesoPerfil(int ID_PERFIL);



    }
}
