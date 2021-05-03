using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class TarjetaAccesoDTO
    {
		public int cod_hid { get; set; }
		public string des_hid { get; set; }
		public string num_hid { get; set; }
		public int id_grupo_hid { get; set; }
		public string descripcion { get; set; }
		public int cod_empresa { get; set; }
		public string des_empresa { get; set; }
		public bool hid_activo { get; set; }
		public bool activo { get; set; }



	}

	public class TarjetaAccesoMantenimientoDTO
	{

		public int cod_hid { get; set; }
		public string des_hid { get; set; }
		public string num_hid { get; set; }
		public int id_grupo_hid { get; set; }
		public int cod_empresa { get; set; }
		public string des_empresa { get; set; }
		public bool hid_activo { get; set; }
		public bool activo { get; set; }
		public DateTime Fecha_Inicio { get; set; }
		public DateTime Fecha_Fin { get; set; }
	    public int cod_sede { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }
	}




}
