using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class VotacionDTO
    {
        public string voto_uid { get; set; }
        public string usuario_uid { get; set; }
        public string catalogo_uid { get; set; }
        public byte voto { get; set; }
    }
}
