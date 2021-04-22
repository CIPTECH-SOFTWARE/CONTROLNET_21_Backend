using CubicoWMSBackend.Domain.IRepositories;
using ControlNetBackend.Domain.Models;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using ControlNetBackend.DTO;
namespace CubicoWMSBackend.Persistence.Repositories
{
    public class UsuarioRepository:IUsuarioRepository

    {
        private readonly AppDbContext _appDBContext;
        public UsuarioRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _appDBContext.Add(usuario);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task UpdatePassword(Usuario usuario)
        {
            _appDBContext.Update(usuario);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistence(Usuario usuario)
        {
            var validateExistence = await _appDBContext.Usuarios.AnyAsync(x => x.NombreUsuario == usuario.NombreUsuario);
            return validateExistence;

        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _appDBContext.Usuarios.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }
        public async Task<UsuarioDTO> RecuperarPassword(string COD_USUARIO)
        {
            var user =  getRecuperarPassword(COD_USUARIO);
            return user;

        }
        public async Task<MensajeResultado> Valida_NuevoUsuario(string COD_USUARIO,string NOM_USUARIO)
        {
            var mensaje = getValida_NuevoUsuario(COD_USUARIO,NOM_USUARIO);
            return mensaje;

        }

        public async Task<MensajeResultado> Grabar_Usuario_Login(string cod_personal, string nombre_usuario, string email, string cod_usuario, int cod_sede)
        {
            var mensaje = getGrabar_Usuario_Login(cod_personal,  nombre_usuario,  email,  cod_usuario,  cod_sede);
            return mensaje;

        }
        private UsuarioDTO getRecuperarPassword(string COD_USUARIO)
        {


            UsuarioDTO UsuarioDTO = new UsuarioDTO();
            UsuarioDTO = null;
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Recuperar_Password_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Usuario", SqlDbType.VarChar, 100).Value = COD_USUARIO;
                   
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        UsuarioDTO = new UsuarioDTO();
                        UsuarioDTO.nom_usuario= oDataReader["NOM_USUARIO"].ToString();
                        UsuarioDTO.cod_usuario = oDataReader["COD_USUARIO"].ToString();
                        UsuarioDTO.email = oDataReader["EMAIL"].ToString(); 
                        UsuarioDTO.Des_Pass_Recuperacion = oDataReader["Des_Pass_Recuperacion"].ToString();
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "UsuarioRepository/getRecuperarPassword(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getRecuperarPassword() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return UsuarioDTO;

        }

        private MensajeResultado getValida_NuevoUsuario(string COD_USUARIO,string NOM_USUARIO)
        {


            MensajeResultado MENSAJE = new MensajeResultado();
            MENSAJE = null;
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Valida_NuevoUsuario_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Usuario", SqlDbType.VarChar, 20).Value = COD_USUARIO;
                    Sqlcmd.Parameters.Add("@Nom_Usuario", SqlDbType.VarChar, 50).Value = NOM_USUARIO;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        MENSAJE = new MensajeResultado();
                        MENSAJE.mensaje = oDataReader["MENSAJE"].ToString();
                        MENSAJE.resultado = int.Parse(oDataReader["RESULTADO"].ToString());
                       
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "UsuarioRepository/getValida_NuevoUsuario(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getValida_NuevoUsuario() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return MENSAJE;

        }

        private MensajeResultado getGrabar_Usuario_Login(string cod_personal, string nombre_usuario, string email, string cod_usuario, int cod_sede)
        {


            MensajeResultado MENSAJE = new MensajeResultado();
            MENSAJE = null;
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_TX_Grabar_Usuario_Login_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Usuario", SqlDbType.VarChar, 20).Value = cod_usuario;
                    Sqlcmd.Parameters.Add("@Nom_Usuario", SqlDbType.VarChar, 50).Value = nombre_usuario;
                    Sqlcmd.Parameters.Add("@Cod_Personal", SqlDbType.VarChar, 50).Value = cod_personal;
                    Sqlcmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = cod_sede;



                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        MENSAJE = new MensajeResultado();
                        MENSAJE.mensaje = oDataReader["MENSAJE"].ToString();
                        MENSAJE.resultado = int.Parse(oDataReader["RESULTADO"].ToString());

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "UsuarioRepository/getGrabar_Usuario_Login(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getGrabar_Usuario_Login() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return MENSAJE;

        }
    }
}
