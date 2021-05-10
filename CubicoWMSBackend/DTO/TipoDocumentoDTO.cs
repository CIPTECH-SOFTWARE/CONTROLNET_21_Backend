using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class TipoDocumentoDTO
    {
        public int Cod_Tipo_Doc { get; set; }
		public string Nom_Tipo_Doc { get; set; }
        public string Des_Tipo_Doc { get; set; }
        public bool Activo { get; set; }

    }

    public class TipoDocumentoMantenimientoDTO
    {
        public int Cod_Tipo_Doc { get; set; }
        public string Nom_Tipo_Doc { get; set; }
        public string Des_Tipo_Doc { get; set; }
        public bool Activo { get; set; }

        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }


          
    }




}
