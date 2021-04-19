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


	public class CitaProgramadaDiaDTO
	{

		public string Img_Cod_Visitante { get; set; }
		public string Fec_Visita_Str { get; set; } 
		public int Num_Cita { get; set; }
		public string Cod_Personal { get; set; }
		public string Nom_Personal { get; set; }
		public string Nom_Visitante { get; set; }  
		public int Cod_Tipo_Doc { get; set; }
		public string Des_Tipo_Doc { get; set; }
		public string  Num_Doc { get; set; }
		public int Cod_Visitante { get; set; }
		public DateTime Fec_Visita { get; set; }
		public string Hor_Ingreso { get; set; }
		public string Hor_Salida { get; set; }
		public string Hor_Tolerancia { get; set; }
		public string Ind_Estado_Cita { get; set; }
		public int Cod_Centro_Costo { get; set; }
		public string Des_Mensaje { get; set; } 
		public string Des_Empresa { get; set; }
		public int Cod_Tipo_Visitante { get; set; }
		public string Des_Tipo_Visitante { get; set; }

















	}

}
