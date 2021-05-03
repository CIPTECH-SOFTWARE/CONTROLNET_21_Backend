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
    public class VisitanteNoDeseadoRepository : IVisitanteNoDeseadoRepository
    {
        private readonly AppDbContext _appDBContext;
        public VisitanteNoDeseadoRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<List<VisitanteDTO>> ListarVisitanteNoDeseado()
        {
            var LISTA = getListarVisitanteNoDeseado();
            return LISTA; 
        }

        public async Task<MensajeResultado> MantenimientoVisitanteNoDeseado(VisitanteMantenimientoDTO visitanteMantenimientoDTO)
        {
            var mensaje = getMantenimientoVisitanteNoDeseado(visitanteMantenimientoDTO);
            return mensaje;
        }


        public List<VisitanteDTO> getListarVisitanteNoDeseado()
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
                    Sqlcmd.CommandText = "SP_S_Listar_Visitante_NoDeseado_21";
                    //Sqlcmd.Parameters.Clear();
                    //Sqlcmd.Parameters.Add("@param_tipo_personal", SqlDbType.VarChar, 400).Value = filtro;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        VisitanteDTO VisitanteDTO = new VisitanteDTO();
                        VisitanteDTO.cod_visitante = int.Parse(oDataReader["cod_visitante"].ToString());
                        VisitanteDTO.cod_tipo_doc = int.Parse(oDataReader["cod_tipo_doc"].ToString());
                        VisitanteDTO.cod_tipo_visitante = int.Parse(oDataReader["cod_tipo_visitante"].ToString());
                        VisitanteDTO.des_tipo_visitante =oDataReader["des_tipo_visitante"].ToString();
                        VisitanteDTO.des_tipo_doc = oDataReader["des_tipo_doc"].ToString();
                        VisitanteDTO.cod_centro_costo = int.Parse(oDataReader["cod_centro_costo"].ToString());
                        VisitanteDTO.des_centro_costo = oDataReader["des_centro_costo"].ToString();
                        VisitanteDTO.num_doc = oDataReader["num_doc"].ToString();
                        VisitanteDTO.nom_visitante = oDataReader["nom_visitante"].ToString();
                        VisitanteDTO.nom_empresa = oDataReader["nom_empresa"].ToString();
                        VisitanteDTO.ind_proveedor = bool.Parse(oDataReader["ind_proveedor"].ToString());
                        VisitanteDTO.no_deseado = bool.Parse(oDataReader["no_deseado"].ToString());
                        VisitanteDTO.motivo_no_deseado = oDataReader["motivo_no_deseado"].ToString();
                        VisitanteDTO.activo = bool.Parse(oDataReader["flag_activo"].ToString());

                        ListaVisitanteDTO.Add(VisitanteDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "VisitanteNoDeseadoRepository/getListarVisitanteNoDeseado(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "VisitanteNoDeseadoRepository/getListarVisitanteNoDeseado() EX." + ex, "Error");
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

        public MensajeResultado getMantenimientoVisitanteNoDeseado(VisitanteMantenimientoDTO visitanteMantenimientoDTO)
        {
            throw new NotImplementedException();
        }
    }
}
