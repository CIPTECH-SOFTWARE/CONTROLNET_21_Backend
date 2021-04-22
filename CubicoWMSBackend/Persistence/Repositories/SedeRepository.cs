using ControlNetBackend.Domain.IRepositories;
using ControlNetBackend.Domain.Models;
using ControlNetBackend.DTO;
using CubicoWMSBackend.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;


namespace ControlNetBackend.Persistence.Repositories
{
    public class SedeRepository : ISedeRepository
    {
        private readonly AppDbContext _appDBContext;
        public SedeRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<List<SedeDTO>> ListarSede_x_Empresa(int COD_EMPRESA)
        {
            var LISTA = getListarSede_x_Empresa(COD_EMPRESA);
            return LISTA;
        }
        public async Task<List<UsuarioSedeDTO>> ListarUsuarioSede(int ID_USER)
        {
            var LISTA =  getListarUsuarioSede(ID_USER);
            return LISTA;
        }
        public async Task<List<UsuarioSedeDTO>> ListarUsuarioSede_activo(int ID_USER)
        {


            var LISTA = getListarUsuarioSede_activo(ID_USER);
            return LISTA;


        }
        public async Task<List<SedeDTO>> ListarSede()
        {
            var LISTA = getListarSede();
            return LISTA;
        }
        public async Task<List<SedeConsultaDTO>> ListarSedeConsulta(int COD_SEDE)
        {
            var LISTA = getListarSedeConsulta(COD_SEDE);
            return LISTA;
        }
        public async Task<MensajeResultado> MantenimientoSede(SedeMantenimientoDTO SEDE)
        {
            var mensaje = getMantenimientoSede(SEDE);
            return mensaje;

        }



        public List<SedeDTO> getListarSede_x_Empresa(int COD_EMPRESA)
        {
            List<SedeDTO> ListaSedeDTO = new List<SedeDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Sede_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        SedeDTO SedeDTO = new SedeDTO();
                        SedeDTO.cod_sede = int.Parse(oDataReader[0].ToString());
                        SedeDTO.des_sede = oDataReader[1].ToString();
                        SedeDTO.direccion = oDataReader[2].ToString();
                        SedeDTO.activo = bool.Parse(oDataReader[3].ToString());
                        ListaSedeDTO.Add(SedeDTO);

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


            return ListaSedeDTO;

        }
        private List<UsuarioSedeDTO> getListarUsuarioSede(int ID_USER)
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
                        usuarioSedeDTO.cod_sede = int.Parse(oDataReader[1].ToString());
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
        public List<UsuarioSedeDTO> getListarUsuarioSede_activo(int ID_USER)
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
                    Sqlcmd.CommandText = "SP_S_LISTAR_USUARIOS_X_SEDE_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Id_User", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        UsuarioSedeDTO usuarioSedeDTO = new UsuarioSedeDTO();
                        usuarioSedeDTO.id_user = int.Parse(oDataReader[0].ToString());
                        usuarioSedeDTO.cod_sede = int.Parse(oDataReader[1].ToString());
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

        public List<SedeDTO> getListarSede()
        {
            List<SedeDTO> ListaSedeDTO = new List<SedeDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Sede_21";
                   
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        SedeDTO SedeDTO = new SedeDTO();
                        SedeDTO.cod_sede = int.Parse(oDataReader["cod_sede"].ToString());
                        SedeDTO.des_sede = oDataReader["des_sede"].ToString();
                        SedeDTO.direccion = oDataReader["direccion"].ToString();
                        SedeDTO.activo = bool.Parse(oDataReader["activo"].ToString());
                        SedeDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        ListaSedeDTO.Add(SedeDTO);

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


            return ListaSedeDTO;
        }

        public List<SedeConsultaDTO> getListarSedeConsulta(int cod_sede)
        {
            List<SedeConsultaDTO> ListaSedeDTO = new List<SedeConsultaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Sede__Consulta_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@cod_sede", SqlDbType.Int).Value = cod_sede;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        SedeConsultaDTO SedeDTO = new SedeConsultaDTO();
                        SedeDTO.cod_sede = int.Parse(oDataReader["cod_sede"].ToString());
                        SedeDTO.des_sede = oDataReader["des_sede"].ToString();
                        ListaSedeDTO.Add(SedeDTO);

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


            return ListaSedeDTO;
        }

        public  MensajeResultado getMantenimientoSede(SedeMantenimientoDTO SEDE)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Sede_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = SEDE.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = SEDE.cod_sede;
                    Sqlcmd.Parameters.Add("@Des_Sede", SqlDbType.VarChar, 100).Value = SEDE.des_sede;
                    Sqlcmd.Parameters.Add("@Des_Direccion", SqlDbType.VarChar, 20).Value = SEDE.direccion;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = SEDE.id_user;
                    Sqlcmd.Parameters.Add("@Flag_Activo", SqlDbType.Bit).Value = SEDE.flag_activo;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = SEDE.cod_empresa;

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {

                        MensajeResultado.mensaje = oDataReader["mensaje"].ToString();
                        MensajeResultado.resultado = int.Parse(oDataReader["resultado"].ToString());

                    }
                }
            }
            catch (SqlException sqlex)
            {

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


            return MensajeResultado;

        }


    }
}
