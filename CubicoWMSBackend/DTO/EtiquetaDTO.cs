using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CubicoWMSBackend.DTO
{
    public class EtiquetaDTO
    {
        public string campo { get; set; }
        public string valor { get; set; }
    }

    public class PrintLabelDTO
    {
        public string labelName { get; set; }
        public string printerName { get; set; }

        public IEnumerable<EtiquetaDTO> label { get; set; }
    }
}
