using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class CatalogoAutoresDTO
    {
        public string catalogo_uid { get; set; }
        public int autor_uid { get; set; }
        public byte autor_tipo { get; set; }

    }
}
