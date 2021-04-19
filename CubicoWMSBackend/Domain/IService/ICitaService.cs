using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IService
{
    public interface ICitaService
    {
        Task<List<CitaProgramadaDiaDTO>> ListarCitasProgramadasDia(string COD_PERSONAL, string FECHA);

    }
}
