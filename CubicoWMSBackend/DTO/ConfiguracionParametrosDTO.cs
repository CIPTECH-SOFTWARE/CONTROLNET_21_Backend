using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class ConfiguracionParametrosDTO
    {
		public string Nombre_Archivo_01_out { get; set; }
		public string Nombre_Archivo_02_out { get; set; }
		public string Nombre_Archivo_01_in { get; set; }
		public string Ruta_Archivos_Origen { get; set; }
		public string Ruta_Archivos_Destino { get; set; }
		public int Cantidad_digitos_max_HID { get; set; }
		public string Password_Autorizacion { get; set; }
		public string Ruta_Archivos_Backup { get; set; }
		public string Ruta_Archivos_Origen_Ftp { get; set; }
		public int Tiempo_Minuto_Reunion { get; set; }
		public int Tiempo_Minuto_Tolerancia { get; set; }
		public string EmailEmisor { get; set; }
		public string Dominio { get; set; }
		public string Usuario { get; set; }
		public string Password { get; set; }
		public int Puerto { get; set; }
		public string Host { get; set; }
		public string Asunto { get; set; }
		public string EmailDestino { get; set; }
		public string EmailDestinoCC { get; set; }
		public int Tiempo_tolerancia_permanencia { get; set; }
		public bool SSL { get; set; }
		public string Url_cabecera { get; set; }
		public int Tiempo_proxima_marca_minutos { get; set; }
		public int Tiempo_permanencia_trabajo_horas { get; set; }
		public int Tiempo_promedio_dif_marcas { get; set; }




}
	public class ConfiguracionParametros_EmailDTO
	{
		public string Dominio { get; set; }
		public string Usuario { get; set; }
		public string Password { get; set; }
		public int Puerto { get; set; }
		public string Host { get; set; }
		public string Asunto { get; set; }
		public string EmailDestino { get; set; }
		public string EmailDestinoCC { get; set; }
		public string EmailEmisor { get; set; }

	}

}
