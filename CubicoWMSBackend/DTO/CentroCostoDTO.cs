using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class CentroCostoDTO
    {
		public int COD_CENTRO_COSTO { get; set; }
		public string	DES_CENTRO_COSTO { get; set; }
		public int COD_EMPRESA { get; set; }
		public string COD_CENTRO_COSTO_EXT { get; set; }
		public string DES_EMPRESA { get; set; }
		public bool ACTIVO { get; set; }
	}

	public class CentroCosto_usuarioDTO
	{
		public int id_user { get; set; }
	    public int cod_centro_costo { get; set; }
	
	}

	public class CentroCostoMantenimientoDTO
	{
		public int COD_CENTRO_COSTO { get; set; }
		public string DES_CENTRO_COSTO { get; set; }
		public int COD_EMPRESA { get; set; }
		public string cod__CENTRO_COSTO_EXT { get; set; }
		public bool activo { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }
	}






}
