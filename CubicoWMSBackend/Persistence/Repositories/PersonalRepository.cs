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

    public class PersonalRepository : IPersonalRepository
    {

        private readonly AppDbContext _appDBContext;
        public PersonalRepository(AppDbContext context)
        {
            _appDBContext = context;
        }
        public async Task<PersonalLoginDTO> Personal_login(string COD_PERSONAL)
        {
            var personal = getPersonalLogin(COD_PERSONAL);
            return personal;
        }

        public PersonalLoginDTO getPersonalLogin(string COD_PERSONAL)
        {
            PersonalLoginDTO PersonalLoginDTO = new PersonalLoginDTO();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_X_Codigo_Login_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@cod_personal", SqlDbType.Int).Value = COD_PERSONAL;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalLoginDTO.cod_personal = oDataReader["cod_personal"].ToString();
                        PersonalLoginDTO.nom_personal = oDataReader["nom_personal"].ToString();
                        PersonalLoginDTO.ape_paterno = oDataReader["ape_paterno"].ToString();
                        PersonalLoginDTO.ape_materno = oDataReader["ape_materno"].ToString();
                        PersonalLoginDTO.activo = bool.Parse(oDataReader["activo"].ToString());
                        PersonalLoginDTO.email = oDataReader["email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                PersonalLoginDTO = null;
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return PersonalLoginDTO;

        }

    }
}
