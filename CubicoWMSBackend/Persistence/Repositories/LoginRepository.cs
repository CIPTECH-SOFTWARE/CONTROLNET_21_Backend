using ControlNetBackend.DTO;
using CubicoWMSBackend.Domain.IRepositories;
using ControlNetBackend.Domain.Models;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace CubicoWMSBackend.Persistence.Repositories
{
    public class LoginRepository:AppDBContext
    {
        private readonly AppDbContext _appDBContext;
       // private IConfiguration configuration;
        public LoginRepository(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        //public IEnumerable<UsuarioEmpresaDTO> ListarUsuarioEmpresa(int ID_USER)
        //{
        //    var ListaUsuarioEmpresa = getListarUsuarioEmpresa(ID_USER);
        //    return ListaUsuarioEmpresa;
        //}

        public async Task<LoginDTO> ValidateUser(Usuario usuario)
        {

            //var user =  await _appDBContext.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario 
            //                                && x.Password == usuario.Password).FirstOrDefaultAsync();
            var user =  getUser(usuario);
            return user;
        }

       
        private LoginDTO getUser(Usuario usuario)
        {


            LoginDTO loginDTO= new LoginDTO();
            loginDTO = null;
            string cnxString= _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Validar_Usuario_AD_CN";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                    Sqlcmd.Parameters.Add("@Des_Password", SqlDbType.VarChar, 50).Value = usuario.Password;
                    Sqlcmd.Parameters.Add("@Validacion_AD", SqlDbType.Bit).Value = 0;
                    Sqlcmd.Parameters.Add("@Mensaje_AD", SqlDbType.VarChar, 200).Value = "";
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {



                        //@ID_USER AS ID_USER,
                        //@ID_PERFIL AS ID_PERFIL,
                        //@COD_PERSONAL AS COD_PERSONAL,
                        //@NOM_USUARIO AS NOM_USUARIO,
                        //@COD_CENTRO_COSTO AS COD_CENTRO_COSTO,
                        //@DES_CENTRO_COSTO AS DES_CENTRO_COSTO,
                        //@NOM_COMPLETO_PERSONAL AS NOM_COMPLETO_PERSONAL,
                        //@IND_ACTIVO AS IND_ACTIVO,
                        //@ESTADO_PERFIL AS ESTADO_PERFIL, 
                        //@RESPUESTA AS RESPUESTA,
                        //@MENSAJE AS MENSAJE
                        loginDTO = new LoginDTO();
                        loginDTO.usuario = usuario.NombreUsuario;
                        loginDTO.password = "";
                        loginDTO.id_user = int.Parse(oDataReader[0].ToString());
                        loginDTO.id_perfil= int.Parse(oDataReader[1].ToString());
                        loginDTO.cod_personal = oDataReader[2].ToString();
                        loginDTO.nom_usuario = oDataReader[3].ToString();
                        loginDTO.cod_centro_costo = int.Parse(oDataReader[4].ToString());
                        loginDTO.des_centro_costo = oDataReader[5].ToString();
                        loginDTO.nom_completo_personal = oDataReader[6].ToString();
                        loginDTO.ind_activo = (oDataReader[7].ToString()=="True"?1:0);
                        loginDTO.estado_perfil = (oDataReader[8].ToString() == "True" ? 1 : 0);
                        loginDTO.respuesta = (oDataReader[9].ToString() == "True" ? 1 : 0);
                        loginDTO.mensaje = oDataReader[10].ToString();

                    }
                 }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                sex.Message, "LoginRepository/getUser(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "LoginRepository/getUser() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State== System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return loginDTO;

        }

        //private List<UsuarioEmpresaDTO> getListarUsuarioEmpresa(int ID_USER)
        //{
        //    List<UsuarioEmpresaDTO> ListaUsuarioEmpresaDTO = new List<UsuarioEmpresaDTO>();
        //    //ListaUsuarioEmpresaDTO = null;
        //    string cnxString = _appDBContext.Database.GetConnectionString();
        //    SqlConnection cnx = new SqlConnection(cnxString);
        //    try
        //    {
        //        cnx.Open();
        //        using (SqlCommand Sqlcmd = new SqlCommand())
        //        {
        //            Sqlcmd.Connection = cnx;
        //            Sqlcmd.CommandType = CommandType.StoredProcedure;
        //            Sqlcmd.CommandText = "SP_S_Listar_Usuario_Empresa_21";
        //            Sqlcmd.Parameters.Clear();
        //            Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = ID_USER;
        //            SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
        //            while (oDataReader.Read())
        //            {
        //                UsuarioEmpresaDTO usuarioEmpresaDTO = new UsuarioEmpresaDTO();
        //                usuarioEmpresaDTO.ID_USER = int.Parse(oDataReader[0].ToString());
        //                usuarioEmpresaDTO.COD_EMPRESA= int.Parse(oDataReader[1].ToString());
        //                usuarioEmpresaDTO.DES_EMPRESA = oDataReader[2].ToString();
        //                ListaUsuarioEmpresaDTO.Add(usuarioEmpresaDTO);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        if (cnx.State == System.Data.ConnectionState.Open)
        //        {
        //            cnx.Close();
        //        }
        //    }


        //    return ListaUsuarioEmpresaDTO;

        //}

    }
}
