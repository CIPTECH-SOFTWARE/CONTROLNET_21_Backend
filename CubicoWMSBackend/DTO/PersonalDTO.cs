using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class PersonalDTO
    {
		public string cod_personal { get; set; }
		public string cod_hid { get; set; }
		public int cod_centro_costo { get; set; }
		public string num_dni { get; set; }
		public string nom_personal { get; set; }
		public string ape_paterno { get; set; }
		public string ape_materno { get; set; }
		public byte[] img_personal { get; set; }
		public bool activo { get; set; }
		public string num_anexo { get; set; }
		public string ind_vehiculo { get; set; }
		public string flg_planta { get; set; }
		public DateTime fecha_inicio_vigencia { get; set; }
		public DateTime fecha_fin_vigencia { get; set; }
		public string email { get; set; }
		public int cod_tipo_doc { get; set; }
		public string cel { get; set; }
		public int id { get; set; }
		public int cod_tipo_personal { get; set; }

	}

	public class PersonalLoginDTO
	{
		public string cod_personal { get; set; }
		public string nom_personal { get; set; }
		public string ape_paterno { get; set; }
		public string ape_materno { get; set; }
		public string email { get; set; }
		public bool activo { get; set; }
	}
}
