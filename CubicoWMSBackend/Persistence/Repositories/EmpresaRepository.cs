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
using ControlNetBackend.Domain.Models;

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

        public async Task<MensajeResultado> MantenimientoEmpresa(EmpresaMantenimientoDTO empresa)
        {

            var mensaje = getMantenimientoEmpresa(empresa);
            return mensaje;




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
                        usuarioEmpresaDTO.id_user = int.Parse(oDataReader["id_user"].ToString());
                        usuarioEmpresaDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        usuarioEmpresaDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        ListaUsuarioEmpresaDTO.Add(usuarioEmpresaDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "EmpresaRepository/getListarUsuarioEmpresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EmpresaRepository/getListarUsuarioEmpresa() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
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
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "EmpresaRepository/getListarEmpresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EmpresaRepository/getListarEmpresa() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
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
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "EmpresaRepository/getListarEmpresa_activa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EmpresaRepository/getListarEmpresa_activa() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
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
        public MensajeResultado getMantenimientoEmpresa(EmpresaMantenimientoDTO empresa)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = empresa.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = empresa.cod_empresa;
                    Sqlcmd.Parameters.Add("@Des_Empresa", SqlDbType.VarChar,100).Value = empresa.des_empresa;
                    Sqlcmd.Parameters.Add("@Ruc", SqlDbType.VarChar,20).Value = empresa.ruc;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = empresa.id_user;
                    Sqlcmd.Parameters.Add("@Flag_Activo", SqlDbType.Bit).Value = empresa.flag_activo;


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
                    sex.Message, "EmpresaRepository/getMantenimientoEmpresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "EmpresaRepository/getMantenimientoEmpresa() EX." + ex, "Error");
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

