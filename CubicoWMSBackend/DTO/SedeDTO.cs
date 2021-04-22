using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class SedeDTO
    {

		public int cod_sede { get; set; }
		public string des_sede { get; set; }
		public string direccion { get; set; }
		public bool activo { get; set; }
		public int cod_empresa { get; set; }






	}
	public class USedeDTO
	{

		public int cod_sede { get; set; }
		public string des_sede { get; set; }
		public string direccion { get; set; }
		public bool activo { get; set; }
		public int cod_empresa { get; set; }






	}


	public class SedeConsultaDTO
	{

		public int cod_sede { get; set; }
		public string des_sede { get; set; }
		

	}
	public class SedeMantenimientoDTO
	{

		public int cod_sede { get; set; }
		public string des_sede { get; set; }
		public string direccion { get; set; }
		public bool activo { get; set; }
		public int cod_empresa { get; set; }
		public bool flag_activo { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }

	}

}
