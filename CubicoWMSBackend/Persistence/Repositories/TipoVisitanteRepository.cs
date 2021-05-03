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
    public class TipoVisitanteRepository : ITipoVisitanteRepository
    {

        private readonly AppDbContext _appDBContext;
        public TipoVisitanteRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async  Task<List<TipoVisitanteDTO>> ListarTipoVisitante()
        {
            var LISTA = getListarTipoVisitante(); 
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoTipoVisitante(TipoVisitanteMantenimientoDTO TIPO_VISITANTE)
        {
            var mensaje = getMantenimientoTipoVisitante(TIPO_VISITANTE);
            return mensaje;
        }


      
        public  List<TipoVisitanteDTO> getListarTipoVisitante()
        {
            List<TipoVisitanteDTO> ListaTipoVisitanteDTO = new List<TipoVisitanteDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Tipo_Visitante_21";
                    //Sqlcmd.Parameters.Clear();
                    //Sqlcmd.Parameters.Add("@param_tipo_personal", SqlDbType.VarChar, 400).Value = filtro;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TipoVisitanteDTO TipoVisitanteDTO = new TipoVisitanteDTO();
                        TipoVisitanteDTO.cod_tipo_visitante = int.Parse(oDataReader["cod_hid"].ToString());
                        TipoVisitanteDTO.des_tipo_visitante = oDataReader["des_hid"].ToString();
                        TipoVisitanteDTO.des_prefijo = oDataReader["des_hid"].ToString();
                        TipoVisitanteDTO.impresion = bool.Parse(oDataReader["impresion"].ToString());
                        TipoVisitanteDTO.contratista = bool.Parse(oDataReader["contratista"].ToString());
                        TipoVisitanteDTO.empresa = bool.Parse(oDataReader["flag_activo"].ToString());
                        TipoVisitanteDTO.activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        
                        ListaTipoVisitanteDTO.Add(TipoVisitanteDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TipoVisitanteRepository/getListarTipoVisitante(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoVisitanteRepository/getListarTipoVisitante() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTipoVisitanteDTO;
        }

        public  MensajeResultado getMantenimientoTipoVisitante(TipoVisitanteMantenimientoDTO TIPO_VISITANTE)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Tipo_Visitante_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = TIPO_VISITANTE.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Tipo_Visitante", SqlDbType.Int).Value = TIPO_VISITANTE.cod_tipo_visitante;
                    Sqlcmd.Parameters.Add("@Des_Tipo_Visitante", SqlDbType.VarChar, 20).Value = TIPO_VISITANTE.des_tipo_visitante;
                    Sqlcmd.Parameters.Add("@Des_Prefijo", SqlDbType.VarChar,5 ).Value = TIPO_VISITANTE.des_prefijo;
                    Sqlcmd.Parameters.Add("@Impresion", SqlDbType.Bit).Value = TIPO_VISITANTE.impresion;
                    Sqlcmd.Parameters.Add("@Empresa", SqlDbType.Bit).Value = TIPO_VISITANTE.empresa;
                    Sqlcmd.Parameters.Add("@Contratista", SqlDbType.Bit).Value = TIPO_VISITANTE.contratista;



                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = TIPO_VISITANTE.activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = TIPO_VISITANTE.id_user;

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
                    sex.Message, "TipoVisitanteRepository/getMantenimientoTipoVisitante(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoVisitanteRepository/getMantenimientoTipoVisitante() EX." + ex, "Error");
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
