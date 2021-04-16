using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
  public interface IConfiguracionParametrosRepository
    {
        Task<ConfiguracionParametrosDTO> ParametrosConfiguracion();
        Task<ConfiguracionParametros_EmailDTO> ParametrosConfiguracionEmail();
       


    }
}
