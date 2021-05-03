using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
	public class VisitanteDTO
	{
		public int cod_visitante { get; set; }
		public int cod_tipo_doc { get; set; }
		public int cod_tipo_visitante { get; set; }
		public string des_tipo_visitante { get; set; }
		public string des_tipo_doc { get; set; }
		public int cod_centro_costo { get; set; }
		public string des_centro_costo { get; set; }
		public string num_doc { get; set; }
		public string nom_visitante { get; set; }
		public byte[] img_visitante { get; set; }
		public string nom_empresa { get; set; }
		public bool ind_proveedor { get; set; }
		public bool no_deseado { get; set; }
		public string motivo_no_deseado { get; set; }
		public bool Autorizacion_datos { get; set; }
		public string genero { get; set; }
		public bool activo { get; set; }



	}



	

	public class VisitanteMantenimientoDTO
	{
		public int cod_visitante { get; set; }
		public int cod_tipo_doc { get; set; }
		public int cod_tipo_visitante { get; set; }
		public string des_tipo_visitante { get; set; }
		public string des_tipo_doc { get; set; }
		public int cod_centro_costo { get; set; }
		public string des_centro_costo { get; set; }
		public string num_doc { get; set; }
		public string nom_visitante { get; set; }
		public Byte[] img_visitante { get; set; }
		public string nom_empresa { get; set; }
		public bool ind_proveedor { get; set; }
		public bool no_deseado { get; set; }
		public string motivo_no_deseado { get; set; }
		public bool Autorizacion_datos { get; set; }
		public bool activo { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }
		public string ape_paterno { get; set; }
		public string ape_materno { get; set; }
	}
}