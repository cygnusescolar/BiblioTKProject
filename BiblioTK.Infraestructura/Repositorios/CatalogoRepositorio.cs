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


        public List<CatalogoResult> ListarPorNombre(string NombreLibro, int TamanoPagina, int PaginaActual)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                //return context.tbl_BiblioTK_Catalogo.Where(x => x.cat_Titulo.Contains(NombreLibro)).ToList();
                var libros = (from q in context.tbl_BiblioTK_Catalogo_Autores
                              where q.tbl_BiblioTK_Catalogo.cat_Titulo.Contains(NombreLibro)
                              orderby
                                q.tbl_BiblioTK_Catalogo.cat_Titulo
                              select new CatalogoResult
                              {
                                  catalogo_uid = q.tbl_BiblioTK_Catalogo.catalogo_uid,
                                  Tipo = q.tbl_BiblioTK_Catalogo.cat_Upload_Tipo,
                                  cat_Titulo = q.tbl_BiblioTK_Catalogo.cat_Titulo,
                                  cat_Año = q.tbl_BiblioTK_Catalogo.cat_Año,
                                  cat_Edicion = q.tbl_BiblioTK_Catalogo.cat_Edicion,
                                  idioma_nombre = q.tbl_BiblioTK_Catalogo.tbl_BiblioTK_Idiomas.idioma_nombre,
                                  autor_nombrecompleto = q.tbl_BiblioTK_Autores.autor_apellido_paterno + (!string.IsNullOrEmpty(q.tbl_BiblioTK_Autores.autor_apellido_materno) ? ", " + q.tbl_BiblioTK_Autores.autor_apellido_materno : string.Empty),
                                  Link = q.tbl_BiblioTK_Catalogo.cat_Upload_Link
                              }).OrderBy(o => o.cat_Titulo).Skip(TamanoPagina * PaginaActual).Take(TamanoPagina).ToList();

                return libros;
            }
        }

        public CatalogoResult ObtenerPorId(string id)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {

                var libro = (from q in context.tbl_BiblioTK_Catalogo_Autores
                             where q.tbl_BiblioTK_Catalogo.catalogo_uid.ToString().Equals(id)
                             orderby
                               q.tbl_BiblioTK_Catalogo.cat_Titulo
                             select new CatalogoResult
                             {
                                 catalogo_uid = q.tbl_BiblioTK_Catalogo.catalogo_uid,
                                 Tipo = q.tbl_BiblioTK_Catalogo.cat_Upload_Tipo,
                                 cat_Titulo = q.tbl_BiblioTK_Catalogo.cat_Titulo,
                                 cat_Año = q.tbl_BiblioTK_Catalogo.cat_Año,
                                 cat_Edicion = q.tbl_BiblioTK_Catalogo.cat_Edicion,
                                 idioma_nombre = q.tbl_BiblioTK_Catalogo.tbl_BiblioTK_Idiomas.idioma_nombre,
                                 autor_nombrecompleto = q.tbl_BiblioTK_Autores.autor_apellido_paterno + (!string.IsNullOrEmpty(q.tbl_BiblioTK_Autores.autor_apellido_materno) ? ", " + q.tbl_BiblioTK_Autores.autor_apellido_materno : string.Empty),
                                 Link = q.tbl_BiblioTK_Catalogo.cat_Upload_Link
                             }).FirstOrDefault();

                return libro;
            }
        }

        public List<CatalogoResult> ListarCatalogoPorMenu(string nivel1, string nivel2, string nivel3, int TamanoPagina, int PaginaActual)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                var libros = (from q in context.tbl_BiblioTK_Catalogo_Autores
                              where q.tbl_BiblioTK_Catalogo.class1_id.Equals(nivel1) && q.tbl_BiblioTK_Catalogo.class2_id == nivel2
                              && q.tbl_BiblioTK_Catalogo.class3_id == nivel3 && q.tbl_BiblioTK_Catalogo.class4_id == "+"
                              //where q.tbl_BiblioTK_Catalogo.class1_id == nivel1 && q.tbl_BiblioTK_Catalogo.class2_id == nivel2
                              //&& q.tbl_BiblioTK_Catalogo.class3_id == nivel3 && q.tbl_BiblioTK_Catalogo.class4_id == "+"
                              orderby
                                q.tbl_BiblioTK_Catalogo.cat_Titulo
                              select new CatalogoResult
                              {
                                  catalogo_uid = q.tbl_BiblioTK_Catalogo.catalogo_uid,
                                  Tipo = q.tbl_BiblioTK_Catalogo.cat_Upload_Tipo,
                                  cat_Titulo = q.tbl_BiblioTK_Catalogo.cat_Titulo,
                                  cat_Año = q.tbl_BiblioTK_Catalogo.cat_Año,
                                  cat_Edicion = q.tbl_BiblioTK_Catalogo.cat_Edicion,
                                  idioma_nombre = q.tbl_BiblioTK_Catalogo.tbl_BiblioTK_Idiomas.idioma_nombre,
                                  autor_nombrecompleto = q.tbl_BiblioTK_Autores.autor_apellido_paterno + (!string.IsNullOrEmpty(q.tbl_BiblioTK_Autores.autor_apellido_materno) ? ", " + q.tbl_BiblioTK_Autores.autor_apellido_materno : string.Empty),
                                  Link = q.tbl_BiblioTK_Catalogo.cat_Upload_Link
                              }).Skip(TamanoPagina * PaginaActual).Take(TamanoPagina).ToList();

                return libros;
            }
        }

        public List<CatalogoResult> ListarCatalogoPorMenu(string nivel1, string nivel2, string nivel3, int TamanoPagina, int PaginaActual, bool flag)
        {
            Expression<Func<tbl_BiblioTK_Catalogo_Autores, bool>> ExpresionCondicional;
            if (nivel3 != null)
            {
                ExpresionCondicional =
                   q => q.tbl_BiblioTK_Catalogo.class1_id == nivel1
                   && q.tbl_BiblioTK_Catalogo.class2_id == nivel2
                   && q.tbl_BiblioTK_Catalogo.class3_id.Equals(nivel3);
            }
            else if (nivel2 != null)
            {
                ExpresionCondicional =
                    q => q.tbl_BiblioTK_Catalogo.class1_id == nivel1
                    && q.tbl_BiblioTK_Catalogo.class2_id == nivel2;
            }
            else 
            {
                ExpresionCondicional = q => q.tbl_BiblioTK_Catalogo.class1_id == nivel1;                    
            }

            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                var libros = context.tbl_BiblioTK_Catalogo_Autores.Where(ExpresionCondicional).Select(q =>
                  new CatalogoResult
                  {
                      catalogo_uid = q.tbl_BiblioTK_Catalogo.catalogo_uid,
                      Tipo = q.tbl_BiblioTK_Catalogo.cat_Upload_Tipo,
                      cat_Titulo = q.tbl_BiblioTK_Catalogo.cat_Titulo,
                      cat_Año = q.tbl_BiblioTK_Catalogo.cat_Año,
                      cat_Edicion = q.tbl_BiblioTK_Catalogo.cat_Edicion,
                      idioma_nombre = q.tbl_BiblioTK_Catalogo.tbl_BiblioTK_Idiomas.idioma_nombre,
                      autor_nombrecompleto = q.tbl_BiblioTK_Autores.autor_apellido_paterno + (!string.IsNullOrEmpty(q.tbl_BiblioTK_Autores.autor_apellido_materno) ? ", " + q.tbl_BiblioTK_Autores.autor_apellido_materno : string.Empty),
                      Link = q.tbl_BiblioTK_Catalogo.cat_Upload_Link
                  }).OrderBy(o => o.cat_Titulo).Skip(TamanoPagina * PaginaActual).Take(TamanoPagina).ToList();

                return libros;
            }
        }

    }
}
