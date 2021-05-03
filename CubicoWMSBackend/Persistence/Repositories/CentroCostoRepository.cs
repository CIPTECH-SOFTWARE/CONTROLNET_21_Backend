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
    public class CentroCostoRepository:ICentroCostoRepository
    {
        private readonly AppDbContext _appDBContext;
        // private IConfiguration configuration;
        public CentroCostoRepository(AppDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        


        public async Task<List<CentroCostoDTO>> ListarCentroCosto()
        {
            var LISTA = getListarCentroCosto();
            return LISTA;
        }
        public async Task<List<CentroCostoDTO>> ListarCentroCosto_x_Empresa(int COD_EMPRESA)
        {
            var LISTA = getListarCentroCosto_x_Empresa(COD_EMPRESA);
            return LISTA;
        }
        public async Task<MensajeResultado> MantenimientoCentroCosto(CentroCostoMantenimientoDTO CENTRO_COSTO)
        {

            var mensaje = getMantenimientoCentroCosto(CENTRO_COSTO);
            return mensaje;
        }
     
        

        public List<CentroCostoDTO> getListarCentroCosto()
        {
            List<CentroCostoDTO> ListaCentroCostoDTO = new List<CentroCostoDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_CentroCosto_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        CentroCostoDTO CentroCostoDTO = new CentroCostoDTO();
                        CentroCostoDTO.COD_CENTRO_COSTO = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        CentroCostoDTO.DES_CENTRO_COSTO = oDataReader["DES_CENTRO_COSTO"].ToString();
                        CentroCostoDTO.COD_CENTRO_COSTO_EXT = oDataReader["COD_CENTRO_COSTO_EXT"].ToString();
                        CentroCostoDTO.COD_EMPRESA = int.Parse(oDataReader["flag_activo"].ToString());
                        CentroCostoDTO.DES_EMPRESA = oDataReader["DES_EMPRESA"].ToString();
                        CentroCostoDTO.ACTIVO = bool.Parse(oDataReader["ACTIVO"].ToString());
                        ListaCentroCostoDTO.Add(CentroCostoDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "CentroCostoRepository/getListarCentroCosto(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "CentroCostoRepository/getListarCentroCosto() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaCentroCostoDTO;
        }
        public List<CentroCostoDTO> getListarCentroCosto_x_Empresa(int COD_EMPRESA)
        {
            List<CentroCostoDTO> ListaCentroCostoDTO = new List<CentroCostoDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Centro_Costo_X_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        CentroCostoDTO CentroCostoDTO = new CentroCostoDTO();
                        CentroCostoDTO.COD_CENTRO_COSTO = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        CentroCostoDTO.DES_CENTRO_COSTO = oDataReader["DES_CENTRO_COSTO"].ToString();
                        CentroCostoDTO.COD_CENTRO_COSTO_EXT = oDataReader["COD_CENTRO_COSTO_EXT"].ToString();
                        CentroCostoDTO.COD_EMPRESA = int.Parse(oDataReader["flag_activo"].ToString());
                        CentroCostoDTO.DES_EMPRESA = oDataReader["DES_EMPRESA"].ToString();
                        CentroCostoDTO.ACTIVO = bool.Parse(oDataReader["ACTIVO"].ToString());
                        ListaCentroCostoDTO.Add(CentroCostoDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "CentroCostoRepository/getListarCentroCosto_x_Empresa(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "CentroCostoRepository/getListarCentroCosto_x_Empresa() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaCentroCostoDTO;
        }
        public MensajeResultado getMantenimientoCentroCosto(CentroCostoMantenimientoDTO CENTRO_COSTO)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_CentroCosto_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = CENTRO_COSTO.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Centro_Costo", SqlDbType.Int).Value = CENTRO_COSTO.COD_CENTRO_COSTO;
                    Sqlcmd.Parameters.Add("@Des_Centro_Costo", SqlDbType.VarChar, 100).Value = CENTRO_COSTO.DES_CENTRO_COSTO;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = CENTRO_COSTO.COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Centro_Costo_Ext", SqlDbType.VarChar, 100).Value = CENTRO_COSTO.cod__CENTRO_COSTO_EXT;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = CENTRO_COSTO.id_user;
                    Sqlcmd.Parameters.Add("@Flag_Activo", SqlDbType.Bit).Value = CENTRO_COSTO.activo;


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
                    sex.Message, "CentroCostoRepository/getMantenimientoCentroCosto(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "CentroCostoRepository/getMantenimientoCentroCosto() EX." + ex, "Error");
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
