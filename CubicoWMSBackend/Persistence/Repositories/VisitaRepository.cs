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
    public class VisitaRepository:IVisitaRepository
    {
        private readonly AppDbContext _appDBContext;
        public VisitaRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<List<VisitaDiaDTO>> ListarVisitasDia(string COD_PERSONAL, string FECHA)
        {

            var LISTA = getListarVisitasDia(COD_PERSONAL, FECHA);
            return LISTA;


        }
            public List<VisitaDiaDTO> getListarVisitasDia(string COD_PERSONAL, string FECHA)
        {
            List<VisitaDiaDTO> ListaVisitaDia = new List<VisitaDiaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Visitas_Dia_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Personal", SqlDbType.VarChar, 20).Value = COD_PERSONAL;
                    Sqlcmd.Parameters.Add("@Fecha", SqlDbType.VarChar, 8).Value = FECHA;///formato yyyyMMdd
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        VisitaDiaDTO VisitaDiaDTO = new VisitaDiaDTO();
                        VisitaDiaDTO.Img_Cod_Visitante = oDataReader["Img_Cod_Visitante"].ToString();
                        VisitaDiaDTO.Nom_Visitante = oDataReader["Nom_Visitante"].ToString();
                        VisitaDiaDTO.Num_Doc = oDataReader["Num_Doc"].ToString();
                        VisitaDiaDTO.Cod_Tipo_Doc = int.Parse(oDataReader["Cod_Tipo_Doc"].ToString());
                        VisitaDiaDTO.Des_Tipo_Doc = oDataReader["Des_Tipo_Doc"].ToString();
                        VisitaDiaDTO.Num_Cita = int.Parse(oDataReader["Num_Cita"].ToString());
                        VisitaDiaDTO.Cod_Visitante = int.Parse(oDataReader["Cod_Visitante"].ToString());
                        VisitaDiaDTO.Fec_Ingreso = DateTime.Parse(oDataReader["Fec_Ingreso"].ToString());
                        VisitaDiaDTO.Hor_Ingreso = oDataReader["Hor_Ingreso"].ToString();

                        //int.Parse(oDataReader[1].ToString());

                        ListaVisitaDia.Add(VisitaDiaDTO);

                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "VisitaRepository/getListarVisitasDia(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "VisitaRepository/getListarVisitasDia() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaVisitaDia;


        }
    }
}
