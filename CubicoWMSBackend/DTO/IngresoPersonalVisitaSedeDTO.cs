using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class IngresoPersonalVisitaSedeDTO
    {

       public int orden { get; set; }
       public string codigo { get; set; }
       public string nombre { get; set; }
       public byte[] imagen { get; set; }
       public string tipo_documento { get; set; }
       public string numero_documento { get; set; }
       public string centro_costo { get; set; }
       public string fec_hor_acceso { get; set; }



    }
    public class IngresoVisitaTiempoExcesoSedeDTO
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string centro_costo { get; set; }
        public string hora_acceso { get; set; }
        public string tiempo_de_exceso { get; set; }
        public int minutos_exceso { get; set; }
        public byte[] imagen { get; set; }
    
    }

    public class IngresoVisitaPersonalGraficaDTO
    {
        public string hora { get; set; }
        
        public int cantidad { get; set; }
        

    }

}
