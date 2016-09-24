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

namespace BiblioTK.MVC.Controllers
{
    public class CatalogoController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;

        //public CatalogoController()
        //{
        //}

        //public CatalogoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}
        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        // GET: Catalogo

        //[OutputCache(Duration = 1800)] //? cache con duracion de 30 minutos para que no llame a BD en cada request 
        public ActionResult Index()
        {
            CatalogoIndexModelView modelo = new CatalogoIndexModelView();
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
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
    }
}