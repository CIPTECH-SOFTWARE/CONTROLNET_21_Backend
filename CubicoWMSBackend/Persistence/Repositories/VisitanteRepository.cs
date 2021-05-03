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
    public class VisitanteRepository : IVisitanteRepository
    {

        private readonly AppDbContext _appDBContext;
        public VisitanteRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<List<VisitanteDTO>> ListarVisitante(string filtro)
        {
            var LISTA = getListarVisitante(filtro);
            return LISTA;
        }

        public async Task<List<VisitanteDTO>> ListarVisitante_X_Codigo(int cod_visitante)
        {
            var LISTA = getListarVisitante_X_Codigo(cod_visitante);
            return LISTA;
        }

      

        public async Task<MensajeResultado> MantenimientoVisitante(VisitanteMantenimientoDTO TIPO_PERSONAL)
        {
            var mensaje = getMantenimientoVisitante(TIPO_PERSONAL);
            return mensaje;
        }



        public List<VisitanteDTO> getListarVisitante(string filtro)
        {
            List<VisitanteDTO> ListaVisitanteDTO = new List<VisitanteDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Datos_Visitante_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@param_tipo_personal", SqlDbType.VarChar, 400).Value = filtro;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        VisitanteDTO VisitanteDTO = new VisitanteDTO();
                        VisitanteDTO.cod_visitante = int.Parse(oDataReader["cod_visitante"].ToString());
                        VisitanteDTO.cod_tipo_doc = int.Parse(oDataReader["cod_tipo_doc"].ToString());
                        VisitanteDTO.cod_tipo_visitante = int.Parse(oDataReader["cod_tipo_visitante"].ToString());
                        VisitanteDTO.des_tipo_visitante = oDataReader["des_tipo_visitante"].ToString();
                        VisitanteDTO.des_tipo_doc = oDataReader["des_tipo_doc"].ToString();
                        VisitanteDTO.cod_centro_costo = int.Parse(oDataReader["cod_centro_costo"].ToString());
                        VisitanteDTO.des_centro_costo = oDataReader["des_centro_costo"].ToString();
                        VisitanteDTO.num_doc = oDataReader["num_doc"].ToString();
                        VisitanteDTO.nom_visitante = oDataReader["nom_visitante"].ToString();
                        VisitanteDTO.img_visitante = (byte[])(oDataReader["img_visitante"]);
                        VisitanteDTO.nom_empresa = oDataReader["nom_empresa"].ToString();
                        VisitanteDTO.ind_proveedor = bool.Parse(oDataReader["ind_proveedor"].ToString());
                        VisitanteDTO.no_deseado = bool.Parse(oDataReader["no_deseado"].ToString());
                        VisitanteDTO.motivo_no_deseado = oDataReader["motivo_no_deseado"].ToString();
                        VisitanteDTO.genero = oDataReader["genero"].ToString();
                        VisitanteDTO.activo = bool.Parse(oDataReader["flag_activo"].ToString());

                        ListaVisitanteDTO.Add(VisitanteDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "VisitanteRepository/getListarVisitante(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "VisitanteRepository/getListarVisitante() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }

            return ListaVisitanteDTO;
        }

        public List<VisitanteDTO> getListarVisitante_X_Codigo(int cod_visitante)
        {
            List<VisitanteDTO> ListaVisitanteDTO = new List<VisitanteDTO>();

            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Datos_Visitante_X_Codigo_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@param_tipo_personal", SqlDbType.Int).Value = cod_visitante;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        VisitanteDTO VisitanteDTO = new VisitanteDTO();
                        VisitanteDTO.cod_visitante = int.Parse(oDataReader["cod_visitante"].ToString());
                        VisitanteDTO.cod_tipo_doc = int.Parse(oDataReader["cod_tipo_doc"].ToString());
                        VisitanteDTO.cod_tipo_visitante = int.Parse(oDataReader["cod_tipo_visitante"].ToString());
                        VisitanteDTO.des_tipo_visitante = oDataReader["des_tipo_visitante"].ToString();
                        VisitanteDTO.des_tipo_doc = oDataReader["des_tipo_doc"].ToString();
                        VisitanteDTO.cod_centro_costo = int.Parse(oDataReader["cod_centro_costo"].ToString());
                        VisitanteDTO.des_centro_costo = oDataReader["des_centro_costo"].ToString();
                        VisitanteDTO.num_doc = oDataReader["num_doc"].ToString();
                        VisitanteDTO.nom_visitante = oDataReader["nom_visitante"].ToString();
                        VisitanteDTO.img_visitante = (byte[])(oDataReader["img_visitante"]);
                        VisitanteDTO.nom_empresa = oDataReader["nom_empresa"].ToString();
                        VisitanteDTO.ind_proveedor = bool.Parse(oDataReader["ind_proveedor"].ToString());
                        VisitanteDTO.no_deseado = bool.Parse(oDataReader["no_deseado"].ToString());
                        VisitanteDTO.motivo_no_deseado = oDataReader["motivo_no_deseado"].ToString();
                        VisitanteDTO.genero = oDataReader["genero"].ToString();
                        VisitanteDTO.activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        VisitanteDTO.Autorizacion_datos = bool.Parse(oDataReader["Autorizacion_datos"].ToString());
                        ListaVisitanteDTO.Add(VisitanteDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "VisitanteRepository/getListarVisitante_X_Codigo(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "VisitanteRepository/getListarVisitante_X_Codigo() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }

            return ListaVisitanteDTO;
        }

       
        public MensajeResultado getMantenimientoVisitante(VisitanteMantenimientoDTO VISITANTE)
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
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = VISITANTE.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Visitante", SqlDbType.Int).Value = VISITANTE.cod_visitante;
                    Sqlcmd.Parameters.Add("@Cod_Tipo_Doc", SqlDbType.VarChar, 20).Value = VISITANTE.cod_tipo_doc;
                    Sqlcmd.Parameters.Add("@Cod_Tipo_Visitante", SqlDbType.VarChar, 5).Value = VISITANTE.cod_tipo_visitante;
                    Sqlcmd.Parameters.Add("@Cod_Centro_Costo", SqlDbType.Bit).Value = VISITANTE.cod_centro_costo;
                    Sqlcmd.Parameters.Add("@Num_Doc", SqlDbType.Bit).Value = VISITANTE.num_doc;
                    Sqlcmd.Parameters.Add("@Nom_Visitante", SqlDbType.Bit).Value = VISITANTE.nom_visitante;
                    Sqlcmd.Parameters.Add("@Img_Visitante", SqlDbType.Bit).Value = VISITANTE.img_visitante;
                    Sqlcmd.Parameters.Add("@Nom_Empresa", SqlDbType.Bit).Value = VISITANTE.nom_empresa;
                    Sqlcmd.Parameters.Add("@Ind_Proveedor", SqlDbType.Bit).Value = VISITANTE.ind_proveedor;
                    Sqlcmd.Parameters.Add("@No_Deseado", SqlDbType.Bit).Value = VISITANTE.no_deseado;
                    Sqlcmd.Parameters.Add("@Motivo_No_Deseado", SqlDbType.Bit).Value = VISITANTE.motivo_no_deseado;
                    Sqlcmd.Parameters.Add("@Autorizacion_datos", SqlDbType.Bit).Value = VISITANTE.Autorizacion_datos;
                    Sqlcmd.Parameters.Add("@ApellidoPaterno", SqlDbType.Bit).Value = VISITANTE.ape_paterno;
                    Sqlcmd.Parameters.Add("@ApellidoMaterno", SqlDbType.Bit).Value = VISITANTE.ape_materno;


                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = VISITANTE.activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = VISITANTE.id_user;

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
                    sex.Message, "VisitanteRepository/getMantenimientoVisitante(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "VisitanteRepository/getMantenimientoVisitante() EX." + ex, "Error");
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
