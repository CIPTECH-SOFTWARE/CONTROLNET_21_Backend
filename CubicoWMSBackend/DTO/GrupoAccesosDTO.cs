using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class GrupoAccesosDTO
    {
        public int cod_grupo_accesos { get; set; }
        public string des_grupo_accesos { get; set; }
        public string identificador { get; set; }
        public int id_tipo_grupo { get; set; }
        public int cod_empresa { get; set; }
        public string des_empresa { get; set; }
        public bool Activo { get; set; }

    }


    public class MantenimientoGrupoAccesosDTO
    {
        public int cod_grupo_accesos { get; set; }
        public string des_grupo_accesos { get; set; }
        public string identificador { get; set; }
        public int id_tipo_grupo { get; set; }
        public int cod_empresa { get; set; }
        public bool activo { get; set; }
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }
    }




}
