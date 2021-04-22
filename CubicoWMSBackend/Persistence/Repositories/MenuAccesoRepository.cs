using ControlNetBackend.DTO;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.Models;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ControlNetBackend.Persistence.Repositories
{
    public class MenuAccesoRepository : IMenuAccesoRepository
    {

        private readonly AppDbContext _appDBContext;
        public MenuAccesoRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<MenuAccesoPerfilDTO>> ListarMenuAccesoPerfil(int ID_PERFIL)
        {
            var LISTA = getListarMenuAccesoPerfil(ID_PERFIL);
            return LISTA;
        }

        public List<MenuAccesoPerfilDTO> getListarMenuAccesoPerfil(int ID_PERFIL)
        {
            List<MenuAccesoPerfilDTO> ListaMenuAccesoPerfilDTO = new List<MenuAccesoPerfilDTO>();
           
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Menu_Acceso_Perfil_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Id_Perfil", SqlDbType.Int).Value = ID_PERFIL;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        MenuAccesoPerfilDTO MenuAccesoPerfilDTO = new MenuAccesoPerfilDTO();
                        MenuAccesoPerfilDTO.id_perfil = int.Parse(oDataReader["ID_PERFIL"].ToString());
                        MenuAccesoPerfilDTO.id_menu = int.Parse(oDataReader["ID_MENU"].ToString());
                        MenuAccesoPerfilDTO.des_menu = oDataReader["ID_MENU"].ToString();
                        MenuAccesoPerfilDTO.id_parent = int.Parse(oDataReader["ID_PARENT"].ToString());
                        ListaMenuAccesoPerfilDTO.Add(MenuAccesoPerfilDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MenuAccesoRepository/getListarMenuAccesoPerfil(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MenuAccesoRepository/getListarMenuAccesoPerfil() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }
            return ListaMenuAccesoPerfilDTO;

        }

    }
}
