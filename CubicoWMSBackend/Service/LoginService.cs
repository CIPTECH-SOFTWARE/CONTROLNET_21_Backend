using ControlNetBackend.DTO;
using CubicoWMSBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.IService;
using CubicoWMSBackend.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CubicoWMSBackend.Service
{
    public class LoginService:ILoginService
    {
        private readonly AppDBContext _loginRepository;
       

        public LoginService(AppDBContext loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<LoginDTO> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }

    
    }
}
