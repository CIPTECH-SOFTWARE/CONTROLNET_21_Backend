using ControlNetBackend.DTO;
using ControlNetBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ControlNetBackend.Service
{
    public class LoginService:ILoginService
    {
        private readonly ILoginRepository _loginRepository;
       

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<LoginDTO> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }

    
    }
}
