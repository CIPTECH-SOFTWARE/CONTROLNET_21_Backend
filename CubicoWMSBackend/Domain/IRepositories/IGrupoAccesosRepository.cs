using ControlNetBackend.DTO;
using ControlNetBackend.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public  interface IGrupoAccesosRepository
    {
        Task<List<GrupoAccesosDTO>> ListarGrupoAccesos();
        Task<List<GrupoAccesosDTO>> ListarGrupoAccesosEmpresa(int cod_empresa);
        Task<MensajeResultado> MantenimientoGrupoAccesos(MantenimientoGrupoAccesosDTO grupo);
    }
}
