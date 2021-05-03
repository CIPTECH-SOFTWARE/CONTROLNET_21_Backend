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
    public class TarjetaAccesoRepository : ITarjetaAccesoRepository
    {
        private readonly AppDbContext _appDBContext;
        public TarjetaAccesoRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso()
        {
            var LISTA = getListarTarjetaAcceso();
            return LISTA;
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_Filtro(string filtro,int cod_grupo_acceso)
        {
            var LISTA = getListarTarjetaAcceso_Filtro(filtro,cod_grupo_acceso);
            return LISTA;
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_GA(int cod_empresa, int cod_grupoAcceso)
        {
            var LISTA = getListarTarjetaAcceso_GA(cod_empresa, cod_grupoAcceso);
            return LISTA;
        }

        public async Task<List<TarjetaAccesoDTO>> ListarTarjetaAcceso_X_Empresa(int cod_empresa)
        {
            var LISTA = getListarTarjetaAcceso_X_Empresa(cod_empresa);
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientTarjetaAcceso(TarjetaAccesoMantenimientoDTO TARJETA)
        {
            var mensaje = getMantenimientTarjetaAcceso(TARJETA);
            return mensaje;
        }


        public List<TarjetaAccesoDTO> getListarTarjetaAcceso()
        {
            List<TarjetaAccesoDTO> ListaTarjetaAccesoDTO = new List<TarjetaAccesoDTO>();
           
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Tarjeta_HID_21";
                   // Sqlcmd.Parameters.Clear();
                   // Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TarjetaAccesoDTO TarjetaAccesoDTO = new TarjetaAccesoDTO();
                        TarjetaAccesoDTO.cod_hid = int.Parse(oDataReader["cod_hid"].ToString());
                        TarjetaAccesoDTO.des_hid = oDataReader["des_hid"].ToString();
                        TarjetaAccesoDTO.num_hid = oDataReader["num_hid"].ToString();
                        TarjetaAccesoDTO.id_grupo_hid = int.Parse(oDataReader["id_grupo_hid"].ToString());
                        TarjetaAccesoDTO.descripcion = oDataReader["descripcion"].ToString();
                        TarjetaAccesoDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        TarjetaAccesoDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        TarjetaAccesoDTO.hid_activo = bool.Parse(oDataReader["hid_activo"].ToString());
                        TarjetaAccesoDTO.activo = bool.Parse(oDataReader["activo"].ToString());
                        ListaTarjetaAccesoDTO.Add(TarjetaAccesoDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TarjetaAccesoRepository/getListarSede_x_Empresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TarjetaAccesoRepository/getListarSede_x_Empresa() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTarjetaAccesoDTO;
        }

        public  List<TarjetaAccesoDTO> getListarTarjetaAcceso_Filtro(string filtro, int cod_grupo_acceso)
        {
            List<TarjetaAccesoDTO> ListaTarjetaAccesoDTO = new List<TarjetaAccesoDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Tarjeta_HID_X_Filtro_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@param_tarjeta", SqlDbType.VarChar,400).Value = filtro;
                    Sqlcmd.Parameters.Add("@id_GrupoHid", SqlDbType.Int).Value = cod_grupo_acceso;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TarjetaAccesoDTO TarjetaAccesoDTO = new TarjetaAccesoDTO();
                        TarjetaAccesoDTO.cod_hid = int.Parse(oDataReader["cod_hid"].ToString());
                        TarjetaAccesoDTO.des_hid = oDataReader["des_hid"].ToString();
                        TarjetaAccesoDTO.num_hid = oDataReader["num_hid"].ToString();
                        TarjetaAccesoDTO.id_grupo_hid = int.Parse(oDataReader["id_grupo_hid"].ToString());
                        TarjetaAccesoDTO.descripcion = oDataReader["descripcion"].ToString();
                        TarjetaAccesoDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        TarjetaAccesoDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        TarjetaAccesoDTO.hid_activo = bool.Parse(oDataReader["hid_activo"].ToString());
                        TarjetaAccesoDTO.activo = bool.Parse(oDataReader["activo"].ToString());
                        
                        ListaTarjetaAccesoDTO.Add(TarjetaAccesoDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TarjetaAccesoRepository/getListarTarjetaAcceso_Filtro(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TarjetaAccesoRepository/getListarTarjetaAcceso_Filtro() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTarjetaAccesoDTO;
        }

        public List<TarjetaAccesoDTO> getListarTarjetaAcceso_GA(int cod_empresa, int cod_grupoAcceso)
        {
            List<TarjetaAccesoDTO> ListaTarjetaAccesoDTO = new List<TarjetaAccesoDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Tarjeta_HID_X_GHID_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_GHid", SqlDbType.Int).Value = cod_grupoAcceso;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = cod_empresa;
                    
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TarjetaAccesoDTO TarjetaAccesoDTO = new TarjetaAccesoDTO();
                        TarjetaAccesoDTO.cod_hid = int.Parse(oDataReader["cod_hid"].ToString());
                        TarjetaAccesoDTO.des_hid = oDataReader["des_hid"].ToString();
                        TarjetaAccesoDTO.num_hid = oDataReader["num_hid"].ToString();
                        TarjetaAccesoDTO.id_grupo_hid = int.Parse(oDataReader["id_grupo_hid"].ToString());
                        TarjetaAccesoDTO.descripcion = oDataReader["descripcion"].ToString();
                        TarjetaAccesoDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        TarjetaAccesoDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        TarjetaAccesoDTO.hid_activo = bool.Parse(oDataReader["hid_activo"].ToString());
                        TarjetaAccesoDTO.activo = bool.Parse(oDataReader["activo"].ToString());

                        ListaTarjetaAccesoDTO.Add(TarjetaAccesoDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TarjetaAccesoRepository/getListarTarjetaAcceso_GA(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TarjetaAccesoRepository/getListarTarjetaAcceso_GA() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTarjetaAccesoDTO;

        }

        public List<TarjetaAccesoDTO> getListarTarjetaAcceso_X_Empresa(int cod_empresa)
        {
            List<TarjetaAccesoDTO> ListaTarjetaAccesoDTO = new List<TarjetaAccesoDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Tarjeta_HID_X_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = cod_empresa;

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TarjetaAccesoDTO TarjetaAccesoDTO = new TarjetaAccesoDTO();
                        TarjetaAccesoDTO.cod_hid = int.Parse(oDataReader["cod_hid"].ToString());
                        TarjetaAccesoDTO.des_hid = oDataReader["des_hid"].ToString();
                        TarjetaAccesoDTO.num_hid = oDataReader["num_hid"].ToString();
                        TarjetaAccesoDTO.id_grupo_hid = int.Parse(oDataReader["id_grupo_hid"].ToString());
                        TarjetaAccesoDTO.descripcion = oDataReader["descripcion"].ToString();
                        TarjetaAccesoDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        TarjetaAccesoDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        TarjetaAccesoDTO.hid_activo = bool.Parse(oDataReader["hid_activo"].ToString());
                        TarjetaAccesoDTO.activo = bool.Parse(oDataReader["activo"].ToString());

                        ListaTarjetaAccesoDTO.Add(TarjetaAccesoDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TarjetaAccesoRepository/getListarTarjetaAcceso_X_Empresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TarjetaAccesoRepository/getListarTarjetaAcceso_X_Empresa() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTarjetaAccesoDTO;
        }

        public MensajeResultado getMantenimientTarjetaAcceso(TarjetaAccesoMantenimientoDTO TARJETA)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Tarjeta_HID_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = TARJETA.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Hid", SqlDbType.Int).Value = TARJETA.cod_hid;
                    Sqlcmd.Parameters.Add("@Des_Hid", SqlDbType.VarChar,100).Value = TARJETA.des_hid;
                    Sqlcmd.Parameters.Add("@Id_Grupo_Hid", SqlDbType.Int).Value = TARJETA.id_grupo_hid;
                    Sqlcmd.Parameters.Add("@Hid_Activo", SqlDbType.Bit).Value = TARJETA.hid_activo;
                    Sqlcmd.Parameters.Add("@Num_Hid", SqlDbType.VarChar, 50).Value = TARJETA.num_hid;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = TARJETA.cod_sede;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = TARJETA.activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = TARJETA.id_user;

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
                    sex.Message, "TarjetaAccesoRepository/getMantenimientTarjetaAcceso(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TarjetaAccesoRepository/getMantenimientTarjetaAcceso() EX." + ex, "Error");
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
