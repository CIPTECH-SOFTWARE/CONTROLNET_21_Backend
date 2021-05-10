using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class MailingDTO
    {
       public int id_mailing { get; set; }
       public int tipo { get; set; }
        public string descripcion { get; set; }
        public string descripcion_tipo { get; set; }
        public bool flag_participante { get; set; }
        public bool flag_responsable { get; set; }
        public bool otros { get; set; }
        public bool activo { get; set; }





    }

    public class MailingDetalleDTO
    {
        public int id_mailing { get; set; }
        public string email { get; set; }
        public string  nombre_completo_persona { get; set; }
        public string cod_personal { get; set; }
        public bool flag_personal { get; set; }
        public int tipo { get; set; }
    }

    public class ProcesoMailingDTO
    {
        public int cod_perfil_trabajo { get; set; }
        public string descripcion { get; set; }
       
    }

    public class TipoProceso_Mailing
    {
        public int cod_perfil_trabajo { get; set; }
        public string descripcion { get; set; }


    }



    public class MailingMantenimientoDTO
    {

        public int id_mailing { get; set; }
        public int id_tipo { get; set; }
        public bool flag_participante { get; set; }
        public bool flag_responsable { get; set; }
        public bool otros { get; set; }
        public bool activo { get; set; }
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }

    }
}
