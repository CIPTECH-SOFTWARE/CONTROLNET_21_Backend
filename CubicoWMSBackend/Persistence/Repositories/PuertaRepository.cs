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
    public class PuertaRepository:IPuertaRepository
    {

        private readonly AppDbContext _appDBContext;
        public PuertaRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<PuertaDTO>> ListarPuerta()
        {
            var LISTA = getListarPuerta();
            return LISTA;
        }

        public async Task<List<PuertaArbol_extDTO>> ListarPuerta_ArbolExt()
        {
            var LISTA = getListarPuerta_ArbolExt();
            return LISTA;
        }

        public async Task<List<PuertaArbolDTO>> ListarPuerta_Arbol()
        {
            var LISTA = getListarPuerta_Arbol();
            return LISTA;
        }

        public async Task<List<PuertaPisoDTO>> ListarPuerta_X_Piso(int COD_PISO)
        {
            var LISTA = getListarPuerta_X_Piso(COD_PISO);
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoPuerta(PuertaMantenimientoDTO PUERTA)
        {
            var MENSAJE = getMantenimientoPuerta(PUERTA);
            return MENSAJE;
        }



        public List<PuertaDTO> getListarPuerta()
        {
            List<PuertaDTO> ListaPuertaDTO = new List<PuertaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Puerta_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PuertaDTO PuertaDTO = new PuertaDTO();
                        PuertaDTO.COD_PUERTA = int.Parse(oDataReader["COD_PUERTA"].ToString());
                        PuertaDTO.COD_PISO = int.Parse(oDataReader["COD_PISO"].ToString());
                        PuertaDTO.COD_EDIFICIO = int.Parse(oDataReader["COD_EDIFICIO"].ToString());
                        PuertaDTO.DES_EDIFICIO = oDataReader["DES_EDIFICIO"].ToString();
                        PuertaDTO.DES_PISO = oDataReader["DES_PISO"].ToString();
                        PuertaDTO.NUM_PISO = oDataReader["NUM_PISO"].ToString();
                        PuertaDTO.DES_PUERTA = oDataReader["DES_PUERTA"].ToString();
                        PuertaDTO.NUM_PUERTA = oDataReader["NUM_PUERTA"].ToString();
                        PuertaDTO.IP = oDataReader["IP"].ToString();
                        PuertaDTO.USER_FTP = oDataReader["USER_FTP"].ToString();
                        PuertaDTO.PASS_FTP = oDataReader["PASS_FTP"].ToString();
                        PuertaDTO.FLAG_ANONIMUS_FTP = bool.Parse(oDataReader["FLAG_ANONIMUS_FTP"].ToString());
                        PuertaDTO.ACTIVO = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PuertaDTO.Ruta_Origen_FTP = oDataReader["Ruta_Origen_FTP"].ToString();

                        ListaPuertaDTO.Add(PuertaDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PuertaRepository/getListarPuerta(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EdificioRepository/getListarPuerta() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPuertaDTO;
        }

        public List<PuertaArbol_extDTO> getListarPuerta_ArbolExt()
        {
            List<PuertaArbol_extDTO> ListaPuertaArbol_extDTO = new List<PuertaArbol_extDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Arbol_Puerta_New_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PuertaArbol_extDTO PuertaArbol_extDTO = new PuertaArbol_extDTO();
                        PuertaArbol_extDTO.cod_sede = int.Parse(oDataReader["COD_SEDE"].ToString());
                        PuertaArbol_extDTO.des_sede = oDataReader["DES_SEDE"].ToString();
                        PuertaArbol_extDTO.direccion = oDataReader["DIRECCION"].ToString();
                        PuertaArbol_extDTO.cod_empresa = int.Parse(oDataReader["COD_EMPRESA"].ToString());
                        PuertaArbol_extDTO.des_empresa = oDataReader["DES_EMPRESA"].ToString();
                       
                        PuertaArbol_extDTO.sede_padre = int.Parse(oDataReader["SEDE_PADRE"].ToString());
                        PuertaArbol_extDTO.cod_edificio = int.Parse(oDataReader["COD_EDIFICIO"].ToString());
                        PuertaArbol_extDTO.des_edificio = oDataReader["DES_EDIFICIO"].ToString();
                        PuertaArbol_extDTO.edificio_padre = int.Parse(oDataReader["EDIFICIO_PADRE"].ToString());
                        PuertaArbol_extDTO.cod_piso = int.Parse(oDataReader["COD_PISO"].ToString());
                        PuertaArbol_extDTO.des_piso = oDataReader["DES_PISO"].ToString();
                        

                        ListaPuertaArbol_extDTO.Add(PuertaArbol_extDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PuertaRepository/getListarPuerta_ArbolExt(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PuertaRepository/getListarPuerta_ArbolExt() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPuertaArbol_extDTO;
        }

        public List<PuertaArbolDTO> getListarPuerta_Arbol()
        {
            List<PuertaArbolDTO> ListaPuertaArbolDTO = new List<PuertaArbolDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Arbol_Puerta_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PuertaArbolDTO PuertaArbolDTO = new PuertaArbolDTO();
                        PuertaArbolDTO.cod_edificio = int.Parse(oDataReader["COD_EDIFICIO"].ToString());
                        PuertaArbolDTO.cod_piso = int.Parse(oDataReader["DES_EDIFICIO"].ToString());
                        PuertaArbolDTO.des_direccion = oDataReader["DES_DIRECCION"].ToString();
                        PuertaArbolDTO.des_edificio = oDataReader["COD_PISO"].ToString();
                        PuertaArbolDTO.des_piso = oDataReader["DES_PISO"].ToString();
                        PuertaArbolDTO.num_piso = oDataReader["SEDE_PADRE"].ToString();
                       
                        ListaPuertaArbolDTO.Add(PuertaArbolDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PuertaRepository/getListarPuerta_Arbol(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EdificioRepository/getListarPuerta_Arbol() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPuertaArbolDTO;
        }

        public List<PuertaPisoDTO> getListarPuerta_X_Piso(int COD_PISO)
        {
            List<PuertaPisoDTO> ListaPuertaPisoDTO = new List<PuertaPisoDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Puerta_X_Piso_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Piso", SqlDbType.Int).Value = COD_PISO;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PuertaPisoDTO PuertaPisoDTO = new PuertaPisoDTO();
                        PuertaPisoDTO.cod_puerta = int.Parse(oDataReader["COD_PUERTA"].ToString());
                        PuertaPisoDTO.cod_piso = int.Parse(oDataReader["COD_PISO"].ToString());
                        PuertaPisoDTO.cod_sede = int.Parse(oDataReader["COD_SEDE"].ToString());
                        PuertaPisoDTO.des_sede = oDataReader["DES_SEDE"].ToString();
                        PuertaPisoDTO.cod_edificio = int.Parse(oDataReader["COD_EDIFICIO"].ToString());
                        PuertaPisoDTO.des_edificio = oDataReader["DES_EDIFICIO"].ToString();
                        PuertaPisoDTO.des_piso = oDataReader["DES_PISO"].ToString();
                        PuertaPisoDTO.num_piso = oDataReader["NUM_PISO"].ToString();
                        PuertaPisoDTO.des_puerta = oDataReader["DES_PUERTA"].ToString();
                        PuertaPisoDTO.num_puerta = oDataReader["NUM_PUERTA"].ToString();
                        PuertaPisoDTO.ip = oDataReader["IP"].ToString();
                        PuertaPisoDTO.user_ftp = oDataReader["USER_FTP"].ToString();
                        PuertaPisoDTO.pass_ftp = oDataReader["PASS_FTP"].ToString();
                        PuertaPisoDTO.flag_anonimus_ftp = bool.Parse(oDataReader["FLAG_ANONIMUS_FTP"].ToString());
                        PuertaPisoDTO.fecha_inicio = DateTime.Parse(oDataReader["fecha_Inicio"].ToString());
                        PuertaPisoDTO.fecha_fin = DateTime.Parse(oDataReader["fecha_Fin"].ToString());
                        PuertaPisoDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PuertaPisoDTO.ingreso_sede = bool.Parse(oDataReader["INGRESO_SEDE"].ToString());

                        ListaPuertaPisoDTO.Add(PuertaPisoDTO);
                    }
                }
            }
            catch (SqlException sex)
            {
                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PuertaRepository/getListarPuerta_X_Piso(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EdificioRepository/getListarPuerta_X_Piso() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPuertaPisoDTO;
        }

        public MensajeResultado getMantenimientoPuerta(PuertaMantenimientoDTO PUERTA)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Puerta_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = PUERTA.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Puerta", SqlDbType.Int).Value = PUERTA.Cod_Puerta;
                    Sqlcmd.Parameters.Add("@Cod_Piso", SqlDbType.Int).Value = PUERTA.Cod_Piso;
                    Sqlcmd.Parameters.Add("@Des_Puerta", SqlDbType.VarChar, 100).Value = PUERTA.Des_Puerta;
                    Sqlcmd.Parameters.Add("@Num_Puerta", SqlDbType.VarChar, 5).Value = PUERTA.Num_Puerta;
                    Sqlcmd.Parameters.Add("@IP", SqlDbType.VarChar,15).Value = PUERTA.Ip;
                    Sqlcmd.Parameters.Add("@User_Ftp", SqlDbType.VarChar, 100).Value = PUERTA.User_Ftp;
                    Sqlcmd.Parameters.Add("@Pass_Ftp", SqlDbType.VarChar, 100).Value = PUERTA.Pass_Ftp;
                    Sqlcmd.Parameters.Add("@Flag_Anonimus_Ftp", SqlDbType.Bit).Value = PUERTA.Flag_Anonimus_Ftp;
                    Sqlcmd.Parameters.Add("@Fecha_Inicio", SqlDbType.DateTime).Value = PUERTA.Fecha_Inicio;
                    Sqlcmd.Parameters.Add("@Fecha_Fin", SqlDbType.DateTime).Value = PUERTA.Fecha_Fin;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = PUERTA.id_user;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Int).Value = PUERTA.Activo;


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
                    sex.Message, "EdificioRepository/getMantenimientoEdificio(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PuertaRepository/getMantenimientoPuerta() EX." + ex, "Error");
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

    }
}
