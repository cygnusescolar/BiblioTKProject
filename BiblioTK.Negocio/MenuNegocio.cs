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
        public List<ClasficacionPrincipalResult> ListarClasificaionesPrincipales()
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<ClasficacionPrincipalResult> lista = repo.ListarClasificaionesPrincipales();
           // List<ClasficacionPrincipalResult> lista = repo.ListarArbolClasPrincipales();


            return lista;
        }

        public List<CatalogoResult> ListarTop10(DateTime fecha)
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<CatalogoResult> lista = repo.ListarTop24(fecha.AddDays(-1));


            return lista;
        }

        public List<CatalogoResult> NuevosMateriales()
        {
            MenuRepositorio repo = new MenuRepositorio();
            //List<CatalogoResult> lista = repo.NuevosMateriales();
            var  lista = repo.NuevosMateriales();


            return lista;
        }
    }
}
