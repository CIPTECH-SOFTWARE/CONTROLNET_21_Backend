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
    public class ConfiguracionParametrosRepository:IConfiguracionParametrosRepository
    {
        private readonly AppDbContext _appDBContext;
        public ConfiguracionParametrosRepository(AppDbContext context)
        {
            _appDBContext = context;
        }

        public Task<ConfiguracionParametrosDTO> ParametrosConfiguracion()
        {
            throw new NotImplementedException();
        }

        public async Task<ConfiguracionParametros_EmailDTO> ParametrosConfiguracionEmail()
        {
            var Parametros = getParametrosConfiguracion_Email();
            return Parametros;
        }

        private ConfiguracionParametros_EmailDTO getParametrosConfiguracion_Email()
        {

            ConfiguracionParametros_EmailDTO ConfiguracionParametros_EmailDTO = new ConfiguracionParametros_EmailDTO();
            string cnxString = _appDBContext.Database.GetConnectionString();
            SqlConnection cnx = new SqlConnection(cnxString);
            try
            {
                cnx.Open();
                using (SqlCommand Sqlcmd = new SqlCommand())
                {
                    Sqlcmd.Connection = cnx;
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.CommandText = "SP_S_Listar_Parametros_Email_21";
                                   
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {

                        ConfiguracionParametros_EmailDTO.EmailEmisor = oDataReader["EmailEmisor"].ToString();
                        ConfiguracionParametros_EmailDTO.Dominio = oDataReader["Dominio"].ToString();
                        ConfiguracionParametros_EmailDTO.Usuario = oDataReader["Usuario"].ToString();
                        ConfiguracionParametros_EmailDTO.Password = oDataReader["Password"].ToString();
                        ConfiguracionParametros_EmailDTO.Puerto = int.Parse(oDataReader["Puerto"].ToString());
                        ConfiguracionParametros_EmailDTO.Host = oDataReader["Host"].ToString();
                        ConfiguracionParametros_EmailDTO.Asunto = oDataReader["Asunto"].ToString();
                        ConfiguracionParametros_EmailDTO.EmailDestino = oDataReader["EmailDestino"].ToString();
                        ConfiguracionParametros_EmailDTO.EmailDestinoCC = oDataReader["EmailDestinoCC"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                ConfiguracionParametros_EmailDTO = null;
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ConfiguracionParametros_EmailDTO;


        }

    }
}
