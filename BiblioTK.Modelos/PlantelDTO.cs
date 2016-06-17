using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class PlantelDTO
    {
        public string plantel_uid { get; set; }
        public string plantel_nombre { get; set; }
        public string plantel_URL { get; set; }
        public string plantel_Facebook { get; set; }
        public string plantel_Twitter { get; set; }
        public string plantel_foto_tipo { get; set; }
        public byte[] plantel_foto { get; set; }
        public bool? ptest_activo_en_home { get; set; }
        public bool? ptest_activo_en_home2 { get; set; }
        public string plantel_siglas { get; set; }
        public string plantel_email { get; set; }
        public short? plantel_theme { get; set; }
        public DateTime? plantel_avisos_ultima_vez { get; set; }
        public string direccion_calle { get; set; }
        public string direccion_num_ext { get; set; }
        public string direccion_num_int { get; set; }
        public string direccion_colonia { get; set; }
        public string direccion_ciudad { get; set; }
        public string direccion_municipio { get; set; }
        public string direccion_entidad { get; set; }
        public string direccion_pais { get; set; }
        public string direccion_CP { get; set; }
        public string direccion_tel1 { get; set; }
        public string direccion_tel2 { get; set; }
        public string direccion_fax { get; set; }
        public string direccion_movil { get; set; }
        public double google_lat { get; set; }
        public double google_lng { get; set; }
        public int google_zoom { get; set; }
    }
}
