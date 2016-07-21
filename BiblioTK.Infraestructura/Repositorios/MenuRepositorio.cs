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

        public List<ClasficacionPrincipalResult> ListarArbolClasPrincipales()
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                var query =
                    from Tbl_BiblioTK_class2 in context.tbl_BiblioTK_class2
                    join Tbl_BiblioTK_class3 in context.tbl_BiblioTK_class3
                          on new { Tbl_BiblioTK_class2.class1_id, Tbl_BiblioTK_class2.class2_id }
                      equals new { Tbl_BiblioTK_class3.class1_id, Tbl_BiblioTK_class3.class2_id }
                    join Tbl_BiblioTK_class4 in context.tbl_BiblioTK_class4
                          on new { Tbl_BiblioTK_class3.class1_id, Tbl_BiblioTK_class3.class2_id, Tbl_BiblioTK_class3.class3_id }
                      equals new { Tbl_BiblioTK_class4.class1_id, Tbl_BiblioTK_class4.class2_id, Tbl_BiblioTK_class4.class3_id }
                    select new ClasficacionPrincipalResult
                    {

                        class1_nombre = Tbl_BiblioTK_class2.tbl_BiblioTK_class1.class1_nombre,
                        class2_nombre = Tbl_BiblioTK_class2.class2_nombre,
                        class3_nombre = Tbl_BiblioTK_class3.class3_nombre,
                        class4_nombre = Tbl_BiblioTK_class4.class4_nombre

                    };


                return query.ToList();

                
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
