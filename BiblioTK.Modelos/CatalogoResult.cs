using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{

    public partial class CatalogoResult
    {
        public string cat_Upload_Tipo;

        public System.Guid catalogo_uid { get; set; }
        public string cat_Titulo { get; set; }
        public string cat_Año { get; set; }
        public string cat_Edicion { get; set; }
        public string idioma_nombre { get; set; }
        public string autor_nombrecompleto { get; set; }
        public int? Voto { get; set; }
        public string Link { get; set; }
        public string Tipo { get; set; }
        public int CantDesc { get; set; }

        //! epropidad para cargar la ruta de la imagen tumbnail para la lista de catalogos
        public string imagenRuta { get; set; }


    }
}
