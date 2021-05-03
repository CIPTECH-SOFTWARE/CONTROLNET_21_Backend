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
    public class TipoPersonalRepository : ITipoPersonalRepository
    {

        private readonly AppDbContext _appDBContext;
        public TipoPersonalRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<TipoPersonalDTO>> ListarTipoPersonal()
        {
            var LISTA = getListarTipoPersonal();
            return LISTA;
        }

        public async Task<List<TipoPersonalDTO>> ListarTipoPersonal_X_filtro(string filtro)
        {
            var LISTA = getListarTipoPersonal_X_filtro(filtro);
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoTipoPersonal(TipoPersonalMantenimientoDTO TIPO_PERSONAL)
        {
            var mensaje = getMantenimientoTipoPersonal(TIPO_PERSONAL);
            return mensaje;
        }

           

        public List<TipoPersonalDTO> getListarTipoPersonal()
        {
            List<TipoPersonalDTO> ListaTipoPersonalDTO = new List<TipoPersonalDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_TIPO_PERSONAL_21";
                    // Sqlcmd.Parameters.Clear();
                    // Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TipoPersonalDTO TipoPersonalDTO = new TipoPersonalDTO();
                        TipoPersonalDTO.cod_tipo_personal = int.Parse(oDataReader["cod_hid"].ToString());
                        TipoPersonalDTO.des_tipo_personal = oDataReader["des_hid"].ToString();
                        TipoPersonalDTO.flag_activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        TipoPersonalDTO.cod_tipo_personal_ext = oDataReader["id_grupo_hid"].ToString();

                        ListaTipoPersonalDTO.Add(TipoPersonalDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TipoPersonalRepository/getListarTipoPersonal(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoPersonalRepository/getListarTipoPersonal() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTipoPersonalDTO;
        }

        public List<TipoPersonalDTO> getListarTipoPersonal_X_filtro(string filtro)
        {
            List<TipoPersonalDTO> ListaTipoPersonalDTO = new List<TipoPersonalDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_tipo_personal_X_Filtro_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@param_tipo_personal", SqlDbType.VarChar,400).Value = filtro;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TipoPersonalDTO TipoPersonalDTO = new TipoPersonalDTO();
                        TipoPersonalDTO.cod_tipo_personal = int.Parse(oDataReader["cod_hid"].ToString());
                        TipoPersonalDTO.des_tipo_personal = oDataReader["des_hid"].ToString();
                        TipoPersonalDTO.flag_activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        TipoPersonalDTO.cod_tipo_personal_ext = oDataReader["id_grupo_hid"].ToString();

                        ListaTipoPersonalDTO.Add(TipoPersonalDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TipoPersonalRepository/getListarTipoPersonal(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoPersonalRepository/getListarTipoPersonal() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTipoPersonalDTO;
        }

        public MensajeResultado getMantenimientoTipoPersonal(TipoPersonalMantenimientoDTO TIPO_PERSONAL)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_TIPO_PERSONAL_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = TIPO_PERSONAL.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@COD_TIPO_PERSONA", SqlDbType.Int).Value = TIPO_PERSONAL.cod_tipo_personal;
                    Sqlcmd.Parameters.Add("@COD_TIPO_PERSONAL_EXT", SqlDbType.VarChar, 10).Value = TIPO_PERSONAL.cod_tipo_personal_ext;
                    Sqlcmd.Parameters.Add("@DES_TIPO_PERSONAL", SqlDbType.Int).Value = TIPO_PERSONAL.des_tipo_personal;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = TIPO_PERSONAL.flag_activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = TIPO_PERSONAL.id_user;

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
                    sex.Message, "TipoPersonalRepository/getMantenimientoTipoPersonal(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoPersonalRepository/getMantenimientoTipoPersonal() EX." + ex, "Error");
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
