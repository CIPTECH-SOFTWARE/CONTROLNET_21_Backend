using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
	public class TipoVisitanteDTO
	{


		public int cod_tipo_visitante { get; set; }
		public string des_tipo_visitante { get; set; }
		public string des_prefijo { get; set; }
		public bool activo { get; set; }
		public bool impresion { get; set; }
		public bool contratista { get; set; }
		public bool empresa { get; set; }



	}

	public class TipoVisitanteMantenimientoDTO
	{
		public int cod_tipo_visitante { get; set; }
		public string des_tipo_visitante { get; set; }
		public string des_prefijo { get; set; }
		public bool activo { get; set; }
		public bool impresion { get; set; }
		public bool contratista { get; set; }
		public bool empresa { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }
	}
}