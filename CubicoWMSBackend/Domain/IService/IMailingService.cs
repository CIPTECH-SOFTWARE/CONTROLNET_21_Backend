using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
using ControlNetBackend.Domain.Models;

namespace ControlNetBackend.Domain.IService
{
   public interface IMailingService
    {
        Task<List<MailingDTO>> ListaMailing();
        Task<List<ProcesoMailingDTO>> ListaProcesoMailing(int id_mailing);
        Task<List<MailingDetalleDTO>> ListaOtrosMailing(int id_mailing, int tipo);
        Task<List<MailingDetalleDTO>> ListaOtrosCorreoMailing(int id_mailing, int tipo);
        Task<List<ProcesoMailingDTO>> TipoProcesoMailing(int id_mailing);
        Task<MensajeResultado> MantenimientoMailing(MailingMantenimientoDTO Mailing);




    }
}
