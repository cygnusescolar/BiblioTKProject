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
            var nivel11 = objMenu.ListarClasificaionesPrincipales();

            modelo.ClasificacionPrincipalMenu = (from n1 in nivel11
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




            modelo.Top10Menu = objMenu.ListarTop10(FuncionesVB.FuncionesGenerales.Takoma_UTCToMexCentral().AddDays(-1));
            modelo.NuevosMaterialesMenu = objMenu.NuevosMateriales();

            return View(modelo);
        }

        ///atributo que espeficica que este metodo solo sera llamado via ajax
        [AjaxOnly]
        public PartialViewResult GetData(int pageIndex, int pageSize)
        {
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            var Libros = objCatalogo.listarCatalogoPorSPPaginado(pageSize, pageIndex);

            Libros.ForEach(x =>
            {
                if (User.Identity.IsAuthenticated)
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


            //return Json(Libros.ToList(), JsonRequestBehavior.AllowGet);
            return PartialView("Catalogo", Libros.ToList());

        }

        [Authorize]
        public ActionResult CargarLibro(string idLibro)
        {
            string filePath = "Pdf1.pdf";//nombre del libro o id
            //filePath = "/MyPDFs/" + filePath; //Ruta y nombre o id

            //por ahora en produccion hasta que se defina la ruta de los libros
            filePath = ""; //Ruta y nombre o id

            ViewBag.filePath = filePath;

            return View("Libro");
        }



    }
}