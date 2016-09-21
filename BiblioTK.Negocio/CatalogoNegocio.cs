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

        #region ////MetodosLocales/////
        private static void ConfigurarEnlaceYouTube(List<CatalogoResult> listaCatalogos)
        {
            //! Aqui estamos modificando la lista para concatenar el link cuando el tipo de documento es YOUTUBE
            listaCatalogos.ForEach(x =>
            {
                if (x.Tipo == "YOUTUBE")
                    x.Link = "www.youtube.com/" + x.Link;

            });
        }
        #endregion

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

        public List<CatalogoResult> listarCatalogoPorSPPaginado(int TamanoPagina, int PaginaActual, bool isAuthenticated)
        {
            repo = new CatalogoRepositorio();
            List<CatalogoResult> listaCatalogos = repo.listarTodosSPPaginado(TamanoPagina, PaginaActual);
            ConfigurarEnlaceYouTube(listaCatalogos);
            ConfigurarRutaImagen(isAuthenticated, listaCatalogos);

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

        public List<CatalogoResult> ListarCatalogoPorMenu(string niveles, bool isAuthenticated, int TamanoPagina, int PaginaActual)
        {
            string[] levels = niveles.Split('-').ToArray();
            string nivel1 = "+";
            string nivel2 = "+";
            string nivel3 = "+";

            switch (int.Parse(levels[0]))
            {
                case 1:
                    nivel1 = levels[1];
                    break;
                case 2:
                    nivel1 = levels[1];
                    nivel2 = levels[2];
                    break;
                case 3:
                    nivel1 = levels[1];
                    nivel2 = levels[2];
                    nivel3 = levels[3];
                    break;
                default:
                    break;
            }
            repo = new CatalogoRepositorio();
            List<CatalogoResult> listaCatalogos = repo.ListarCatalogoPorMenu(nivel1, nivel2, nivel3, TamanoPagina, PaginaActual);
            ConfigurarEnlaceYouTube(listaCatalogos);
            ConfigurarRutaImagen(isAuthenticated, listaCatalogos);
            return listaCatalogos;
        }

        private static void ConfigurarRutaImagen(bool isAuthenticated, List<CatalogoResult> listaCatalogos)
        {
            listaCatalogos.ForEach(x =>
            {
                if (isAuthenticated)
                {
                    if (x.Tipo == "YOUTUBE")
                    {
                        x.imagenRuta = "Content/images/youtubeColor.png";
                    }
                    else if (x.Tipo == "PDF")
                    {
                        x.imagenRuta = "Content/images/acrobatColor80.png";
                    }
                    else if (x.Tipo == "LINK")
                    {
                        x.imagenRuta = "Content/images/LINKColor.png";
                    }
                }
                else
                {
                    if (x.Tipo == "YOUTUBE")
                    {
                        x.imagenRuta = "Content/images/youtubeBlanco.png";
                    }
                    else if (x.Tipo == "PDF")
                    {
                        x.imagenRuta = "Content/images/acrobatBlanco80.png";
                    }
                    else if (x.Tipo == "LINK")
                    {
                        x.imagenRuta = "Content/images/LINKBlanco.png";
                    }
                }
            });
        }

        public List<CatalogoResult> BuscarPorTitulo(bool isAuthenticated, string NombreLibro)
        {
            repo = new CatalogoRepositorio();
            List<CatalogoResult> listaCatalogos = repo.ListarPorNombre(NombreLibro);
            ConfigurarEnlaceYouTube(listaCatalogos);
            ConfigurarRutaImagen(isAuthenticated, listaCatalogos);

            return listaCatalogos;
        }

    }
}
