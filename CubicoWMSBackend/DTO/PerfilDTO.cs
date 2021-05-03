using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class PerfilDTO
    {

        public int cod_perfil { get; set; }
        public string des_perfil { get; set; }
        public bool activo { get; set; }




    }

    public class PerfilMantenimientoDTO
    {
        public int cod_perfil { get; set; }
        public string des_perfil { get; set; }
        public bool activo { get; set; }
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }



    }

}