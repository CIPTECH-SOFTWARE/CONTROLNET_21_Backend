using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class PisoDTO
    {

		public int cod_piso { get; set; }
		public int cod_edificio { get; set; }
		public string des_edificio { get; set; }
		public string des_direccion { get; set; }
		public string des_piso { get; set; }
		public string num_piso { get; set; }
		public bool activo { get; set; }




	}

	public class PisoEdificioDTO
	{

		public int cod_piso { get; set; }
		public int cod_edificio { get; set; }
		public string des_edificio { get; set; }
		public int cod_Sede { get; set; }
		public string des_sede { get; set; }
		public string des_direccion { get; set; }
		public string des_piso { get; set; }
		public string num_piso { get; set; }
		public bool activo { get; set; }



		

	}

	public class PisoArbolDTO
	{

		
		
		public int cod_Sede { get; set; }
		public string des_sede { get; set; }
		public string des_direccion { get; set; }
		public int cod_edificio { get; set; }
		public string des_edificio { get; set; }
		


	}



	public class PisoMantenimientoDTO
	{

		public int cod_piso { get; set; }
		public int cod_edificio { get; set; }
		public string des_piso { get; set; }
		public string num_piso { get; set; }
		public bool activo { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }












	}


}
