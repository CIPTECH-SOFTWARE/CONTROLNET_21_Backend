using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.IService;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlNetBackend.Service
{
    public class TarjetaAccesoService:ITarjetaAccesoService
    {
        private readonly ITarjetaAccesoRepository _TarjetaAccesoRepository;
        public TarjetaAccesoService(ITarjetaAccesoRepository TarjetaAccesoRepository)
        {
            _TarjetaAccesoRepository = TarjetaAccesoRepository;
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso()
        {
            return await _TarjetaAccesoRepository.ListarTarjetaAcceso();
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_Filtro(string filtro,int cod_grupo_acceso)
        {
            return await _TarjetaAccesoRepository.ListarTarjetaAcceso_Filtro( filtro, cod_grupo_acceso);
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_GA(int cod_empresa, int cod_grupoAcceso)
        {
            return await _TarjetaAccesoRepository.ListarTarjetaAcceso_GA( cod_empresa,  cod_grupoAcceso);
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_X_Empresa(int cod_empresa)
        {
            return await _TarjetaAccesoRepository.ListarTarjetaAcceso_X_Empresa(cod_empresa);

        }

        public async Task<MensajeResultado> MantenimientTarjetaAcceso(TarjetaAccesoMantenimientoDTO TARJETA)
        {
            return await _TarjetaAccesoRepository.MantenimientTarjetaAcceso(TARJETA);

        }
    }
}
