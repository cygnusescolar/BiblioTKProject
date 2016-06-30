using BiblioTK.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiblioTKProject.Models
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            CatalogoIndexModelView modelo = new CatalogoIndexModelView();
            CatalogoNegocio objCatalogo = new CatalogoNegocio();
            modelo.Libros  = objCatalogo.listarCatalogoPorSPPaginado(10, 7);
            modelo.ClasificacionPrincipalMenu = objCatalogo.ListarClasificaionesPrincipales();
            modelo.Top10Menu = objCatalogo.ListarTop10(DateTime.Now.AddDays(-30));

            return View(modelo);
        }
    }
}