using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;
using CubicoWMSBackend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace ControlNetBackend.Persistence.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AppDbContext _appDBContext;
        // private IConfiguration configuration;
        public EmpresaRepository(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public IEnumerable<UsuarioEmpresaDTO> ListarUsuarioEmpresa(int ID_USER)
        {
            List<UsuarioEmpresaDTO> ListaUsuarioEmpresaDTO = new List<UsuarioEmpresaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Usuario_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        UsuarioEmpresaDTO usuarioEmpresaDTO = new UsuarioEmpresaDTO();
                        usuarioEmpresaDTO.ID_USER = int.Parse(oDataReader[0].ToString());
                        usuarioEmpresaDTO.COD_EMPRESA = int.Parse(oDataReader[1].ToString());
                        usuarioEmpresaDTO.DES_EMPRESA = oDataReader[2].ToString();
                        ListaUsuarioEmpresaDTO.Add(usuarioEmpresaDTO);
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


            return ListaUsuarioEmpresaDTO;

        }
    }
}
