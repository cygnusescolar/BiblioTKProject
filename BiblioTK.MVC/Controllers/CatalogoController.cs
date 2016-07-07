using BiblioTK.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;
using Microsoft.AspNet.Identity.Owin;
using BiblioTK.MVC.Models;

namespace BiblioTK.MVC.Controllers
{
    public class CatalogoController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public CatalogoController()
        {
        }

        public CatalogoController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Catalogo
        [OutputCache(Duration = 1800)] //? cache con duracion de 30 minutos para que no llame a BD en cada request 
        public ActionResult Index()
        {
            CatalogoIndexModelView modelo = new CatalogoIndexModelView();
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            MenuNegocio objMenu = new MenuNegocio();
            //modelo.Libros = objCatalogo.listarCatalogoPorSPPaginado(10, 1);
            modelo.ClasificacionPrincipalMenu = objMenu.ListarClasificaionesPrincipales();
            modelo.Top10Menu = objMenu.ListarTop10(FuncionesVB.FuncionesGenerales.Takoma_UTCToMexCentral().AddDays(-1));
            modelo.NuevosMaterialesMenu = objMenu.NuevosMateriales();

            return View(modelo);
        }

        public ActionResult GetData(int pageIndex, int pageSize)
        {
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            var Libros = objCatalogo.listarCatalogoPorSPPaginado(pageSize, pageIndex);

            Libros.ForEach(x =>
            {
                if (true)
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

            return Json(Libros.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult CargarLibro()
        {
       
            return View("Libro");
        }

        
    }
}