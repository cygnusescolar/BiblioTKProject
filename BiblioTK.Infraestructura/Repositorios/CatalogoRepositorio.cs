using BiblioTK.Infraestructura.Repositorios;
using BiblioTK.Infraestructura.Interfaces;
using BiblioTK.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using BiblioTK.DAL.DataModel;

namespace BiblioTK.Infraestructura.Repositorios
{
    public class CatalogoRepositorio : RepositorioBase<tbl_BiblioTK_Catalogo>, ICatalogoRepositorio
    {

        public List<SP_ListarCatalogo_Result> ListarTodosSP()
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Database.SqlQuery<SP_ListarCatalogo_Result>("SP_ListarCatalogo").ToList();
            }
        }

        /// <summary>
        /// Metodo para obtener la lista de libros de 10 en 10
        /// </summary>
        /// <param name="TamanoPagina">candidad de libros a mostrar por pagina</param>
        /// <param name="PaginaActual">pagina que esta mostrando los libros actualmente. ej: pagina 5.</param>
        /// <returns></returns>
        public List<tbl_BiblioTK_Catalogo> ListarTodosPaginado(int TamanoPagina, int PaginaActual)
        {
            try
            {
                using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
                {
                    return context.Set<tbl_BiblioTK_Catalogo>().OrderByDescending(x => x.catalogo_uid).Skip(TamanoPagina * PaginaActual).Take(TamanoPagina).ToList();
                }
            }
            catch (Exception ex)
            {

                return new List<tbl_BiblioTK_Catalogo>();
            }
        }

        /// <summary>
        /// Buscar un libro por el nombre
        /// </summary>
        /// <returns></returns>
        public tbl_BiblioTK_Catalogo ObtenerPorNombre(string NombreLibro)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.tbl_BiblioTK_Catalogo.Where(x => x.cat_Titulo.Equals(NombreLibro)).FirstOrDefault();
            }
        }

        public List<tbl_BiblioTK_Catalogo> ListarPorNombre(string NombreLibro)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.tbl_BiblioTK_Catalogo.Where(x => x.cat_Titulo.Contains(NombreLibro)).ToList();
            }
        }

    }
}
