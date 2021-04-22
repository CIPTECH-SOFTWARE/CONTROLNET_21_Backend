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
    public class EdificioRepository : IEdificioRepository
    {
        private readonly AppDbContext _appDBContext;
        public EdificioRepository(AppDbContext context)
        {
            _appDBContext = context;
        }


        public async Task<List<EdificioDTO>> ListarEdificio()
        {
            var LISTA = getListarEdificio();
            return LISTA;
        }

        public async Task<List<EdificioDTO>> ListarEdificio_X_Sede(int COD_SEDE)
        {
            var LISTA = getListarEdificio_X_Sede(COD_SEDE);
            return LISTA;
        }

        public async Task<MensajeResultado> MantenimientoEdificio(EdificioMantenimientoDTO EDIFICIO)
        {
            var mensaje = getMantenimientoEdificio(EDIFICIO);
            return mensaje;
        }


        public List<EdificioDTO> getListarEdificio()
        {
            List<EdificioDTO> ListaEdificioDTO = new List<EdificioDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Edificio_21";

                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        EdificioDTO EdificioDTO = new EdificioDTO();
                        EdificioDTO.cod_edificio = int.Parse(oDataReader["cod_edificio"].ToString());
                        EdificioDTO.cod_sede = int.Parse(oDataReader["cod_sede"].ToString());
                        EdificioDTO.des_edificio = oDataReader["des_edificio"].ToString();
                        EdificioDTO.des_direccion = oDataReader["des_direccion"].ToString();
                        EdificioDTO.activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        ListaEdificioDTO.Add(EdificioDTO);
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


            return ListaEdificioDTO;
        }

        public List<EdificioDTO> getListarEdificio_X_Sede(int cod_sede)
        {
            List<EdificioDTO> ListaEdificioDTO = new List<EdificioDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Edificio_X_Sede_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = cod_sede;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        EdificioDTO EdificioDTO = new EdificioDTO();
                        EdificioDTO.cod_edificio = int.Parse(oDataReader["cod_edificio"].ToString());
                        EdificioDTO.cod_sede = int.Parse(oDataReader["cod_sede"].ToString());
                        EdificioDTO.des_sede = oDataReader["des_sede"].ToString();
                        EdificioDTO.des_edificio = oDataReader["des_edificio"].ToString();
                        EdificioDTO.des_direccion = oDataReader["des_direccion"].ToString();
                        EdificioDTO.activo = bool.Parse(oDataReader["flag_activo"].ToString());
                        ListaEdificioDTO.Add(EdificioDTO);
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


            return ListaEdificioDTO;
        }

        public MensajeResultado getMantenimientoEdificio(EdificioMantenimientoDTO EDIFICIO)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = EDIFICIO.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Cod_Edificio", SqlDbType.Int).Value = EDIFICIO.cod_edificio;
                    Sqlcmd.Parameters.Add("@Cod_Sede", SqlDbType.Int).Value = EDIFICIO.cod_sede;
                    Sqlcmd.Parameters.Add("@Des_Edificio", SqlDbType.VarChar,60).Value = EDIFICIO.des_edificio;
                    Sqlcmd.Parameters.Add("@Des_Direccion", SqlDbType.VarChar, 100).Value = EDIFICIO.des_direccion;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = EDIFICIO.id_user;
                    Sqlcmd.Parameters.Add("@Flag_Activo", SqlDbType.Bit).Value = EDIFICIO.activo;


                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {

                        MensajeResultado.mensaje = oDataReader["mensaje"].ToString();
                        MensajeResultado.resultado = int.Parse(oDataReader["resultado"].ToString());

                    }
                }
            }
            catch (SqlException sqlex)
            {

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


            return MensajeResultado;
        }

    }
}
