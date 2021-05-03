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
    public class PisoRepository:IPisoRepository
    {
        private readonly AppDbContext _appDBContext;
        public PisoRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<PisoDTO>> ListarPiso()
        {
            var LISTA = getListarPiso();
            return LISTA;
        }
        public async Task<List<PisoArbolDTO>> ListarPiso_Arbol()
        {
            var LISTA = getListarPiso_Arbol();
            return LISTA;
        }
        public async Task<List<PisoEdificioDTO>> ListarPiso_X_Edificio(int COD_EDIFICIO)
        {
            var LISTA = getListarPiso_X_Edificio(COD_EDIFICIO);
            return LISTA;
        }
        public Task<MensajeResultado> MantenimientoPiso(PisoMantenimientoDTO PISO)
        {
            var mensaje = MantenimientoPiso(PISO);
            return mensaje;
        }


        public List<PisoDTO> getListarPiso()
        {
            List<PisoDTO> ListaPisoDTO = new List<PisoDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Piso_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PisoDTO PisoDTO = new PisoDTO();
                        PisoDTO.cod_piso = int.Parse(oDataReader["cod_piso"].ToString());
                        PisoDTO.cod_edificio = int.Parse(oDataReader["cod_edificio"].ToString());
                        PisoDTO.des_edificio = oDataReader["des_edificio"].ToString();
                        PisoDTO.des_direccion = oDataReader["des_direccion"].ToString();
                        PisoDTO.des_piso = oDataReader["des_piso"].ToString();
                        PisoDTO.num_piso = oDataReader["num_piso"].ToString();
                        PisoDTO.activo = bool.Parse(oDataReader["activo"].ToString());
                        ListaPisoDTO.Add(PisoDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PisoRepository/getListarPiso(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PisoRepository/getListarPiso() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPisoDTO;
        }
        public List<PisoArbolDTO> getListarPiso_Arbol()
        {
            List<PisoArbolDTO> ListaPisoArbolDTO = new List<PisoArbolDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Arbol_Piso_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PisoArbolDTO PisoArbolDTO = new PisoArbolDTO();
                        PisoArbolDTO.cod_Sede = int.Parse(oDataReader["cod_Sede"].ToString());
                        PisoArbolDTO.des_sede = oDataReader["des_sede"].ToString();
                        PisoArbolDTO.des_direccion = oDataReader["des_direccion"].ToString();
                        PisoArbolDTO.cod_edificio = int.Parse(oDataReader["cod_edificio"].ToString());
                        PisoArbolDTO.des_edificio = oDataReader["des_edificio"].ToString();
                                              
                        ListaPisoArbolDTO.Add(PisoArbolDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PisoRepository/getListarPiso_Arbol(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PisoRepository/getListarPiso_Arbol() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPisoArbolDTO;
        }
        public List<PisoEdificioDTO> getListarPiso_X_Edificio(int COD_EDIFICIO)
        {
            List<PisoEdificioDTO> ListaPisoEdificioDTO = new List<PisoEdificioDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Piso_X_Edificio_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_edificio", SqlDbType.Int).Value = COD_EDIFICIO;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PisoEdificioDTO PisoEdificioDTO = new PisoEdificioDTO();
                        PisoEdificioDTO.cod_piso = int.Parse(oDataReader["cod_Sede"].ToString());
                        PisoEdificioDTO.cod_edificio = int.Parse(oDataReader["cod_edificio"].ToString());
                        PisoEdificioDTO.des_edificio = oDataReader["des_edificio"].ToString();
                        PisoEdificioDTO.des_direccion = oDataReader["des_direccion"].ToString();
                        PisoEdificioDTO.cod_Sede = int.Parse(oDataReader["cod_Sede"].ToString());
                        PisoEdificioDTO.des_sede = oDataReader["des_sede"].ToString();
                        PisoEdificioDTO.des_piso = oDataReader["des_piso"].ToString();
                        PisoEdificioDTO.num_piso = oDataReader["num_piso"].ToString();
                        PisoEdificioDTO.activo = bool.Parse(oDataReader["activo"].ToString());


                        ListaPisoEdificioDTO.Add(PisoEdificioDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PisoRepository/getListarPiso_X_Edificio(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PisoRepository/getListarPiso_X_Edificio() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPisoEdificioDTO;
        }
        public MensajeResultado getMantenimientoPiso(PisoMantenimientoDTO PISO)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Piso_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = PISO.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Piso", SqlDbType.Int).Value = PISO.cod_piso;
                    Sqlcmd.Parameters.Add("@Cod_Edificio", SqlDbType.Int).Value = PISO.cod_edificio;
                    Sqlcmd.Parameters.Add("@Des_Piso", SqlDbType.VarChar, 100).Value = PISO.des_piso;
                    Sqlcmd.Parameters.Add("@Num_Piso", SqlDbType.VarChar,5).Value = PISO.num_piso;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = PISO.activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = PISO.id_user;

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
                    sex.Message, "PisoRepository/getMantenimientoPiso(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PisoRepository/getMantenimientoPiso() EX." + ex, "Error");
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
