using ControlNetBackend.DTO;
using ControlNetBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.Models;
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
                        MenuAccesoPerfilDTO.ID_PERFIL = int.Parse(oDataReader[0].ToString());
                        MenuAccesoPerfilDTO.ID_MENU = int.Parse(oDataReader[1].ToString());
                        MenuAccesoPerfilDTO.DES_MENU = oDataReader[2].ToString();
                        MenuAccesoPerfilDTO.ID_PARENT = int.Parse(oDataReader[3].ToString());
                        ListaMenuAccesoPerfilDTO.Add(MenuAccesoPerfilDTO);

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
            return ListaMenuAccesoPerfilDTO;

        }

    }
}
