﻿using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Domain.IService
{
   public interface IEmpresaService
    {
        Task<List<UsuarioEmpresaDTO>> ListarUsuarioEmpresa(int ID_USER);

    }
}
