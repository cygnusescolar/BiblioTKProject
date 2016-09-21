using BiblioTK.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiblioTK.MVC.Models
{
    /// <summary>
    /// Este clase contiene 3 modelos o propiedades para cargar las secciones de
    /// ClasificacionPrincipal, La lista de libros y los tops(10/24hrs) y 
    /// la lista de los nuebos materiales
    /// </summary>
    public class CatalogoIndexModelView
    {

        public List<CatalogoResult> Libros { get; set; }
        public List<MenuResult> ClasificacionPrincipalMenu { get; set; }
        public List<CatalogoResult> Top10Menu { get; set; }
        public List<CatalogoResult> NuevosMaterialesMenu { get; set; }

    }
}