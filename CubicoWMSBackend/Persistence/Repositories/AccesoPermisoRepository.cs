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
    public class AccesoPermisoRepository : IAccesoPermisoRepository
    {

        private readonly AppDbContext _appDBContext;

        public AccesoPermisoRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<MensajeResultado> MantenimientoUsuario_CentroCosto(Usuario_CentroCostoDTO USUARIO_CENTROCOSTO)
        {
            var mensaje = getMantenimientoUsuario_CentroCosto(USUARIO_CENTROCOSTO);
            return mensaje;
        }

        public async Task<MensajeResultado> MantenimientoUsuario_TipoPersonal(Usuario_TipoPersonalDTO USUARIO_TIPOPERSONAL)
        {
            var mensaje = getMantenimientoUsuario_TipoPersonal(USUARIO_TIPOPERSONAL);
            return mensaje;
        }







        public MensajeResultado getMantenimientoUsuario_CentroCosto(Usuario_CentroCostoDTO USUARIO_CENTROCOSTO)
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
                    Sqlcmd.CommandText = "SP_TX_GRABAR_USUARIO_CENTRO_COSTO_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = USUARIO_CENTROCOSTO.id_user;
                    Sqlcmd.Parameters.Add("@COD_CENTRO_COSTO", SqlDbType.Int).Value = USUARIO_CENTROCOSTO.cod_centro_costo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = USUARIO_CENTROCOSTO.usuario;
                    

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
                    sex.Message, "AccesoPermisoRepository/getMantenimientoUsuario_CentroCosto(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "AccesoPermisoRepository/getMantenimientoUsuario_CentroCosto() EX." + ex, "Error");
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

        public MensajeResultado getMantenimientoUsuario_TipoPersonal(Usuario_TipoPersonalDTO USUARIO_TIPOPERSONAL)
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
                    Sqlcmd.CommandText = "SP_TX_GRABAR_USUARIO_CENTRO_COSTO_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = USUARIO_TIPOPERSONAL.id_user;
                    Sqlcmd.Parameters.Add("@COD_TIPO_PERSONAL", SqlDbType.Int).Value = USUARIO_TIPOPERSONAL.cod_Tipo_Personal;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = USUARIO_TIPOPERSONAL.usuario;


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
                    sex.Message, "AccesoPermisoRepository/getMantenimientoUsuario_CentroCosto(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "AccesoPermisoRepository/getMantenimientoUsuario_CentroCosto() EX." + ex, "Error");
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
