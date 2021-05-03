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
    public class GrupoAccesosRepository : IGrupoAccesosRepository
    {

        private readonly AppDbContext _appDBContext;
        public GrupoAccesosRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<List<GrupoAccesosDTO>> ListarGrupoAccesos()
        {
            var LISTA = getListarGrupoAccesos();
            return LISTA;
        }

        public async Task<List<GrupoAccesosDTO>> ListarGrupoAccesosEmpresa(int cod_empresa)
        {
            var LISTA = getListarGrupoAccesosEmpresa(cod_empresa);
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoGrupoAccesos(MantenimientoGrupoAccesosDTO grupo)
        {
            var GRUPO = getMantenimientoGrupoAccesos(grupo);
            return GRUPO;
        }


        public List<GrupoAccesosDTO> getListarGrupoAccesos()
        {
            List<GrupoAccesosDTO> ListaGrupoAccesosDTO = new List<GrupoAccesosDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Grupo_Accesos_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        GrupoAccesosDTO GrupoAccesosDTO = new GrupoAccesosDTO();
                        GrupoAccesosDTO.cod_grupo_accesos = int.Parse(oDataReader["cod_grupo_accesos"].ToString());
                        GrupoAccesosDTO.des_grupo_accesos = oDataReader["des_grupo_accesos"].ToString();
                        GrupoAccesosDTO.identificador = oDataReader["identificador"].ToString();
                        GrupoAccesosDTO.id_tipo_grupo = int.Parse(oDataReader["id_tipo_grupo"].ToString());
                        GrupoAccesosDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        GrupoAccesosDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        GrupoAccesosDTO.Activo = bool.Parse(oDataReader["activo"].ToString());
                        ListaGrupoAccesosDTO.Add(GrupoAccesosDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "GrupoAccesosRepository/getListarGrupoAccesos(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "GrupoAccesosRepository/getListarGrupoAccesos() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaGrupoAccesosDTO;
        }

        public List<GrupoAccesosDTO> getListarGrupoAccesosEmpresa(int cod_empresa)
        {
            List<GrupoAccesosDTO> ListaGrupoAccesosDTO = new List<GrupoAccesosDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Grupo_Accesos_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_empresa", SqlDbType.Int).Value = cod_empresa;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        GrupoAccesosDTO GrupoAccesosDTO = new GrupoAccesosDTO();
                        GrupoAccesosDTO.cod_grupo_accesos = int.Parse(oDataReader["cod_grupo_accesos"].ToString());
                        GrupoAccesosDTO.des_grupo_accesos = oDataReader["des_grupo_accesos"].ToString();
                        GrupoAccesosDTO.identificador = oDataReader["identificador"].ToString();
                        GrupoAccesosDTO.id_tipo_grupo = int.Parse(oDataReader["id_tipo_grupo"].ToString());
                        GrupoAccesosDTO.cod_empresa = int.Parse(oDataReader["cod_empresa"].ToString());
                        GrupoAccesosDTO.des_empresa = oDataReader["des_empresa"].ToString();
                        GrupoAccesosDTO.Activo = bool.Parse(oDataReader["activo"].ToString());
                        ListaGrupoAccesosDTO.Add(GrupoAccesosDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "GrupoAccesosRepository/getListarGrupoAccesos(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "GrupoAccesosRepository/getListarGrupoAccesos() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaGrupoAccesosDTO;
        }

        public MensajeResultado getMantenimientoGrupoAccesos(MantenimientoGrupoAccesosDTO grupo)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Grupo_Accesos_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = grupo.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Grupo_Accesos", SqlDbType.Int).Value = grupo.cod_grupo_accesos;
                    Sqlcmd.Parameters.Add("@Descripcion", SqlDbType.VarChar,100).Value = grupo.des_grupo_accesos;
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = grupo.cod_empresa;
                    Sqlcmd.Parameters.Add("@Identificador", SqlDbType.Int).Value = grupo.identificador;
                    Sqlcmd.Parameters.Add("@id_tipo_grupo", SqlDbType.Int).Value = grupo.id_tipo_grupo;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = grupo.activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = grupo.id_user;

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
                    sex.Message, "PisoRepository/getMantenimientoGrupoAccesos(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PisoRepository/getMantenimientoGrupoAccesos() EX." + ex, "Error");
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
