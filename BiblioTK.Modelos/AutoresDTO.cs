using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class AutoresDTO
    {
        public string autor_uid { get; set; }
        public string autor_cutter { get; set; }
        public string autor_nombre { get; set; }
        public string autor_apellido_paterno { get; set; }
        public string autor_apellido_materno { get; set; }
        public string autor_año_nacimiento { get; set; }
        public string autor_año_muerte { get; set; }
    }
}
