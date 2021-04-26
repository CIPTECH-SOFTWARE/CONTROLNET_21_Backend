using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<LoginDTO> ValidateUser(Usuario usuario);
       
    } 
}
