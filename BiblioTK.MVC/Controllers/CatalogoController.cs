using BiblioTK.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;
using Microsoft.AspNet.Identity.Owin;
using BiblioTK.MVC.Models;
using BiblioTK.Modelos;
using FuncionesVB;
using System.Web.UI;

namespace BiblioTK.MVC.Controllers
{
    public class CatalogoController : Controller
    {
 
        [OutputCache(NoStore = true, Duration = 30, VaryByCustom = "User")]
        public ActionResult Index()
        {
            CatalogoIndexModelView modelo = new CatalogoIndexModelView();
            MenuNegocio objMenu = new MenuNegocio();
            modelo.ClasificacionPrincipalMenu = objMenu.ListarClasificaionesPrincipales();
            modelo.Top10Menu = objMenu.ListarTop10(FuncionesGenerales.UtcToMexCentral());
            modelo.NuevosMaterialesMenu = objMenu.NuevosMateriales();
            return View(modelo);
        }

        ///atributo que espeficica que este metodo solo sera llamado via ajax
        [AjaxOnly]
        public PartialViewResult GetData(int pageIndex, int pageSize)
        {
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            var Libros = objCatalogo.listarCatalogoPorSPPaginado(pageSize, pageIndex, User.Identity.IsAuthenticated);
            return PartialView("Catalogo", Libros.ToList());

        }

        [Authorize]
        public ActionResult CargarLibro(string idLibro)
        {
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            string urliframe = objCatalogo.ObtenerUrlIframe(idLibro);
            return View("Libro", null, urliframe);
        }

        [AjaxOnly]
        public PartialViewResult CargarCatalogoFiltrado(string level, int pageSize, int pageIndex)
        {
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            var Libros = objCatalogo.ListarCatalogoPorMenu(level, User.Identity.IsAuthenticated, pageSize, pageIndex);
            //ViewBag.TotalLibros = Libros.Count.ToString();
            return PartialView("Catalogo", Libros.ToList());
        }

        public PartialViewResult BuscarPorTitulo(string searchText, int pageIndex, int pageSize)
        {
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            var Libros = objCatalogo.BuscarPorTitulo(User.Identity.IsAuthenticated, searchText, pageIndex, pageSize);
            return PartialView("Catalogo", Libros.ToList());
        }

        public PartialViewResult ListarPorTipo(string Tipo, int pageIndex, int pageSize)
        { 
            Tipo = (Tipo == "Videos") ? "YOUTUBE" : "LINK" ;
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            var Libros = objCatalogo.ListarPorTipo(Tipo, User.Identity.IsAuthenticated, pageIndex, pageSize);
            return PartialView("Catalogo", Libros.ToList());
        }
    }
}