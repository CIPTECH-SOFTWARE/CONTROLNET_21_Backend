using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface IPersonalRepository
    {
        Task<PersonalLoginDTO> Personal_login(string COD_PERSONAL);




    }
}
