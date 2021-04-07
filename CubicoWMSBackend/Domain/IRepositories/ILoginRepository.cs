﻿using ControlNetBackend.DTO;
using CubicoWMSBackend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Domain.IRepositories
{
    public interface AppDBContext
    {
        Task<LoginDTO> ValidateUser(Usuario usuario);
    } 
}
