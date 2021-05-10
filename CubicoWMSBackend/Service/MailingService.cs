using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class MailingService:IMailingService
    {
        private readonly IMailingRepository _MailingRepository;
        public MailingService(IMailingRepository MailingRepository)
        {
            _MailingRepository = MailingRepository;
        }

        public async Task<List<MailingDTO>> ListaMailing()
        {
            return await _MailingRepository.ListaMailing();
        }

        public async Task<List<MailingDetalleDTO>> ListaOtrosCorreoMailing(int id_mailing, int tipo)
        {
            return await _MailingRepository.ListaOtrosCorreoMailing(id_mailing,tipo);
        }

        public async Task<List<MailingDetalleDTO>> ListaOtrosMailing(int id_mailing, int tipo)
        {
            return await _MailingRepository.ListaOtrosMailing(id_mailing,tipo);
        }

        public async Task<List<ProcesoMailingDTO>> ListaProcesoMailing(int id_mailing)
        {
            return await _MailingRepository.ListaProcesoMailing(id_mailing);
        }

        public async Task<MensajeResultado> MantenimientoMailing(MailingMantenimientoDTO Mailing)
        {
            return await _MailingRepository.MantenimientoMailing(Mailing);
        }

        public async Task<List<ProcesoMailingDTO>> TipoProcesoMailing(int id_mailing)
        {
            return await _MailingRepository.TipoProcesoMailing(id_mailing);
        }
    }
}
