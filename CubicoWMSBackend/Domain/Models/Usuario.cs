using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlNetBackend.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string CodUsuario { get; set; }
        [Column(TypeName ="varchar(20)")]
        public string NombreUsuario { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }
        public string email { get; set; }
        public string DesPasswordRec { get; set; }

    }


    public class SGAA_Usuario
    {
        [Key]
        public string Usuario { get; set; }
        public Nullable<int> Id_Perfil { get; set; }
        //public Nullable<int> Id_Cliente { get; set; }
        public string ApeNom { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
        public byte[] Foto { get; set; }
        public string AccesoWeb { get; set; }
        public string UsuarioRegistro { get; set; }
        public Nullable<bool> FlagActivo { get; set; }
        //public Nullable<bool> FlagAnulado { get; set; }

        public string Perfil { get; set; }
        public Nullable<int> FlagRestablecer { get; set; }
        public Nullable<bool> FlagPermiso { get; set; }
        public Nullable<int> Id_Cuenta { get; set; }
        public string Cuenta { get; set; }

    }
}
