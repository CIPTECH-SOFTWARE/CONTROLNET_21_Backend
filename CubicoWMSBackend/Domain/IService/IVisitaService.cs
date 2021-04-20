using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ControlNetBackend.Domain.IService
{
  public  interface IVisitaService
    {
        Task<List<VisitaDiaDTO>> ListarVisitasDia(string COD_PERSONAL, string FECHA);

    }
}
