using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class UsuarioDTO
    {
        public int id_user { get; set; }
        public string cod_usuario { get; set; }
        
        public string nom_usuario { get; set; }
        public string des_Pass { get; set; }
        public string des_Password { get; set; }
        public bool ind_activo { get; set; }
        public int id_perfil { get; set; }
        public string des_perfil { get; set; }
        public string cod_personal { get; set; }
        public string email { get; set; }
        public bool flag_ad { get; set; }
        public string des_pass_recuperacion { get; set; }
        public string nom_personal { get; set; }
    }


    public class Usuario_EmpresaDTO
    {
        public int id_user { get; set; }
        public int cod_empresa { get; set; }
        public int usuario { get; set; }
    }


    public class Usuario_PasswordDTO
    {
        public string cod_usuario { get; set; }
        public string des_Password { get; set; }
        public string old_Password { get; set; }
    }

    public class Usuario_TipoPersonalDTO
    {
        public int id_user { get; set; }
        public int cod_Tipo_Personal { get; set; }
        public int usuario { get; set; }
    }


    public class Usuario_CentroCostoDTO
    {
        public int id_user { get; set; }
        public int cod_centro_costo { get; set; }
        public int usuario { get; set; }
    }


    public class UsuarioMantenimientoDTO
    {
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }
        public string cod_usuario { get; set; }
        public string nom_usuario { get; set; }
        public string password { get; set; }
        public bool ind_activo { get; set; }
        public int id_perfil { get; set; }
        public string cod_personal { get; set; }
        public string email { get; set; }
        public bool flag_ad { get; set; }

        public int usuario { get; set; }
    }






}
