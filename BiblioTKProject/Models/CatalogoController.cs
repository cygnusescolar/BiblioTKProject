using BiblioTK.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Caching;

namespace BiblioTKProject.Models
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        [OutputCache(Duration = 30)]
        public ActionResult Index()
        {
            CatalogoIndexModelView modelo = new CatalogoIndexModelView();
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            MenuNegocio objMenu = new MenuNegocio();
            //modelo.Libros = objCatalogo.listarCatalogoPorSPPaginado(10, 1);
            modelo.ClasificacionPrincipalMenu = objMenu.ListarClasificaionesPrincipales();
            modelo.Top10Menu = objMenu.ListarTop10(FuncionesVB.FuncionesGenerales.Takoma_UTCToMexCentral());
            modelo.NuevosMaterialesMenu = objMenu.NuevosMateriales();

            return View(modelo);
        }

         public ActionResult GetData(int pageIndex, int pageSize)
        {
             CatalogoNegocio objCatalogo = new CatalogoNegocio();
             var Libros = objCatalogo.listarCatalogoPorSPPaginado(pageSize, pageIndex);

            return Json(Libros.ToList(), JsonRequestBehavior.AllowGet);
        }



    }



}