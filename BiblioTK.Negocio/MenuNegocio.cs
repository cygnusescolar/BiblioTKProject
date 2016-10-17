using BiblioTK.Infraestructura.Repositorios;
using BiblioTK.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Negocio
{
    public class MenuNegocio
    {
        public List<MenuResult> ListarClasificaionesPrincipales()
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<ClasficacionPrincipalResult> lista = repo.ListarClasificaionesPrincipales();

            if (lista != null && lista.Count > 0)
            {
                var arbolMenu = (from n1 in lista
                                 group n1 by new { n1.class1_nombre, n1.class1_id } into grupo1
                                 select new MenuResult
                                 {
                                     NombreGrupo = grupo1.Key.class1_nombre.ToString(),
                                     classId = grupo1.Key.class1_id,
                                     NombresItems = (from n2 in grupo1
                                                     group n2 by new { n2.class2_nombre, n2.class2_id } into grupo2
                                                     select new MenuResult
                                                     {
                                                         NombreGrupo = grupo2.Key.class2_nombre.ToString(),
                                                         classId = grupo2.Key.class2_id,
                                                         NombresItems = (from n3 in grupo2
                                                                         group n3 by new { n3.class3_nombre, n3.class3_id } into grupo3
                                                                         select new MenuResult
                                                                         {
                                                                             NombreGrupo = grupo3.Key.class3_nombre,
                                                                             classId = grupo3.Key.class3_id,
                                                                         }
                                                                  ).ToList()
                                                     }


                                             ).ToList()


                                 }).ToList();
                return arbolMenu;

            }
            else
            {
                return new List<MenuResult>();
            }
            
        }

        public List<CatalogoResult> ListarTop10(DateTime fecha)
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<CatalogoResult> lista = repo.ListarTop24(fecha.AddDays(-7)); //fechahora de mexico menos un dia
            return lista ?? new List<CatalogoResult>();
        }

        public List<CatalogoResult> NuevosMateriales()
        {
            MenuRepositorio repo = new MenuRepositorio();
            var lista = repo.NuevosMateriales();
            return lista;
        }
    }
}
