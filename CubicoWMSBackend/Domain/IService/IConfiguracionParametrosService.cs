using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
   public interface IConfiguracionParametrosService
    {
        Task<ConfiguracionParametrosDTO> ParametrosConfiguracion();
        Task<ConfiguracionParametros_EmailDTO> ParametrosConfiguracionEmail();
        Task<string> ActualizarConfiguracionParametros(ConfiguracionParametrosDTO configuracionParametrosDTO);



    }
}
