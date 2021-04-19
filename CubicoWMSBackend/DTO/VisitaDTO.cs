using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class VisitaDTO
    {
		public int num_correlativo { get; set; }
		public string cod_hid_visitado { get; set; }
		public int cod_visitante { get; set; }
		public string cod_hid { get; set; }
		public int cod_sede { get; set; }
		public DateTime fec_ingreso { get; set; }
		public string hor_ingreso { get; set; }
		public DateTime fec_salida { get; set; }
		public string hor_salida { get; set; }
		public string des_adicional { get; set; }
		public bool ind_avisado { get; set; }
		public int num_cita { get; set; }
		public int cod_trabajo { get; set; }
		public int cod_centro_costo { get; set; }
		public string observaciones { get; set; }
		public string motivo { get; set; }
		public int cod_tipo_visitante { get; set; }
		public string nom_empresa { get; set; }
		public int tipo_visita { get; set; }
		public string obs_trabajo { get; set; }
		public int cod_perfil_trabajo { get; set; }
		public int cod_puerta { get; set; }
		public int id_visitado { get; set; }


	}

	public class VisitaDiaDTO {

		public string Img_Cod_Visitante { get; set; }
		public string Nom_Visitante { get; set; }
		public string Num_Doc { get; set; }
		public int Cod_Tipo_Doc{ get; set; }
	    public string Des_Tipo_Doc { get; set; }
		public int Num_Cita { get; set; }
		public int Cod_Visitante { get; set; }
		public DateTime Fec_Ingreso { get; set; }
		public string Hor_Ingreso { get; set; }



	}
}
