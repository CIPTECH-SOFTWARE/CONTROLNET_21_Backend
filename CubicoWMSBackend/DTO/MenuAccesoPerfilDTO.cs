using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class MenuAccesoPerfilDTO
    {
        public int ID_PERFIL { get; set; }
        public int  ID_MENU { get; set; }
        public string DES_MENU { get; set; }
        public int  ID_PARENT { get; set; }
       


    }
}
