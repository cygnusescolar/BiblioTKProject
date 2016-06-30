using BiblioTK.DAL.DataModel;
using BiblioTK.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Infraestructura.Repositorios
{
    public class MenuRepositorio
    {
        public List<CatalogoResult> ListarTop24(DateTime fecha)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                var fechaparam = new SqlParameter("@D1", System.Data.SqlDbType.DateTime);
                fechaparam.Value = fecha;
                return context.Database.SqlQuery<CatalogoResult>("Top24 @D1", fechaparam).ToList();
            }
        }

        public List<ClasficacionPrincipalResult> ListarClasificaionesPrincipales()
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Database.SqlQuery<ClasficacionPrincipalResult>("SP_CantPorClasificacion").ToList();
            }
        }

    }
}
