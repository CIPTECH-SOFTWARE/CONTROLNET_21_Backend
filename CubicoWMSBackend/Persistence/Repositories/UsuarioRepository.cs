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
            return UsuarioDTO;

        }

      
    }
}
