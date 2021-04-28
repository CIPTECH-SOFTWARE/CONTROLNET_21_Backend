using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlNetBackend.DTO
{
    public class GrupoAccesoPersonalDTO
    {
        public int cod_gap { get; set; }
        public string des_grupo_acceso { get; set; }
        public int cod_empresa { get; set; }
        public string des_empresa { get; set; }
        public bool Activo { get; set; }

    }


    public class MantenimientoGrupoAccesoPersonalDTO
    {
        public int cod_gap { get; set; }
        public string des_grupo_acceso { get; set; }
        public int cod_empresa { get; set; }
        public bool activo { get; set; }
        public int Tipo_Operacion { get; set; }
        public int id_user { get; set; }
    }




}
