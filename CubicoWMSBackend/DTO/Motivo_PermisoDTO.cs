using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class Motivo_PermisoDTO
    {

        public int cod_motivo { get; set; }
		public string descripcion { get; set; }
        public bool activo { get; set; }
        public bool traslado_sede { get; set; }



    }
}
