using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.DTO;
using CubicoWMSBackend.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

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

        public async Task<List<EmpresaDTO>> ListarEmpresa()
        {
            var LISTA = getListarEmpresa();
            return LISTA;
        }

        public async Task<List<EmpresaDTO>> ListarEmpresa_activa(int COD_EMPRESA)
        {
            var LISTA = getListarEmpresa_activa(COD_EMPRESA);
            return LISTA;
        }

        public async Task<List<UsuarioEmpresaDTO>> ListarUsuarioEmpresa(int ID_USER)
        {
            var LISTA = getListarUsuarioEmpresa(ID_USER);
            return LISTA;
        }
        public List<UsuarioEmpresaDTO> getListarUsuarioEmpresa(int ID_USER)
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
                        usuarioEmpresaDTO.id_user = int.Parse(oDataReader[0].ToString());
                        usuarioEmpresaDTO.cod_empresa = int.Parse(oDataReader[1].ToString());
                        usuarioEmpresaDTO.des_empresa = oDataReader[2].ToString();
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
        public List<EmpresaDTO> getListarEmpresa()
        {
            List<EmpresaDTO> ListaEmpresaDTO = new List<EmpresaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Empresa_21";
                  
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        EmpresaDTO EmpresaDTO = new EmpresaDTO();
                        EmpresaDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        EmpresaDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        EmpresaDTO.ruc = oDataReader["ruc"].ToString();
                        EmpresaDTO.flag_activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        ListaEmpresaDTO.Add(EmpresaDTO);
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


            return ListaEmpresaDTO;
        }

        public List<EmpresaDTO> getListarEmpresa_activa(int COD_EMPRESA)
        {
            List<EmpresaDTO> ListaEmpresaDTO = new List<EmpresaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Empresa_activo_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        EmpresaDTO EmpresaDTO = new EmpresaDTO();
                        EmpresaDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        EmpresaDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        EmpresaDTO.ruc = oDataReader["ruc"].ToString();
                        EmpresaDTO.flag_activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        ListaEmpresaDTO.Add(EmpresaDTO);
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


            return ListaEmpresaDTO;
        }

    }
}
