using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
    public interface IVisitaRepository
    {
        Task<List<VisitaDiaDTO>> ListarVisitasDia(string COD_PERSONAL,string FECHA);




    }
}
