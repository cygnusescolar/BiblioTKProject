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

        public List<CatalogoResult> NuevosMateriales()
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                var list = context.Set<tbl_BiblioTK_Catalogo>().OrderByDescending(x => x.cat_Upload_Fecha).Skip(1).Take(10).ToList();

                var nuevaLista = list.Select(x => new CatalogoResult
                {
                    catalogo_uid = x.catalogo_uid,
                    cat_Titulo = x.cat_Titulo,
                    cat_Upload_Tipo = x.cat_Upload_Tipo
                }).ToList();

                return nuevaLista;
            }
        }

    }
}
