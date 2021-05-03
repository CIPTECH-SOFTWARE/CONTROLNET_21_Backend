using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class PerfilService:IPerfilService
    {
        private readonly IPerfilRepository _PerfilRepository;

        public PerfilService(IPerfilRepository PerfilRepository)
        {
            _PerfilRepository = PerfilRepository;
        }

        public async Task<List<PerfilDTO>> ListarPerfil()
        {
            return await _PerfilRepository.ListarPerfil();
        }

        public async Task<MensajeResultado> MantenimientoPerfil(PerfilMantenimientoDTO perfil)
        {
            return await _PerfilRepository.MantenimientoPerfil(perfil);
        }
    }
}
