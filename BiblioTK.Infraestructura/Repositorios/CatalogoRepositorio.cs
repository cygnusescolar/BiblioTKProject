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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BiblioTK.Infraestructura.Repositorios
{
    public class CatalogoRepositorio : RepositorioBase<tbl_BiblioTK_Catalogo>, ICatalogoRepositorio
    {


        //public List<CatalogoResult> ListarTodosSPNoEF()
        //{

        //    List<CatalogoResult> TestList = new List<CatalogoResult>();
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CygnusBiblioTKv2Entities"].ToString()))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SP_ListarCatalogo", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
 
        //            con.Open();
        //            cmd.ExecuteNonQuery();

        //            SqlDataReader reader = cmd.e.ExecuteReader();

        //            CatalogoResult test;

        //            while (reader.Read() && reader.)
        //            {
        //                test = new CatalogoResult();
        //                test.catalogo_uid = (Guid) reader["catalogo_uid"];
        //                test.cat_Titulo = reader["cat_Titulo"].ToString();
        //                test.idioma_nombre = reader["idioma_nombre"].ToString();
        //                test.cat_Año = reader["cat_Año"].ToString();
        //                test.autor_nombrecompleto = reader["autor_nombrecompleto"].ToString();
        //                test.Tipo = reader["Tipo"].ToString();
        //                test.Link = reader["Link"].ToString();
        //                TestList.Add(test);
        //            }
        //        }
        //    }
        //    return TestList;

        //}

        public List<CatalogoResult> ListarTodosSP()
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Database.SqlQuery<CatalogoResult>("SP_ListarCatalogo").ToList();
            }
        }

        public List<CatalogoResult> listarTodosSPPaginado(int TamanoPagina, int PaginaActual)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Database.SqlQuery<CatalogoResult>("SP_ListarCatalogo").Skip(TamanoPagina * PaginaActual).Take(TamanoPagina).ToList();
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
