using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;
using CubicoWMSBackend.Domain.IRepositories;
using CubicoWMSBackend.Domain.Models;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace ControlNetBackend.Persistence.Repositories
{
    public class SedeRepository : ISedeRepository
    {
        private readonly AppDbContext _appDBContext;
        public SedeRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        



        private List<UsuarioSedeDTO> getListarUsuarioSede(int ID_USER)
        {
            {
                List<UsuarioSedeDTO> ListaUsuarioSedeDTO = new List<UsuarioSedeDTO>();
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
                        Sqlcmd.CommandText = "SP_S_Listar_Usuario_Sede_21";
                        Sqlcmd.Parameters.Clear();
                        Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = ID_USER;
                        SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                        while (oDataReader.Read())
                        {
                            UsuarioSedeDTO usuarioSedeDTO = new UsuarioSedeDTO();
                            usuarioSedeDTO.id_user = int.Parse(oDataReader[0].ToString());
                            usuarioSedeDTO.cod_sede= int.Parse(oDataReader[1].ToString());
                            usuarioSedeDTO.des_sede = oDataReader[2].ToString();
                            ListaUsuarioSedeDTO.Add(usuarioSedeDTO);
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


                return ListaUsuarioSedeDTO;

            }
        }

        public async Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER)
        {
            var LISTA =  getListarUsuarioSede(ID_USER);
            return LISTA;
        }
    }
}
