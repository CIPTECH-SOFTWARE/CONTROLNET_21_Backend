using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
	public class PuertaDTO
	{
		public int COD_PUERTA { get; set; }
		public int COD_PISO { get; set; }
		public int COD_EDIFICIO { get; set; }
		public string DES_EDIFICIO { get; set; }
		public string DES_PISO { get; set; }
		public string NUM_PISO { get; set; }
		public string DES_PUERTA { get; set; }
		public string NUM_PUERTA { get; set; }
		public string IP { get; set; }
		public string USER_FTP { get; set; }
		public string PASS_FTP { get; set; }
		public bool FLAG_ANONIMUS_FTP { get; set; }
		public bool ACTIVO { get; set; }
		public string Ruta_Origen_FTP { get; set; }

	}

	public class PuertaPisoDTO
	{
		public int cod_puerta { get; set; }
		public int cod_piso { get; set; }
		public int cod_sede { get; set; }
		public string des_sede { get; set; }
		public int cod_edificio { get; set; }
		public string des_edificio { get; set; }
		public string des_piso { get; set; }
		public string num_piso { get; set; }
		public string des_puerta { get; set; }
		public string num_puerta { get; set; }
		public string ip { get; set; }
		public string user_ftp { get; set; }
		public string pass_ftp { get; set; }
		public bool flag_anonimus_ftp { get; set; }
		public bool activo { get; set; }
		public string ruta_origen_ftp { get; set; }
		public DateTime fecha_inicio { get; set; }
		public DateTime fecha_fin { get; set; }
		public bool ingreso_sede { get; set; }

	}

	public class PuertaArbolDTO
	{
		public int cod_edificio { get; set; }
		public string des_edificio { get; set; }
		public string des_direccion { get; set; }
		public int cod_piso { get; set; }
		public string des_piso { get; set; }
		public string num_piso { get; set; }

	}

	public class PuertaArbol_extDTO
	{
		public int cod_sede { get; set; }
		public string des_sede { get; set; }
		public string direccion { get; set; }
		public int cod_empresa { get; set; }
		public string des_empresa { get; set; }
		public int sede_padre { get; set; }
		public int cod_edificio { get; set; }
		public string des_edificio { get; set; }
		public int edificio_padre { get; set; }
		public int cod_piso { get; set; }
		public string des_piso { get; set; }
		
		
	}


	public class PuertaMantenimientoDTO
	{

		public int Cod_Puerta { get; set; }
		public int Cod_Piso { get; set; }
		public string Des_Puerta { get; set; }
		public string Num_Puerta { get; set; }
		public string Ip { get; set; }
		
		public string User_Ftp { get; set; }
		public string Pass_Ftp { get; set; }
		public bool Flag_Anonimus_Ftp { get; set; }
		public DateTime Fecha_Inicio { get; set; }
		public DateTime Fecha_Fin { get; set; }
		public bool Ingresar_Sede { get; set; }
		public bool Activo { get; set; }
		public int Tipo_Operacion { get; set; }
		public int id_user { get; set; }

	}


}