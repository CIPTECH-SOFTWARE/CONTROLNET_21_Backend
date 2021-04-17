using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class PersonalService: IPersonalService
    {

        private readonly IPersonalRepository _PersonalRepository;
        public PersonalService(IPersonalRepository PersonalRepository)
        {
            _PersonalRepository = PersonalRepository;
        }

     

        public async Task<PersonalLoginDTO> Personal_login(string COD_PERSONAL)
        {
            return await _PersonalRepository.Personal_login(COD_PERSONAL);
        }
    }
}
