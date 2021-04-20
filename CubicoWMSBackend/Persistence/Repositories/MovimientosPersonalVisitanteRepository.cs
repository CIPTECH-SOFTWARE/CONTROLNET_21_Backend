﻿using ControlNetBackend.Domain.IRepositories;
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
                        IngresoPersonalVisitaSedeDTO.fec_hor_acceso = oDataReader["FEC:HOR_ACCESO"].ToString();
                       
                                               
                        ListaIngresoPersonalVisitaSedeDTO.Add(IngresoPersonalVisitaSedeDTO);

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
                        IngresoPersonalVisitaSedeDTO.imagen = (byte[])(oDataReader["imagen"]);
                        IngresoPersonalVisitaSedeDTO.tipo_documento = oDataReader["TIPO_DOCUMENTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.numero_documento = oDataReader["NUMERO_DOCUMENTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.centro_costo = oDataReader["CENTRO_COSTO"].ToString();
                        IngresoPersonalVisitaSedeDTO.fec_hor_acceso = oDataReader["FEC:HOR_ACCESO"].ToString();


                        ListaIngresoPersonalVisitaSedeDTO.Add(IngresoPersonalVisitaSedeDTO);

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
                        total= oDataReader["contador"].ToString();
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


            return total;




        }
    }
}