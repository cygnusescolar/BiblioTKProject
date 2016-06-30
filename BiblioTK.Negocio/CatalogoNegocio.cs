using BiblioTK.Infraestructura.Repositorios;
using BiblioTK.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Negocio
{
    public class CatalogoNegocio
    {
        CatalogoRepositorio repo;

        public CatalogoNegocio()
        {
            //Inicializamos el repositorio al instanciar CatalogoNegocio
           
        }


        public List<CatalogoResult> listarCatalogoPorSP()
        {
            repo = new CatalogoRepositorio();
            List<CatalogoResult> listaCatalogos = repo.ListarTodosSP();

            //Aqui estamos modificando la lista para concatenar el link cuando el tipo de documento es YOUTUBE
            listaCatalogos.ForEach(x =>
            {
                if (x.Tipo == "YOUTUBE")
                    x.Link = "www.youtube.com/" + x.Link;

            });
            return listaCatalogos;
        }


        public List<CatalogoResult> listarCatalogoPorSPPaginado(int TamanoPagina, int PaginaActual)
        {
            repo = new CatalogoRepositorio();
            List<CatalogoResult> listaCatalogos = repo.listarTodosSPPaginado(TamanoPagina, PaginaActual);

            //Aqui estamos modificando la lista para concatenar el link cuando el tipo de documento es YOUTUBE
            listaCatalogos.ForEach(x =>
            {
                if (x.Tipo == "YOUTUBE")
                    x.Link = "www.youtube.com/" + x.Link;

            });
            return listaCatalogos;
        }

        public List<ClasficacionPrincipalResult> ListarClasificaionesPrincipales()
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<ClasficacionPrincipalResult> lista = repo.ListarClasificaionesPrincipales();

          
            return lista;
        }

        public List<CatalogoResult> ListarTop10(DateTime fecha)
        {
            MenuRepositorio repo = new MenuRepositorio();
            List<CatalogoResult> lista = repo.ListarTop24(fecha);


            return lista;
        }
    }
}
