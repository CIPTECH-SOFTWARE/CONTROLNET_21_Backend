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
    public class PerfilRepository : IPerfilRepository
    {

        private readonly AppDbContext _appDBContext;
        public PerfilRepository(AppDbContext context)
        { 
            _appDBContext = context;
        }
        public async Task<List<PerfilDTO>> ListarPerfil()
        {
            var Lista = getListarPerfil();
            return Lista;
        }

        public async Task<MensajeResultado> MantenimientoPerfil(PerfilMantenimientoDTO perfil)
        {
            var mensaje = getMantenimientoPerfil(perfil);
            return mensaje;
        }


        public List<PerfilDTO> getListarPerfil()
        {
            List<PerfilDTO> ListaPerfilDTO = new List<PerfilDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Perfil_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PerfilDTO PerfilDTO = new PerfilDTO();
                        PerfilDTO.cod_perfil = int.Parse(oDataReader["id_perfil"].ToString());
                        PerfilDTO.des_perfil =oDataReader["des_perfil"].ToString();
                        PerfilDTO.activo =bool.Parse(oDataReader["activo"].ToString());
                        ListaPerfilDTO.Add(PerfilDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PerfilRepository/getListarPerfil(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PerfilRepository/getListarPerfil() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPerfilDTO;
        }

        public MensajeResultado getMantenimientoPerfil(PerfilMantenimientoDTO perfil)
        {
            MensajeResultado MensajeResultado = new MensajeResultado();
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_TX_Grabar_Perfil_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = perfil.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Id_Perfil", SqlDbType.Int).Value = perfil.cod_perfil;
                    Sqlcmd.Parameters.Add("@Des_Perfil", SqlDbType.VarChar, 100).Value = perfil.des_perfil;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = perfil.activo;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = perfil.id_user;

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
                    sex.Message, "PerfilRepository/getMantenimientoPerfil(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PerfilRepository/getMantenimientoPerfil() EX." + ex, "Error");
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
