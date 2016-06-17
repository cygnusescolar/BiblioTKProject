using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class SeguridadDTO
    {
        public string log_uid { get; set; }
        public string usuario_uid { get; set; }
        public short usuario_tipo { get; set; }
        public DateTime fecha { get; set; }
        public bool mobile { get; set; }
        public string ip { get; set; }
        public string browser { get; set; }
    }
}
