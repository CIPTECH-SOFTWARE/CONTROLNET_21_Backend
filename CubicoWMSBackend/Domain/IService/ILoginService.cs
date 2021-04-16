using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlNetBackend.Domain.Models;
namespace CubicoWMSBackend.Domain.IService
{
    public interface ILoginService
    {
        Task<LoginDTO> ValidateUser(Usuario usuario);
       
    }
}
