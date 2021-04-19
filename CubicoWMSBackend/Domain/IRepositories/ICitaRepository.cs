using ControlNetBackend.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.IRepositories
{
   public interface ICitaRepository
    {

        Task<List<CitaProgramadaDiaDTO>> ListarCitasProgramadasDia(string COD_PERSONAL, string FECHA);



    }
}
