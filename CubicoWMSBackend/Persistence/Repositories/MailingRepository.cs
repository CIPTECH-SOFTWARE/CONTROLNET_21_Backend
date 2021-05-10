using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.Models;
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
    public class MailingRepository:IMailingRepository
    {
        private readonly AppDbContext _appDBContext;

        public MailingRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<MailingDTO>> ListaMailing()
        {
            var LISTA = getListaMailing();
            return LISTA;
        }

        public async Task<List<MailingDetalleDTO>> ListaOtrosCorreoMailing(int id_mailing, int tipo)
        {
            var LISTA = getListaOtrosCorreoMailing(id_mailing, tipo);
            return LISTA;
        }

        public async  Task<List<MailingDetalleDTO>> ListaOtrosMailing(int id_mailing, int tipo)
        {
            var LISTA = getListaOtrosMailing(id_mailing, tipo);
            return LISTA;
        }

        public async Task<List<ProcesoMailingDTO>> ListaProcesoMailing(int id_mailing)
        {
            var LISTA = getListaProcesoMailing(id_mailing);
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoMailing(MailingMantenimientoDTO Mailing)
        {
            var mensaje = getMantenimientoMailing(Mailing);
            return mensaje;
        }

        public async Task<List<ProcesoMailingDTO>> TipoProcesoMailing(int id_mailing)
        {
            var LISTA = getTipoProcesoMailing(id_mailing);
            return LISTA;
        }




        public List<MailingDTO> getListaMailing()
        {
            //ListaUsuarioEmpresaDTO = null;
            List<MailingDTO> ListaMailingDTO = new List<MailingDTO>();
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_CONFIGURACION_CORREO_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        MailingDTO MailingDTO = new MailingDTO();
                        MailingDTO.id_mailing = int.Parse(oDataReader["id_mailing"].ToString());
                        MailingDTO.tipo = int.Parse(oDataReader["tipo"].ToString());
                        MailingDTO.descripcion = oDataReader["descripcion"].ToString();
                        MailingDTO.descripcion_tipo = oDataReader["descripcion_tipo"].ToString();
                        MailingDTO.flag_participante =bool.Parse(oDataReader["flag_participante"].ToString());
                        MailingDTO.flag_responsable = bool.Parse(oDataReader["flag_responsable"].ToString());
                        MailingDTO.otros = bool.Parse(oDataReader["otros"].ToString());
                        MailingDTO.activo = bool.Parse(oDataReader["activo"].ToString());



                        ListaMailingDTO.Add(MailingDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MailingRepository/ListaMailingDTO(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MailingRepository/ListaMailingDTO() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaMailingDTO;
        }

        public List<MailingDetalleDTO> getListaOtrosCorreoMailing(int id_mailing, int tipo)
        {
            List<MailingDetalleDTO> ListaMailingDTO = new List<MailingDetalleDTO>();
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
                    Sqlcmd.CommandText = "SP_S_MAILING_OTROS_CORREO_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@id_mailing", SqlDbType.Int).Value = id_mailing;
                    Sqlcmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        MailingDetalleDTO MailingDetalleDTO = new MailingDetalleDTO();
                        MailingDetalleDTO.id_mailing = int.Parse(oDataReader["id_mailing"].ToString());
                        MailingDetalleDTO.tipo = int.Parse(oDataReader["tipo"].ToString());
                        MailingDetalleDTO.cod_personal = oDataReader["cod_personal"].ToString();
                        MailingDetalleDTO.nombre_completo_persona = oDataReader["nombre_completo_persona"].ToString();
                        MailingDetalleDTO.email =oDataReader["email"].ToString();
                        MailingDetalleDTO.flag_personal = bool.Parse(oDataReader["flag_personal"].ToString());
                     
                        ListaMailingDTO.Add(MailingDetalleDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MailingRepository/getListaOtrosCorreoMailing(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MailingRepository/getListaOtrosCorreoMailing() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaMailingDTO;
        }

        public List<MailingDetalleDTO> getListaOtrosMailing(int id_mailing, int tipo)
        {
            List<MailingDetalleDTO> ListaMailingDTO = new List<MailingDetalleDTO>();
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
                    Sqlcmd.CommandText = "SP_S_OTROS_MAILING_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@id_mailing", SqlDbType.Int).Value = id_mailing;
                    Sqlcmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        MailingDetalleDTO MailingDetalleDTO = new MailingDetalleDTO();
                        MailingDetalleDTO.id_mailing = int.Parse(oDataReader["id_mailing"].ToString());
                        MailingDetalleDTO.email = oDataReader["email"].ToString();
                        MailingDetalleDTO.nombre_completo_persona = oDataReader["nombre_completo_persona"].ToString();
                        MailingDetalleDTO.flag_personal = bool.Parse(oDataReader["flag_personal"].ToString());
                        MailingDetalleDTO.cod_personal = oDataReader["cod_personal"].ToString();
                        ListaMailingDTO.Add(MailingDetalleDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MailingRepository/getListaOtrosMailing(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MailingRepository/getListaOtrosMailing() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaMailingDTO;
        }

        public List<ProcesoMailingDTO> getListaProcesoMailing(int id_mailing)
        {
            List<ProcesoMailingDTO> ListaProcesosMailingDTO = new List<ProcesoMailingDTO>();
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
                    Sqlcmd.CommandText = "SP_S_PROCESO_MAILING_21";
                    //Sqlcmd.Parameters.Clear();
                    //Sqlcmd.Parameters.Add("@id_mailing", SqlDbType.Int).Value = id_mailing;
                  
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        ProcesoMailingDTO ProcesoMailingDTO = new ProcesoMailingDTO();
                        ProcesoMailingDTO.cod_perfil_trabajo = int.Parse(oDataReader["ID_PROCESO_MAILING"].ToString());
                        ProcesoMailingDTO.descripcion = oDataReader["descripcion"].ToString();

                        ListaProcesosMailingDTO.Add(ProcesoMailingDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MailingRepository/getListaProcesoMailing(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MailingRepository/getListaProcesoMailing() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaProcesosMailingDTO;
        }

        public MensajeResultado getMantenimientoMailing(MailingMantenimientoDTO Mailing)
        {
            MensajeResultado MensajeResultado = new MensajeResultado();
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
                    Sqlcmd.CommandText = "SP_TX_ACTUALIZAR_MAILING_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = Mailing.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@ID_MAILING", SqlDbType.Int).Value = Mailing.id_mailing;
                    Sqlcmd.Parameters.Add("@ID_TIPO", SqlDbType.Int).Value = Mailing.id_tipo;
                    Sqlcmd.Parameters.Add("@FLAG_PARTICIPANTE", SqlDbType.Bit).Value = Mailing.flag_participante;
                    Sqlcmd.Parameters.Add("@FLAG_RESPONSABLE", SqlDbType.Bit).Value = Mailing.flag_responsable;
                    Sqlcmd.Parameters.Add("@OTROS", SqlDbType.Bit).Value = Mailing.otros;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = Mailing.id_user;
                    Sqlcmd.Parameters.Add("@Flag_Activo", SqlDbType.Bit).Value = Mailing.activo;


                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {

                        MensajeResultado.mensaje = oDataReader["mensaje"].ToString();
                        MensajeResultado.resultado = int.Parse(oDataReader["resultado"].ToString());

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MailingRepository/getMantenimientoMailing(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MailingRepository/getMantenimientoMailing() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return MensajeResultado;
        }

        public List<ProcesoMailingDTO> getTipoProcesoMailing(int id_mailing)
        {
            List<ProcesoMailingDTO> ListaTipoProcesosMailingDTO = new List<ProcesoMailingDTO>();
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
                    Sqlcmd.CommandText = "SP_S_TIPOS_PROCESO_MAILING_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@id_mailing", SqlDbType.Int).Value = id_mailing;

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        ProcesoMailingDTO ProcesoMailingDTO = new ProcesoMailingDTO();
                        ProcesoMailingDTO.cod_perfil_trabajo = int.Parse(oDataReader["cod_perfil_trabajo"].ToString());
                        ProcesoMailingDTO.descripcion = oDataReader["descripcion"].ToString();

                        ListaTipoProcesosMailingDTO.Add(ProcesoMailingDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MailingRepository/getListaTipoProcesoMailing(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MailingRepository/getListaTipoProcesoMailing() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTipoProcesosMailingDTO;
        }
    }
}
