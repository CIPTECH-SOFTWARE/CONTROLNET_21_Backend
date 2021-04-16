using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class CitaDTO
    {
	public int num_cita { get; set; }
	    public string cod_personal { get; set; }
		public int cod_visitante { get; set; }
		public DateTime fec_visita { get; set; }
		public string hor_ingreso { get; set; }
		public string  hor_salida { get; set; }
		public string hor_tolerancia { get; set; }
		public string ind_estado_cita { get; set; }
		public int cod_centro_costo { get; set; }
		public string des_mensaje { get; set; }
		public int  cod_sede { get; set; }
		public string des_empresa { get; set; }
		public int cod_tipo_visitante { get; set; }




	}
}
