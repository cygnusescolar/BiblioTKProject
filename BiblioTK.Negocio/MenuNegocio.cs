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

            //? creando el menu por clasificacion
            var arbolMenu = (from n1 in lista
                             group n1 by n1.class1_nombre into grupo1
                             select new MenuResult
                             {
                                 NombreGrupo = grupo1.Key.ToString(),
                                 NombresItems = (from n2 in grupo1
                                                 group n2 by n2.class2_nombre into grupo2
                                                 select new MenuResult
                                                 {
                                                     NombreGrupo = grupo2.Key.ToString(),
                                                     NombresItems = (from n3 in grupo2
                                                                     group n3 by n3.class3_nombre into grupo3
                                                                     select new MenuResult
                                                                     {
                                                                         NombreGrupo = grupo3.Key,
                                                                     }
                                                              ).ToList()
                                                 }


                                         ).ToList()


                             }).ToList();


            return arbolMenu;
        }

        public List<CatalogoResult> ListarTop10(DateTime fecha)
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<CatalogoResult> lista = repo.ListarTop24(fecha.AddDays(-1)); //fechahora de mexico menos un dia
            return lista;
        }

        public List<CatalogoResult> NuevosMateriales()
        {
            MenuRepositorio repo = new MenuRepositorio();
            var lista = repo.NuevosMateriales();
            return lista;
        }
    }
}
