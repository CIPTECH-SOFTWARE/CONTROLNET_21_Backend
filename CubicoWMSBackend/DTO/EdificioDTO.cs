using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class EdificioDTO
    {

        public int cod_edificio { get; set; }
        public int cod_sede { get; set; }
        public string des_sede { get; set; }
        public string des_edificio { get; set; }
        public string des_direccion { get; set; }
        public bool activo { get; set; }


    }

    public class EdificioMantenimientoDTO
    {

        public int cod_edificio { get; set; }
        public int cod_sede { get; set; }
        public string des_sede { get; set; }
        public string des_edificio { get; set; }
        public string des_direccion { get; set; }
        public bool activo { get; set; }
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }
    }

}
