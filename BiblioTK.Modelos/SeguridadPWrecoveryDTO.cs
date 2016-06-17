using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class SeguridadPWrecoveryDTO
    {
        public string pw_recovery_uid { get; set; }
        public DateTime pw_fecha { get; set; }
        public string pw_codigo { get; set; }
        public string pw_usuario_uid { get; set; }
        public short pw_usuario_tipo { get; set; }
    }
}
