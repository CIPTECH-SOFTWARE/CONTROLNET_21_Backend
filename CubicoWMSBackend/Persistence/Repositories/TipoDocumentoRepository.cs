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
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly AppDbContext _appDBContext;

        public TipoDocumentoRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public async Task<List<TipoDocumentoDTO>> ListarTipoDocumento()
        {
            var LISTA = getListarTipoDocumento();
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoTipoDocumento(TipoDocumentoMantenimientoDTO TIPO_DOCUMENTO)
        {
            var mensaje = getMantenimientoTipoDocumento(TIPO_DOCUMENTO);
            return mensaje;
        }



        public List<TipoDocumentoDTO> getListarTipoDocumento()
        {
            List<TipoDocumentoDTO> ListaTipoDocumentoDTO = new List<TipoDocumentoDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Tipo_Documento_21";
                    // Sqlcmd.Parameters.Clear();
                    // Sqlcmd.Parameters.Add("@cod_empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        TipoDocumentoDTO TipoDocumentoDTO = new TipoDocumentoDTO();
                        TipoDocumentoDTO.Cod_Tipo_Doc = int.Parse(oDataReader["Cod_Tipo_Doc"].ToString());
                        TipoDocumentoDTO.Nom_Tipo_Doc = oDataReader["Nom_Tipo_Doc"].ToString();
                        TipoDocumentoDTO.Des_Tipo_Doc = oDataReader["Des_Tipo_Doc"].ToString();
                        TipoDocumentoDTO.Activo = bool.Parse(oDataReader["Activo"].ToString());
                        ListaTipoDocumentoDTO.Add(TipoDocumentoDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "TipoDocumentoRepository/getListarTipoDocumento(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoDocumentoRepository/getListarTipoDocumento() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaTipoDocumentoDTO;
        }

        public MensajeResultado getMantenimientoTipoDocumento(TipoDocumentoMantenimientoDTO TIPO_DOCUMENTO)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_TIPO_PERSONAL_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = TIPO_DOCUMENTO.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Tipo_Doc", SqlDbType.Int).Value = TIPO_DOCUMENTO.Cod_Tipo_Doc;
                    Sqlcmd.Parameters.Add("@Nom_Tipo_Doc", SqlDbType.VarChar,60).Value = TIPO_DOCUMENTO.Cod_Tipo_Doc;
                    Sqlcmd.Parameters.Add("@Des_Tipo_Doc", SqlDbType.VarChar,50).Value = TIPO_DOCUMENTO.Des_Tipo_Doc;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = TIPO_DOCUMENTO.Activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = TIPO_DOCUMENTO.id_user;

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
                    sex.Message, "TipoDocumentoRepository/getMantenimientoTipoDocumento(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "TipoDocumentoRepository/getMantenimientoTipoDocumento() EX." + ex, "Error");
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
