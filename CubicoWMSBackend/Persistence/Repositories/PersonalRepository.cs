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

        public async Task<List<PersonalDTO>> ListarPersonal()
        {
            var ListaPersonal = getListarPersonal();
            return ListaPersonal;
        }
        public async Task<List<PersonalDTO>> ListarPersonal_CentroCosto(int COD_CENTRO_COSTO)
        {
            var ListaPersonal = getListarPersonal_CentroCosto(COD_CENTRO_COSTO);
            return ListaPersonal;
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Empresa_filtro(int COD_EMPRESA, int ID_USER)
        {
            var ListaPersonal = getListarPersonal_Empresa_filtro( COD_EMPRESA,ID_USER);
            return ListaPersonal;
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Empresa(int COD_EMPRESA)
        {
            var ListaPersonal = getListarPersonal_Empresa(COD_EMPRESA);
            return ListaPersonal;
        }

        public async Task<List<PersonalDTO>> ListarPersonal_GAP(int COD_GAP)
        {
            var ListaPersonal = getListarPersonal_GAP(COD_GAP);
            return ListaPersonal;
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Empresa_tree(int COD_EMPRESA)
        {
            var ListaPersonal = getListarPersonal_Empresa_tree(COD_EMPRESA);
            return ListaPersonal;
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Codigo(string COD_PERSONAL)
        {
            var ListaPersonal = getListarPersonal_Codigo(COD_PERSONAL);
            return ListaPersonal;
        }

        public async Task<List<PersonalDTO>> ListarPersonal_Codigo_login(string COD_PERSONAL)
        {
            var ListaPersonal = getListarPersonal_Codigo_login(COD_PERSONAL);
            return ListaPersonal;
        }

        public async Task<MensajeResultado> MantenimientoPersonal(PersonalMantenimientoDTO PERSONAL)
        {
            var Personal = getMantenimientoPersonal(PERSONAL);
            return Personal;
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
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getPersonalLogin(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getPersonalLogin() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
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

        public List<PersonalDTO> getListarPersonal()
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_21";
                    //Sqlcmd.Parameters.Clear();
                    //Sqlcmd.Parameters.Add("@cod_personal", SqlDbType.Int).Value = COD_PERSONAL;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        PersonalDTO.img_personal = (byte[]) oDataReader["IMG_PERSONAL"];
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();
                        PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();
                        PersonalDTO.cel = oDataReader["CEL"].ToString();
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                        PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }
        public List<PersonalDTO> getListarPersonal_CentroCosto(int COD_CENTRO_COSTO)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_Centro_Costo_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Centro_Costo", SqlDbType.Int).Value = COD_CENTRO_COSTO;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                       /// PersonalDTO.img_personal = (byte[])oDataReader["IMG_PERSONAL"];
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();
                        PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();
                        PersonalDTO.cel = oDataReader["CEL"].ToString();
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                       // PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_CentroCosto(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_CentroCosto() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;

        }

        public List<PersonalDTO> getListarPersonal_Empresa_filtro(int COD_EMPRESA, int ID_USER)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_X_Empresa_filtro_permiso_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    Sqlcmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        /// PersonalDTO.img_personal = (byte[])oDataReader["IMG_PERSONAL"];
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();
                        PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();
                        PersonalDTO.cel = oDataReader["CEL"].ToString();
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                        // PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_Empresa_filtro(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_Empresa_filtro() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }

        public List<PersonalDTO> getListarPersonal_Empresa(int COD_EMPRESA)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_X_Empresa_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                   // Sqlcmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        PersonalDTO.cod_empresa = int.Parse(oDataReader["COD_EMPRESA"].ToString());
                        PersonalDTO.des_empresa = oDataReader["DES_EMPRESA"].ToString();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        /// PersonalDTO.img_personal = (byte[])oDataReader["IMG_PERSONAL"];
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();
                        PersonalDTO.cel = oDataReader["CEL"].ToString();
                        PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();
                        
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                        // PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_Empresa_filtro(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_Empresa_filtro() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }

        public List<PersonalDTO> getListarPersonal_GAP(int COD_GAP)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_X_GAP_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_GAP", SqlDbType.Int).Value = COD_GAP;
                    // Sqlcmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        //PersonalDTO.cod_empresa = int.Parse(oDataReader["COD_EMPRESA"].ToString());
                        //PersonalDTO.des_empresa = oDataReader["DES_EMPRESA"].ToString();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        /// PersonalDTO.img_personal = (byte[])oDataReader["IMG_PERSONAL"];
                        //PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        //PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();
                        //PersonalDTO.cel = oDataReader["CEL"].ToString();
                        //PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();

                        //PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        //PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        //PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                        // PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        PersonalDTO.User_Login = oDataReader["User_Login"].ToString();
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_GAP(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_GAP() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }

        public List<PersonalDTO> getListarPersonal_Empresa_tree(int COD_EMPRESA)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_X_Empresa_tree_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Cod_Empresa", SqlDbType.Int).Value = COD_EMPRESA;
                    // Sqlcmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        PersonalDTO.cod_empresa = int.Parse(oDataReader["COD_EMPRESA"].ToString());
                        PersonalDTO.des_empresa = oDataReader["DES_EMPRESA"].ToString();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        // PersonalDTO.img_personal = (byte[])oDataReader["IMG_PERSONAL"];
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();
                        
                        PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_DOC"].ToString());
                        PersonalDTO.des_tipo_doc = oDataReader["DES_TIPO_DOC"].ToString();
                        PersonalDTO.cel = oDataReader["CEL"].ToString();
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                        //PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        PersonalDTO.User_Login = oDataReader["User_Login"].ToString();
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_Empresa_tree(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_Empresa_tree() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }

        public List<PersonalDTO> getListarPersonal_Codigo(string COD_PERSONAL)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.CommandText = "SP_S_Listar_Personal_X_Empresa_tree_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@@Cod_Personal", SqlDbType.Int).Value = COD_PERSONAL;
                    // Sqlcmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                        PersonalDTO.cod_empresa = int.Parse(oDataReader["COD_EMPRESA"].ToString());
                        PersonalDTO.des_empresa = oDataReader["DES_EMPRESA"].ToString();
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.cod_hid = oDataReader["COD_HID"].ToString();
                        PersonalDTO.cod_centro_costo = int.Parse(oDataReader["COD_CENTRO_COSTO"].ToString());
                        PersonalDTO.des_centro_costo = oDataReader["DES_CENTRO_COSTO"].ToString();
                        PersonalDTO.num_dni = oDataReader["NUM_DNI"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        PersonalDTO.img_personal = (byte[])oDataReader["IMG_PERSONAL"];
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.num_anexo = oDataReader["NUM_ANEXO"].ToString();

                        PersonalDTO.ind_vehiculo = oDataReader["IND_VEHICULO"].ToString();
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_DOC"].ToString());
                        PersonalDTO.des_tipo_doc = oDataReader["DES_TIPO_DOC"].ToString();
                        PersonalDTO.cel = oDataReader["CEL"].ToString();
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        PersonalDTO.fiscalizado = bool.Parse(oDataReader["FISCALIZADO"].ToString());
                        PersonalDTO.cod_tipo_personal = int.Parse(oDataReader["COD_TIPO_PERSONAL"].ToString());
                        //PersonalDTO.genero = oDataReader["GENERO"].ToString();
                        PersonalDTO.User_Login = oDataReader["User_Login"].ToString();
                        PersonalDTO.Existente_Reg = int.Parse(oDataReader["Existente_Reg"].ToString());
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_Codigo(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_Codigo() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }

        public List<PersonalDTO> getListarPersonal_Codigo_login(string COD_PERSONAL)
        {
            List<PersonalDTO> ListaPersonalDTO = new List<PersonalDTO>();
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
                    Sqlcmd.Parameters.Add("@Cod_Personal", SqlDbType.Int).Value = COD_PERSONAL;
                    // Sqlcmd.Parameters.Add("@ID_USER", SqlDbType.Int).Value = ID_USER;
                    SqlDataReader oDataReader = Sqlcmd.ExecuteReader();
                    while (oDataReader.Read())
                    {
                        PersonalDTO PersonalDTO = new PersonalDTO();
                       
                        PersonalDTO.cod_personal = oDataReader["COD_PERSONAL"].ToString();
                        PersonalDTO.nom_personal = oDataReader["NOM_PERSONAL"].ToString();
                        PersonalDTO.ape_paterno = oDataReader["APE_PATERNO"].ToString();
                        PersonalDTO.ape_materno = oDataReader["APE_MATERNO"].ToString();
                        PersonalDTO.activo = bool.Parse(oDataReader["ACTIVO"].ToString());
                        PersonalDTO.email = oDataReader["EMAIL"].ToString();
                        
                        ListaPersonalDTO.Add(PersonalDTO);
                    }
                }
            }
            catch (SqlException sex)
            {

                eErrorLog mensajeLogError = new eErrorLog(
                    sex.Message, "PersonalRepository/getListarPersonal_Codigo_login(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PersonalRepository/getListarPersonal_Codigo_login() EX." + ex, "Error");
                mensajeLogError.RegisterLog();
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                }
            }


            return ListaPersonalDTO;
        }

        public MensajeResultado getMantenimientoPersonal(PersonalMantenimientoDTO PERSONAL)
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
                    Sqlcmd.CommandText = "SP_TX_Grabar_Personal_21";
                    Sqlcmd.Parameters.Clear();
                    Sqlcmd.Parameters.Add("@Accion", SqlDbType.Int).Value = PERSONAL.Tipo_Operacion;
                    Sqlcmd.Parameters.Add("@Usuario", SqlDbType.Int).Value = PERSONAL.id_user;
                    Sqlcmd.Parameters.Add("@Cod_Personal", SqlDbType.VarChar,20).Value = PERSONAL.cod_personal;
                    Sqlcmd.Parameters.Add("@Cod_Hid", SqlDbType.VarChar, 30).Value = PERSONAL.cod_hid;
                    Sqlcmd.Parameters.Add("@Cod_Centro_Costo", SqlDbType.Int).Value = PERSONAL.cod_centro_costo;
                    Sqlcmd.Parameters.Add("@Num_Dni", SqlDbType.VarChar,15).Value = PERSONAL.num_dni;
                    Sqlcmd.Parameters.Add("@Nom_Personal", SqlDbType.VarChar, 80).Value = PERSONAL.nom_personal;
                    Sqlcmd.Parameters.Add("@Ape_Paterno", SqlDbType.VarChar, 80).Value = PERSONAL.ape_paterno;
                    Sqlcmd.Parameters.Add("@Ape_Materno", SqlDbType.VarChar,80).Value = PERSONAL.ape_materno;
                    Sqlcmd.Parameters.Add("@Img_Personal", SqlDbType.Image).Value = PERSONAL.img_personal;
                    Sqlcmd.Parameters.Add("@Activo", SqlDbType.Bit).Value = PERSONAL.activo;
                    Sqlcmd.Parameters.Add("@Num_Anexo", SqlDbType.Int).Value = PERSONAL.id_user;
                    Sqlcmd.Parameters.Add("@Ind_Vehiculo", SqlDbType.Char,1).Value = PERSONAL.ind_vehiculo;
                    Sqlcmd.Parameters.Add("@Cod_Tipo_Doc", SqlDbType.Int).Value = PERSONAL.cod_tipo_doc;
                    Sqlcmd.Parameters.Add("@Cel", SqlDbType.VarChar,50).Value = PERSONAL.cel;
                    Sqlcmd.Parameters.Add("@Email", SqlDbType.VarChar,100).Value = PERSONAL.email;
                    Sqlcmd.Parameters.Add("@Fiscalizado", SqlDbType.Bit).Value = PERSONAL.fiscalizado;
                    Sqlcmd.Parameters.Add("@tipo_personal", SqlDbType.Int).Value = PERSONAL.cod_tipo_personal;

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
                    sex.Message, "EdificioRepository/getMantenimientoPersonal(). SQL." + sex, "Error Sql");
                mensajeLogError.RegisterLog();
            }
            catch (Exception ex)
            {
                eErrorLog mensajeLogError = new eErrorLog(ex.Message, "PuertaRepository/getMantenimientoPersonal() EX." + ex, "Error");
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
