using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Modelos
{
    public class DonativosDTO
    {
        public string donativo_uid { get; set; }
        public string usuario_uid { get; set; }
        public double donativo_importe { get; set; }
        public DateTime donativo_fecha { get; set; }

    }
}
