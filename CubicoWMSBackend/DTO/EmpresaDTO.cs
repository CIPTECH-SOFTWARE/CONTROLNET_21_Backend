using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class EmpresaDTO
    {
		public int cod_empresa { get; set; }
		public string ruc { get; set; }
		public string des_empresa { get; set; }
		public bool flag_activo { get; set; }
		
	}

	public class EmpresaMantenimientoDTO
	{
		public int cod_empresa { get; set; }
		public string ruc { get; set; }
		public string des_empresa { get; set; }
		public bool flag_activo { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }
	}
}
