using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;

namespace ControlNetBackend.Service
{
    public class MenuAccesoService : IMenuAccesoService
    {

        private readonly IMenuAccesoRepository _MenuAccesoRepository;
        public MenuAccesoService(IMenuAccesoRepository MenuAccesoRepository)
        {
            _MenuAccesoRepository = MenuAccesoRepository;
        }
        public async Task<List<MenuAccesoPerfilDTO>> ListarMenuAccesoPerfil(int ID_PERFIL)
        {
            return await _MenuAccesoRepository.ListarMenuAccesoPerfil(ID_PERFIL);
        }
    }
}
