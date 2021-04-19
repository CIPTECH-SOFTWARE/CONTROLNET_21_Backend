using ControlNetBackend.Domain.IRepositories;
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
    public class CitaRepository : ICitaRepository
    {

        private readonly AppDbContext _appDBContext;
        public CitaRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<List<CitaProgramadaDiaDTO>> ListarCitasProgramadasDia(string COD_PERSONAL, string FECHA)
        {
            var LISTA = getListarCitasProgramadasDia(COD_PERSONAL, FECHA);
            return LISTA;
        }
               
        private List<CitaProgramadaDiaDTO> getListarCitasProgramadasDia(string COD_PERSONAL, string FECHA)
        {

            List<CitaProgramadaDiaDTO> ListaCitasProgramadasDia = new List<CitaProgramadaDiaDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Citas_Programadas_Dia_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Personal", SqlDbType.VarChar,20).Value = COD_PERSONAL;
                    Sqlcmd.Parameters.Add("@Fecha", SqlDbType.VarChar,8).Value = FECHA;///formato yyyyMMdd
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        CitaProgramadaDiaDTO CitaProgramadaDiaDTO = new CitaProgramadaDiaDTO();
                        CitaProgramadaDiaDTO.Img_Cod_Visitante = oDataReader["Img_Cod_Visitante"].ToString();
                        CitaProgramadaDiaDTO.Fec_Visita_Str = oDataReader["fec_Visita_Str"].ToString();
                        CitaProgramadaDiaDTO.Cod_Personal =oDataReader["Cod_Personal"].ToString();
                        CitaProgramadaDiaDTO.Nom_Personal = oDataReader["Nom_Personal"].ToString();
                        CitaProgramadaDiaDTO.Nom_Visitante = oDataReader["Nom_Visitante"].ToString();
                        CitaProgramadaDiaDTO.Cod_Tipo_Doc = int.Parse(oDataReader["Cod_Tipo_Doc"].ToString());
                        CitaProgramadaDiaDTO.Des_Tipo_Doc = oDataReader["Des_Tipo_Doc"].ToString();
                        CitaProgramadaDiaDTO.Num_Doc = oDataReader["Num_Doc"].ToString();
                        CitaProgramadaDiaDTO.Cod_Visitante = int.Parse(oDataReader["Cod_Visitante"].ToString());
                        CitaProgramadaDiaDTO.Fec_Visita = DateTime.Parse(oDataReader["Fec_Visita"].ToString());
                        CitaProgramadaDiaDTO.Hor_Ingreso = oDataReader["Hor_Ingreso"].ToString();
                        CitaProgramadaDiaDTO.Hor_Salida = oDataReader["Hor_Salida"].ToString();
                        CitaProgramadaDiaDTO.Hor_Tolerancia = oDataReader["Hor_Tolerancia"].ToString();
                        CitaProgramadaDiaDTO.Ind_Estado_Cita = oDataReader["Ind_Estado_Cita"].ToString();
                        CitaProgramadaDiaDTO.Cod_Centro_Costo = int.Parse(oDataReader["Cod_Centro_Costo"].ToString());
                        CitaProgramadaDiaDTO.Des_Mensaje = oDataReader["Des_Mensaje"].ToString();
                        CitaProgramadaDiaDTO.Des_Empresa = oDataReader["Des_Empresa"].ToString();
                        CitaProgramadaDiaDTO.Cod_Tipo_Visitante = int.Parse(oDataReader["Cod_Tipo_Visitante"].ToString());
                        CitaProgramadaDiaDTO.Des_Tipo_Visitante = oDataReader["Des_Tipo_Visitante"].ToString();
                      
                        //int.Parse(oDataReader[1].ToString());

                        ListaCitasProgramadasDia.Add(CitaProgramadaDiaDTO);

                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaCitasProgramadasDia;


        }

       
    }
}
