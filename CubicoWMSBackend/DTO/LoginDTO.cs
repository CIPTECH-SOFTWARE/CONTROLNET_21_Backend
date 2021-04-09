namespace ControlNetBackend.DTO
{
    public class LoginDTO
    {

        public string usuario { get; set; }

        public string password { get; set; }
        public int ID_USER { get; set; }
        public int ID_PERFIL { get; set; }
        public string COD_PERSONAL { get; set; }
        public string NOM_USUARIO { get; set; }
        public int COD_CENTRO_COSTO { get; set; }
        public string DES_CENTRO_COSTO { get; set; }
        public string NOM_COMPLETO_PERSONAL { get; set; }
        public int IND_ACTIVO { get; set; }
        public int ESTADO_PERFIL { get; set; }
        public int RESPUESTA { get; set; }
        public string MENSAJE { get; set; }



    }
}
