using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.IO;
namespace ControlNetBackend.Domain.Models
{
    public class eErrorLog
    {

        public static string mensajeErrorOriginalLog;
        public static string metodoErrorLog;
        public static string tituloErrorLog;

        public eErrorLog(string _mensajeErrorOriginalLog, string _metodoErrorLog, string _tituloErrorLog)
        {
            mensajeErrorOriginalLog = _mensajeErrorOriginalLog;
            metodoErrorLog = _metodoErrorLog;
            tituloErrorLog = _tituloErrorLog;
        }

        public void RegisterLog()
        {
            try
            {
                var rutaLog = "";
                //string rutaErrorLogAlterna = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //string RutaCreacionCarpeta = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string RutaCreacionCarpeta = rutaLog;//"C:\\xControlNetLog";
                if (!Directory.Exists(RutaCreacionCarpeta))
                    Directory.CreateDirectory(RutaCreacionCarpeta);
                string rutaCompletaErrorLog = RutaCreacionCarpeta + "\\LogXControlNet_Software_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + ".log";
                TextWriter tx = new StreamWriter(rutaCompletaErrorLog, true);
                tx.WriteLine(DateTime.Now.ToString());
                tx.WriteLine("---------------------");
                tx.WriteLine("Mensaje: " + mensajeErrorOriginalLog);
                tx.WriteLine("Metodo: " + metodoErrorLog);
                tx.WriteLine("Titulo: " + tituloErrorLog);
                tx.WriteLine("\r");
                tx.Close();
            }
            catch (Exception)
            {

            }
        }


    }
}
