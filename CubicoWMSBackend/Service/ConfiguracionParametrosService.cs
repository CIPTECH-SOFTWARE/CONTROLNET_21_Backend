using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class ConfiguracionParametrosService : IConfiguracionParametrosService
    {

        private readonly IConfiguracionParametrosRepository _ConfiguracionParametrosRepository;
        public ConfiguracionParametrosService(IConfiguracionParametrosRepository ConfiguracionParametrosRepository)
        {
            _ConfiguracionParametrosRepository = ConfiguracionParametrosRepository;
        }
        public Task<ConfiguracionParametrosDTO> ParametrosConfiguracion()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ConfiguracionParametros_EmailDTO> ParametrosConfiguracionEmail()
        {
            return await _ConfiguracionParametrosRepository.ParametrosConfiguracionEmail();
        }
    }
}
