using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class TipoPersonalDTO
    {
        public int cod_tipo_personal { get; set; }
        public string des_tipo_personal { get; set; }
        public bool flag_activo { get; set; }
        public string cod_tipo_personal_ext { get; set; }



    }

    public class TipoPersonalMantenimientoDTO
    {
        public int cod_tipo_personal { get; set; }
        public string des_tipo_personal { get; set; }
        public bool flag_activo { get; set; }
        public string cod_tipo_personal_ext { get; set; }
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }


    }



}
