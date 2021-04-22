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
    public class MovimientosPersonalVisitanteRepository:IMovimientosPersonalVisitanteRepository
    {
        private readonly AppDbContext _appDBContext;
        public MovimientosPersonalVisitanteRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            var LISTA = getListarIngresoSede_DHAS( TIPO, COD_EMPRESA,  COD_SEDE);
            return LISTA;
        }
        public async Task<List<IngresoPersonalVisitaSedeDTO>> ListarIngresoSede_Top_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            var LISTA = getListarIngresoSede_Top_DHAS(TIPO, COD_EMPRESA, COD_SEDE);
            return LISTA;
        }
        public async Task<string> TotalCantidades_Movimiento_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            var LISTA = geTotalCantidades_Movimiento_DHAS(FECHA_INICIO, FECHA_FIN,TIPO, COD_EMPRESA, COD_SEDE);
            return LISTA;
        }
        public async Task<string> Total_Visitante_Tiempo_Exceso_DHAS(int COD_EMPRESA, int COD_SEDE)
        {
            var LISTA = getTotal_Visitante_Tiempo_Exceso_DHAS(COD_EMPRESA, COD_SEDE);
            return LISTA;
        }
        public async Task<List<IngresoVisitaTiempoExcesoSedeDTO>> ListarVisitasTiempoExceso_DHAS(int COD_EMPRESA, int COD_SEDE)
        {
            var LISTA = getListarVisitasTiempoExceso_DHAS(COD_EMPRESA, COD_SEDE);
            return LISTA;
        }
        public async Task<List<IngresoVisitaPersonalGraficaDTO>> IngresoVisitaGrafica_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            var LISTA = getIngresoVisitaGrafica_DHAS(FECHA_INICIO,FECHA_FIN,TIPO,COD_EMPRESA, COD_SEDE);
            return LISTA;
        }

        public List<IngresoPersonalVisitaSedeDTO> getListarIngresoSede_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            List<IngresoPersonalVisitaSedeDTO> ListaIngresoPersonalVisitaSedeDTO = new List<IngresoPersonalVisitaSedeDTO>();
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
                    Sqlcmd.CommandText = "SP_S_DHAS_Personal_Ingreso_per_vis_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = TIPO;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = COD_SEDE;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        IngresoPersonalVisitaSedeDTO IngresoPersonalVisitaSedeDTO = new IngresoPersonalVisitaSedeDTO();
                        IngresoPersonalVisitaSedeDTO.orden =int.Parse(oDataReader["ORDEN"].ToString());
                        IngresoPersonalVisitaSedeDTO.codigo = oDataReader["CODIGO"].ToString();
                        IngresoPersonalVisitaSedeDTO.nombre = oDataReader["NOMBRE"].ToString();
                        IngresoPersonalVisitaSedeDTO.tipo_documento = oDataReader["TIPO_DOCUMENTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.numero_documento = oDataReader["NUMERO_DOCUMENTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.centro_costo = oDataReader["CENTRO_COSTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.fec_hor_acceso = oDataReader["FEC_HOR_ACCESO"].ToString();
                       
                                               
                        ListaIngresoPersonalVisitaSedeDTO.Add(IngresoPersonalVisitaSedeDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MovimientosPersonalVisitanteRepository/getListarIngresoSede_DHAS(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MovimientosPersonalVisitanteRepository/getListarIngresoSede_DHAS() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaIngresoPersonalVisitaSedeDTO;

        }
        public List<IngresoPersonalVisitaSedeDTO> getListarIngresoSede_Top_DHAS(int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            List<IngresoPersonalVisitaSedeDTO> ListaIngresoPersonalVisitaSedeDTO = new List<IngresoPersonalVisitaSedeDTO>();
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
                    Sqlcmd.CommandText = "SP_S_DHAS_Personal_Ingreso_per_vis_top_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = TIPO;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = COD_SEDE;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        IngresoPersonalVisitaSedeDTO IngresoPersonalVisitaSedeDTO = new IngresoPersonalVisitaSedeDTO();
                        IngresoPersonalVisitaSedeDTO.orden = int.Parse(oDataReader["ORDEN"].ToString());
                        IngresoPersonalVisitaSedeDTO.codigo = oDataReader["CODIGO"].ToString();
                        IngresoPersonalVisitaSedeDTO.nombre = oDataReader["NOMBRE"].ToString();

                        if (!(oDataReader["imagen"].ToString() == ""))
                        {
                            IngresoPersonalVisitaSedeDTO.imagen = (byte[])(oDataReader["imagen"]);
                        }
                        IngresoPersonalVisitaSedeDTO.tipo_documento = oDataReader["TIPO_DOCUMENTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.numero_documento = oDataReader["NUMERO_DOCUMENTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.centro_costo = oDataReader["CENTRO_COSTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.fec_hor_acceso = oDataReader["FEC_HOR_ACCESO"].ToString();


                        ListaIngresoPersonalVisitaSedeDTO.Add(IngresoPersonalVisitaSedeDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MovimientosPersonalVisitanteRepository/getListarIngresoSede_Top_DHAS(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MovimientosPersonalVisitanteRepository/getListarIngresoSede_Top_DHAS() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaIngresoPersonalVisitaSedeDTO;

        }
        public string geTotalCantidades_Movimiento_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            string total = string.Empty;
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
                    Sqlcmd.CommandText = "SP_S_DHAS_Total_Ingreso_per_vis_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@fecha_inicio", SqlDbType.VarChar,8).Value =FECHA_INICIO;
                    Sqlcmd.Parameters.Add("@fecha_fin", SqlDbType.VarChar, 8).Value = FECHA_FIN;
                    Sqlcmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = TIPO;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = COD_SEDE;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        total= oDataReader["contador"].ToString().Trim();
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MovimientosPersonalVisitanteRepository/geTotalCantidades_Movimiento_DHAS(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MovimientosPersonalVisitanteRepository/geTotalCantidades_Movimiento_DHAS() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return total;




        }
        public string getTotal_Visitante_Tiempo_Exceso_DHAS(int COD_EMPRESA, int COD_SEDE)
        {
            string total = string.Empty;
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
                    Sqlcmd.CommandText = "SP_S_DHAS_Total_VISITAS_TIEM_EXCESO_21";
                    Sqlcmd.Parameters.Clear();
                   
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = COD_SEDE;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        total = oDataReader["TOTAL_VIS_TIEM_EXCESO"].ToString().Trim();
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MovimientosPersonalVisitanteRepository/getTotal_Visitante_Tiempo_Exceso_DHAS(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MovimientosPersonalVisitanteRepository/getTotal_Visitante_Tiempo_Exceso_DHAS() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return total;




        }
        public List<IngresoVisitaTiempoExcesoSedeDTO> getListarVisitasTiempoExceso_DHAS(int COD_EMPRESA, int COD_SEDE)
        {
            List<IngresoVisitaTiempoExcesoSedeDTO> ListaIngresoVisitaExcesoTiempoSedeDTO = new List<IngresoVisitaTiempoExcesoSedeDTO>();
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
                    Sqlcmd.CommandText = "SP_S_DHAS_LISTAR_VISITAS_TIEM_EXCESO_21";
                    Sqlcmd.Parameters.Clear();
                    
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = COD_SEDE;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        IngresoVisitaTiempoExcesoSedeDTO IngresoVisitaTiempoExcesoSedeDTO = new IngresoVisitaTiempoExcesoSedeDTO();
                        IngresoVisitaTiempoExcesoSedeDTO.nombre = oDataReader["NOMBRE"].ToString();
                        IngresoVisitaTiempoExcesoSedeDTO.centro_costo = oDataReader["CENTRO_COSTO"].ToString();
                        IngresoVisitaTiempoExcesoSedeDTO.hora_acceso = oDataReader["HORA_ACCESO"].ToString();
                        IngresoVisitaTiempoExcesoSedeDTO.tiempo_de_exceso = oDataReader["TIEMPO_DE_EXCESO"].ToString();
                        IngresoVisitaTiempoExcesoSedeDTO.minutos_exceso = int.Parse(oDataReader["MINUTOS_EXCESO"].ToString());
                        IngresoVisitaTiempoExcesoSedeDTO.imagen = (byte[])(oDataReader["imagen"]);
                        ListaIngresoVisitaExcesoTiempoSedeDTO.Add(IngresoVisitaTiempoExcesoSedeDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MovimientosPersonalVisitanteRepository/getListarVisitasTiempoExceso_DHAS(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MovimientosPersonalVisitanteRepository/getListarVisitasTiempoExceso_DHAS() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaIngresoVisitaExcesoTiempoSedeDTO;

        }

        public List<IngresoVisitaPersonalGraficaDTO> getIngresoVisitaGrafica_DHAS(string FECHA_INICIO, string FECHA_FIN, int TIPO, int COD_EMPRESA, int COD_SEDE)
        {
            List<IngresoVisitaPersonalGraficaDTO> ListaIngresoVisitaPersonalGrafica = new List<IngresoVisitaPersonalGraficaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_DHAS_Total_Ingreso_per_vis_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@fecha_inicio", SqlDbType.VarChar, 8).Value = FECHA_INICIO;
                    Sqlcmd.Parameters.Add("@fecha_fin", SqlDbType.VarChar, 8).Value = FECHA_FIN;
                    Sqlcmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = TIPO;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = COD_SEDE;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        IngresoVisitaPersonalGraficaDTO IngresoVisitaPersonalGraficaDTO = new IngresoVisitaPersonalGraficaDTO();
                        IngresoVisitaPersonalGraficaDTO.hora = oDataReader["HORA"].ToString();
                        IngresoVisitaPersonalGraficaDTO.cantidad =int.Parse(oDataReader["CANTIDAD"].ToString());

                        ListaIngresoVisitaPersonalGrafica.Add(IngresoVisitaPersonalGraficaDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "MovimientosPersonalVisitanteRepository/getIngresoVisitaGrafica_DHAS(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "MovimientosPersonalVisitanteRepository/getIngresoVisitaGrafica_DHAS() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaIngresoVisitaPersonalGrafica;


        }
    }
}
