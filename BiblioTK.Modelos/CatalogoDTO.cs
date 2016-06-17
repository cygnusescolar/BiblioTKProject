using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class CatalogoDTO
    {
        public string catalogo_uid { get; set; }
        public string class1_id { get; set; }
        public string class2_id { get; set; }
        public string class3_id { get; set; }
        public string class4_id { get; set; }
        public string cat_Class_LCC { get; set; }
        public string cat_Class_Decimal { get; set; }
        public string cat_Titulo { get; set; }
        public string cat_SubTitulo { get; set; }
        public string idioma_id { get; set; }
        public string cat_Edicion { get; set; }
        public string cat_Año { get; set; }
        public string cat_Pais { get; set; }
        public int Editorial_uid { get; set; }
        public string cat_Sinopsis { get; set; }
        public Nullable<System.DateTime> cat_Upload_Fecha { get; set; }
        public int cat_Upload_Por { get; set; }
        public string cat_Upload_Tipo { get; set; }
        public string cat_Upload_Link { get; set; }
        public byte cat_status { get; set; }
    }
}
