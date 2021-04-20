using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
namespace ControlNetBackend.Domain.IRepositories
{
   public  interface IEmpresaRepository
    {
        Task<List<EmpresaDTO>> ListarEmpresa();
        Task<List<EmpresaDTO>> ListarEmpresa_activa(int COD_EMPRESA);
        Task<List<UsuarioEmpresaDTO>> ListarUsuarioEmpresa(int ID_USER);
        Task<MensajeResultado> MantenimientoEmpresa(EmpresaMantenimientoDTO empresa);

    }
}
