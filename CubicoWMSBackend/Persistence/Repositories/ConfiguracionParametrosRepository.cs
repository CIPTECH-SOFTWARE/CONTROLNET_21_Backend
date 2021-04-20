using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ControlNetBackend.Persistence.Repositories
{
    public class ConfiguracionParametrosRepository : IConfiguracionParametrosRepository
    {
        private readonly AppDbContext _appDBContext;
        public ConfiguracionParametrosRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<string> ActualizarConfiguracionParametros(ConfiguracionParametrosDTO configuracionParametrosDTO)
        {
            var mensaje = getActualizarConfiguracionParametros(configuracionParametrosDTO);
            return mensaje;
        }

        public async Task<ConfiguracionParametrosDTO> ParametrosConfiguracion()
        {
            var Parametros = getParametrosConfiguracion();
            return Parametros;
        }

        public async Task<ConfiguracionParametros_EmailDTO> ParametrosConfiguracionEmail()
        {
            var Parametros = getParametrosConfiguracion_Email();
            return Parametros;
        }

        private ConfiguracionParametros_EmailDTO getParametrosConfiguracion_Email()
        {

            ConfiguracionParametros_EmailDTO ConfiguracionParametros_EmailDTO = new ConfiguracionParametros_EmailDTO();
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Parametros_Email_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {

                        ConfiguracionParametros_EmailDTO.EmailEmisor = oDataReader["EmailEmisor"].ToString();
                        ConfiguracionParametros_EmailDTO.Dominio = oDataReader["Dominio"].ToString();
                        ConfiguracionParametros_EmailDTO.Usuario = oDataReader["Usuario"].ToString();
                        ConfiguracionParametros_EmailDTO.Password = oDataReader["Password"].ToString();
                        ConfiguracionParametros_EmailDTO.Puerto = int.Parse(oDataReader["Puerto"].ToString());
                        ConfiguracionParametros_EmailDTO.Host = oDataReader["Host"].ToString();
                        ConfiguracionParametros_EmailDTO.Asunto = oDataReader["Asunto"].ToString();
                        ConfiguracionParametros_EmailDTO.EmailDestino = oDataReader["EmailDestino"].ToString();
                        ConfiguracionParametros_EmailDTO.EmailDestinoCC = oDataReader["EmailDestinoCC"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ConfiguracionParametros_EmailDTO = null;
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ConfiguracionParametros_EmailDTO;


        }

        public string getActualizarConfiguracionParametros(ConfiguracionParametrosDTO configuracionParametrosDTO)
        {

            string mensaje = string.Empty;
            //ListaUsuarioEmpresaDTO = null;
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_TX_Actualizar_Configuracion_Parametros_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Nombre_Archivo_01_out", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Nombre_Archivo_01_out;
                    Sqlcmd.Parameters.Add("@Nombre_Archivo_02_out", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Nombre_Archivo_02_out;
                    Sqlcmd.Parameters.Add("@Nombre_Archivo_01_in", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Nombre_Archivo_01_in;
                    Sqlcmd.Parameters.Add("@Ruta_Archivos_Origen", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Ruta_Archivos_Origen;
                    Sqlcmd.Parameters.Add("@Ruta_Archivos_Destino", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Ruta_Archivos_Destino;
                    Sqlcmd.Parameters.Add("@Password_Autorizacion", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Password_Autorizacion;
                    Sqlcmd.Parameters.Add("@Ruta_Archivos_Backup", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Ruta_Archivos_Backup;
                    Sqlcmd.Parameters.Add("@Ruta_Archivos_Origen_Ftp", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Ruta_Archivos_Origen_Ftp;
                    Sqlcmd.Parameters.Add("@Tiempo_Minuto_Reunion", SqlDbType.Int).Value = configuracionParametrosDTO.Tiempo_Minuto_Reunion;
                    Sqlcmd.Parameters.Add("@Tiempo_Minuto_Tolerancia", SqlDbType.Int).Value = configuracionParametrosDTO.Tiempo_Minuto_Tolerancia;
                    Sqlcmd.Parameters.Add("@Email_Emisor", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.EmailEmisor;
                    Sqlcmd.Parameters.Add("@Dominio", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Dominio;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Usuario;
                    Sqlcmd.Parameters.Add("@Password_Email", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Password;
                    Sqlcmd.Parameters.Add("@Email_Destino", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.EmailDestino;
                    Sqlcmd.Parameters.Add("@Email_Destino_CC", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.EmailDestinoCC;
                    Sqlcmd.Parameters.Add("@Puerto", SqlDbType.Int).Value = configuracionParametrosDTO.Puerto;
                    Sqlcmd.Parameters.Add("@Host", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Host;
                    Sqlcmd.Parameters.Add("@SSL", SqlDbType.Bit).Value = configuracionParametrosDTO.SSL;
                    Sqlcmd.Parameters.Add("@Asunto", SqlDbType.VarChar, 100).Value = configuracionParametrosDTO.Asunto;
                    Sqlcmd.Parameters.Add("@Tiempo_tolerancia_permanencia", SqlDbType.Int).Value = configuracionParametrosDTO.Tiempo_tolerancia_permanencia;
                    Sqlcmd.Parameters.Add("@Tiempo_espera_proxima_marca", SqlDbType.Int).Value = configuracionParametrosDTO.Tiempo_proxima_marca_minutos;
                    Sqlcmd.Parameters.Add("@Url_cabecera_WS", SqlDbType.VarChar).Value = configuracionParametrosDTO.Url_cabecera;




                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        mensaje = oDataReader["mensaje"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return mensaje;




        }




        public ConfiguracionParametrosDTO getParametrosConfiguracion()
        {
            ConfiguracionParametrosDTO ConfiguracionParametrosDTO = new ConfiguracionParametrosDTO();
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Configuracion_Parametros_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {

                        ConfiguracionParametrosDTO.Nombre_Archivo_01_out = oDataReader["Nombre_Archivo_01_out"].ToString();
                        ConfiguracionParametrosDTO.Nombre_Archivo_02_out = oDataReader["Nombre_Archivo_02_out"].ToString();
                        ConfiguracionParametrosDTO.Nombre_Archivo_01_in = oDataReader["Nombre_Archivo_01_in"].ToString();
                        ConfiguracionParametrosDTO.Ruta_Archivos_Origen = oDataReader["Ruta_Archivos_Origen"].ToString();
                        ConfiguracionParametrosDTO.Ruta_Archivos_Destino = oDataReader["Ruta_Archivos_Destino"].ToString();
                        ConfiguracionParametrosDTO.Password_Autorizacion = oDataReader["Password_Autorizacion"].ToString();
                        ConfiguracionParametrosDTO.Ruta_Archivos_Backup = oDataReader["Ruta_Archivos_Backup"].ToString();
                        ConfiguracionParametrosDTO.Ruta_Archivos_Origen_Ftp = oDataReader["Ruta_Archivos_Origen_Ftp"].ToString();
                        ConfiguracionParametrosDTO.Tiempo_Minuto_Reunion = int.Parse(oDataReader["Tiempo_Minuto_Reunion"].ToString());
                        ConfiguracionParametrosDTO.Tiempo_Minuto_Tolerancia = int.Parse(oDataReader["Tiempo_Minuto_Tolerancia"].ToString());
                        ConfiguracionParametrosDTO.EmailEmisor = oDataReader["EmailEmisor"].ToString();
                        ConfiguracionParametrosDTO.Dominio = oDataReader["Dominio"].ToString();
                        ConfiguracionParametrosDTO.Usuario = oDataReader["Usuario"].ToString();
                        ConfiguracionParametrosDTO.Password = oDataReader["Password"].ToString();
                        ConfiguracionParametrosDTO.Puerto = int.Parse(oDataReader["Puerto"].ToString());
                        ConfiguracionParametrosDTO.Host = oDataReader["Host"].ToString();
                        ConfiguracionParametrosDTO.SSL = bool.Parse(oDataReader["SSL"].ToString());
                        ConfiguracionParametrosDTO.Asunto = oDataReader["Asunto"].ToString();
                        ConfiguracionParametrosDTO.EmailDestino = oDataReader["EmailDestino"].ToString();
                        ConfiguracionParametrosDTO.EmailDestinoCC = oDataReader["EmailDestinoCC"].ToString();
                        ConfiguracionParametrosDTO.Tiempo_tolerancia_permanencia = int.Parse(oDataReader["Tiempo_tolerancia_permanencia"].ToString());
                        ConfiguracionParametrosDTO.Tiempo_proxima_marca_minutos = int.Parse(oDataReader["Tiempo_proxima_marca_minutos"].ToString());
                        ConfiguracionParametrosDTO.Url_cabecera = oDataReader["Url_cabecera"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ConfiguracionParametrosDTO = null;
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ConfiguracionParametrosDTO;

        }


    }
}
