using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlNetBackend.Domain.IService
{
   public  interface IPersonalService
    {
        Task<PersonalLoginDTO> Personal_login(string COD_PERSONAL);

    }
}
