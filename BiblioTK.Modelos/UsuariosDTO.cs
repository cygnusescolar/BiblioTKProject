using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class UsuariosDTO
    {
        public string usuario_uid { get; set; }
        public Nullable<byte> usuario_tipo { get; set; }
        public string usuario_apellido_paterno { get; set; }
        public string usuario_apellido_materno { get; set; }
        public string usuario_nombre { get; set; }
        public string usuario_sexo { get; set; }
        public DateTime usuario_nacimiento { get; set; }
        public string usuario_nacimiento_pais { get; set; }
        public byte[] usuario_foto { get; set; }
        public string usuario_foto_tipo { get; set; }
        public string usuario_email { get; set; }
        public string usuario_password { get; set; }
        public short usuario_status { get; set; }
        public DateTime usuario_fecha_registro { get; set; }
        public DateTime usuario_fecha_ping { get; set; }
        public string admin_cargo { get; set; }
    }
}
