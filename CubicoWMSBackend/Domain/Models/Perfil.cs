using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.Domain.Models
{
    public class Perfil
    {
        public int Accion { get; set; }
        public int Usuario { get; set; }
        public int Id_Perfil { get; set; }
        public string Des_Perfil { get; set; }
        public bool Activo { get; set; }

    }
}
