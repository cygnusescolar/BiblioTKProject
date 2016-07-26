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
 
            //! Aqui estamos modificando la lista para concatenar el link cuando el tipo de documento es YOUTUBE
            listaCatalogos.ForEach(x =>
            {
                if (x.Tipo == "YOUTUBE")
                    x.Link = "www.youtube.com/" + x.Link;

            });
            return listaCatalogos;
        }

        public CatalogoResult ObtenerLibroPorId(string id)
        {
            repo = new CatalogoRepositorio();
            CatalogoResult libro = repo.ObtenerPorId(id);
            return libro;
        }

        public string ObtenerUrlIframe(string id)
        {
            CatalogoResult libro = ObtenerLibroPorId(id);
            string urliframe = string.Empty;
            string tk1 = "00000000-0000-0000-0000-000000000000"; // aqui debe setearse el id user
            switch (libro.Tipo)
            {
                case "PDF":
                    urliframe = "http://biblio-tk.net/App_pdf/web/Default.aspx?tk1=" + tk1 + "&tk2=" + libro.catalogo_uid;
                    break;
                case "YOUTUBE":
                    urliframe = "https://www.youtube.com/embed/" + libro.Link;
                    break;
                default:
                    urliframe = libro.Link;
                    break;
            }
            return urliframe;
        }


    }
}
