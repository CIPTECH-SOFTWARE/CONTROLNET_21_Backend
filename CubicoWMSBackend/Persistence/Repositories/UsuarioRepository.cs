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
        
        
        
        public async Task<List<UsuarioDTO>> ListarUsuario()
        {
            var LISTA= getListarUsuario();
            return LISTA;
        }
        public async Task<List<UsuarioDTO>> ListarUsuario_x_perfil(int ID_PERFIL)
        {
            var LISTA = getListarUsuario_x_perfil(ID_PERFIL);
            return LISTA;
        }
        public async Task<List<UsuarioDTO>> ListarUsuario_Codigo_filtro(string COD_USUARIO)
        {
            var LISTA = getListarUsuario_Codigo_filtro(COD_USUARIO);
            return LISTA;
        }
        public async Task<MensajeResultado> Cambio_PasswordUsuario(Usuario_PasswordDTO USUARIO)
        {
            var mensaje = getCambio_PasswordUsuario(USUARIO);
            return mensaje;
        }
        public async Task<MensajeResultado> Grabar_Usuario(UsuarioMantenimientoDTO usuario)
        {
            var mensaje = getGrabar_Usuario(usuario);
            return mensaje;
        }
        public async Task<MensajeResultado> Grabar_UsuarioEmpresa(Usuario_EmpresaDTO USUARIO_EMPRESA)
        {
            var mensaje = getGrabar_UsuarioEmpresa(USUARIO_EMPRESA);
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
                        UsuarioDTO.des_pass_recuperacion = oDataReader["Des_Pass_Recuperacion"].ToString();
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


        public List<UsuarioDTO> getListarUsuario()
        {
            List<UsuarioDTO> ListaUsuarioDTO = new List<UsuarioDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Usuario_21";
                    //Sqlcmd.Parameters.Clear();
                    //Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        UsuarioDTO UsuarioDTO = new UsuarioDTO();
                        UsuarioDTO.id_user = int.Parse(oDataReader["id_user"].ToString());
                        UsuarioDTO.cod_usuario = oDataReader["cod_usuariocod_usuario"].ToString();
                        UsuarioDTO.nom_usuario = oDataReader["nom_usuario"].ToString();
                        UsuarioDTO.des_Password= oDataReader["des_Password"].ToString();
                        UsuarioDTO.des_Pass = oDataReader["des_Pass"].ToString();
                        UsuarioDTO.ind_activo = bool.Parse(oDataReader["ind_activo"].ToString());
                        UsuarioDTO.id_perfil = int.Parse(oDataReader["id_perfil"].ToString());
                        UsuarioDTO.email = oDataReader["email"].ToString();
                        UsuarioDTO.des_perfil = oDataReader["des_perfil"].ToString();
                        UsuarioDTO.cod_personal = oDataReader["cod_personal"].ToString();
                        UsuarioDTO.flag_ad = bool.Parse(oDataReader["flag_ad"].ToString());
                        UsuarioDTO.nom_personal = oDataReader["nom_personal"].ToString();
                        ListaUsuarioDTO.Add(UsuarioDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "UsuarioRepository/getListarUsuario(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getListarUsuario() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaUsuarioDTO;
        }
        public List<UsuarioDTO> getListarUsuario_x_perfil(int ID_PERFIL)
        {
           
                List<UsuarioDTO> ListaUsuarioDTO = new List<UsuarioDTO>();
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
                        Sqlcmd.CommandText = "SP_S_Listar_Usuario_X_Perfil_21";
                        //Sqlcmd.Parameters.Clear();
                        //Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                        SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                        while (oDataReader.Read())
                        {
                            UsuarioDTO UsuarioDTO = new UsuarioDTO();
                            UsuarioDTO.id_user = int.Parse(oDataReader["id_user"].ToString());
                            UsuarioDTO.cod_usuario = oDataReader["cod_usuario"].ToString();
                            UsuarioDTO.nom_usuario = oDataReader["nom_usuario"].ToString();
                            UsuarioDTO.id_perfil = int.Parse(oDataReader["id_perfil"].ToString());
                            UsuarioDTO.ind_activo = bool.Parse(oDataReader["ind_activo"].ToString());
                            ListaUsuarioDTO.Add(UsuarioDTO);

                        }
                    }
                }
                catch (SqlException sex)
                {

                    eErrorLog mensajeLogError = new eErrorLog(
                        sex.Message, "UsuarioRepository/getListarUsuario_x_perfil(). SQL." + sex, "Error Sql");
                    mensajeLogError.RegisterLog();
                }
                catch (Exception ex)
                {
                    eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getListarUsuario_x_perfil() EX." + ex, "Error");
                    mensajeLogError.RegisterLog();
                }
                finally
                {
                    if (cnx.State == System.Data.ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                }


                return ListaUsuarioDTO;
            
        }
        public List<UsuarioDTO> getListarUsuario_Codigo_filtro(string COD_USUARIO)
        {
           
                List<UsuarioDTO> ListaUsuarioDTO = new List<UsuarioDTO>();
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
                        Sqlcmd.CommandText = "SP_S_Listar_Usuario_codigo_filtro_21";
                        //Sqlcmd.Parameters.Clear();
                        //Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                        SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                        while (oDataReader.Read())
                        {
                            UsuarioDTO UsuarioDTO = new UsuarioDTO();
                            UsuarioDTO.id_user = int.Parse(oDataReader["id_user"].ToString());
                            UsuarioDTO.cod_usuario = oDataReader["cod_usuariocod_usuario"].ToString();
                            UsuarioDTO.nom_usuario = oDataReader["nom_usuario"].ToString();
                            UsuarioDTO.nom_personal = oDataReader["nom_personal"].ToString();
                            ListaUsuarioDTO.Add(UsuarioDTO);

                        }
                    }
                }
                catch (SqlException sex)
                {

                    eErrorLog mensajeLogError = new eErrorLog(
                        sex.Message, "UsuarioRepository/getListarUsuario_Codigo_filtro(). SQL." + sex, "Error Sql");
                    mensajeLogError.RegisterLog();
                }
                catch (Exception ex)
                {
                    eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getListarUsuario_Codigo_filtro() EX." + ex, "Error");
                    mensajeLogError.RegisterLog();
                }
                finally
                {
                    if (cnx.State == System.Data.ConnectionState.Open)
                    {
                        cnx.Close();
                    }
                }


                return ListaUsuarioDTO;
            }
        public MensajeResultado getCambio_PasswordUsuario(Usuario_PasswordDTO USUARIO)
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
                    Sqlcmd.CommandText = "SP_TX_Usuario_Cambio_password_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@CodUsuario", SqlDbType.VarChar,20).Value = USUARIO.cod_usuario;
                    Sqlcmd.Parameters.Add("@Des_Password", SqlDbType.VarChar,15).Value = USUARIO.des_Password;
                    Sqlcmd.Parameters.Add("@Old_Password", SqlDbType.VarChar, 15).Value = USUARIO.old_Password;
                   

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
                    sex.Message, "UsuarioRepository/getCambio_PasswordUsuario(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getCambio_PasswordUsuario() EX." + ex, "Error");
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
        public MensajeResultado getGrabar_Usuario(UsuarioMantenimientoDTO USUARIO)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Usuario_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = USUARIO.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = USUARIO.id_user;
                    Sqlcmd.Parameters.Add("@Cod_Usuario", SqlDbType.VarChar, 20).Value = USUARIO.cod_usuario;
                    Sqlcmd.Parameters.Add("@Nom_Usuario", SqlDbType.VarChar, 50).Value = USUARIO.nom_usuario;
                    Sqlcmd.Parameters.Add("@Des_Password", SqlDbType.VarChar,15).Value = USUARIO.password;
                    Sqlcmd.Parameters.Add("@Ind_Activo", SqlDbType.Bit).Value = USUARIO.ind_activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = USUARIO.usuario;
                    Sqlcmd.Parameters.Add("@Id_Perfil", SqlDbType.Int).Value = USUARIO.id_perfil;
                    Sqlcmd.Parameters.Add("@Cod_Personal", SqlDbType.VarChar, 50).Value = USUARIO.cod_personal;
                    Sqlcmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value =USUARIO.email;
                    Sqlcmd.Parameters.Add("@Flag_Ad", SqlDbType.Bit).Value = USUARIO.flag_ad;

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
                    sex.Message, "UsuarioRepository/getGrabar_Usuario(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getGrabar_Usuario() EX." + ex, "Error");
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
        public MensajeResultado getGrabar_UsuarioEmpresa(Usuario_EmpresaDTO USUARIO)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Usuario_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                   
                    Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = USUARIO.id_user;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = USUARIO.cod_empresa;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = USUARIO.usuario;
                 

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
                    sex.Message, "UsuarioRepository/getGrabar_UsuarioEmpresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "UsuarioRepository/getGrabar_UsuarioEmpresa() EX." + ex, "Error");
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
