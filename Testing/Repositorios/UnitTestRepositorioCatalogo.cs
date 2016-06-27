using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiblioTK.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioTK.DAL.DataModel;

namespace BiblioTK.Infraestructura.Repositorios.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void ListarTodosTest()
        {
            CatalogoRepositorio catalogoRepositorio = new CatalogoRepositorio();

            var ListSP = catalogoRepositorio.ListarTodosSP();
          
            //Listar todos llamando al metodo generico "ListarTodos" RepositorioBase.ListarTodos
            var categoryList = catalogoRepositorio.ListarTodos();

            //Listar todos llamando al metodo generico "ListarTodos" 
            //RepositorioBase.ListarTodosPaginado
            var listapaginada = catalogoRepositorio.ListarTodosPaginado(10, 1);

            //Listar todos llamando al metodo generico "ListarTodos" 
            //RepositorioBase.Seleccionar. Puede ser que encuentre mas de un libro del 2002
            //pero siempre devolvera el primero (FirstOrDefault). un solo objeto y NO una lista.
            var libros = catalogoRepositorio.Seleccionar(x => x.cat_Año == "2002");
            //o puedo obtener una lista por el metodo filtrar
            var listafiltrada = catalogoRepositorio.Filtrar(x => x.cat_Año == "2002");


            //LOS SIGUIENTES METODOS SON ESPECIFICOS DE ICatalogoRepositorio y catalogoRepositorio.
            //si quiero botener un libro espeficico. Debo escribir el nombre exacto.
            //utilizar catalogoRepositorio.ObtenerPorNombre
            var libro = catalogoRepositorio.ObtenerPorNombre(".NET Framework 4.5 Expert Programming Cookbook ");

            //si quiero botener un libro pero No se el nombre exacto. paso una palabra clave
            //utilizar catalogoRepositorio.ListarPorNombre y Obtengo una lista de libros que
            //incluyen la palabra Cookbook
            var librosCookbook = catalogoRepositorio.ListarPorNombre("Cookbook");

          
            Assert.AreEqual(categoryList.Count(), 297);
        }

        [TestMethod()]
        public void AgregarNuevo()
        {
            CatalogoRepositorio catalogoRepositorio = new CatalogoRepositorio();

            tbl_BiblioTK_Catalogo nuevoLibro = new tbl_BiblioTK_Catalogo();
            nuevoLibro.cat_Titulo = "NUEVO LIBRO .NET";

            nuevoLibro.idioma_id = "ES";
            nuevoLibro.class1_id = "100";
            nuevoLibro.class2_id = ".100";
            nuevoLibro.class3_id = "+";
            nuevoLibro.class4_id = "+";
            nuevoLibro.cat_Año = "2016";
            nuevoLibro.Editorial_uid = new Guid("18173E49-E360-4EB3-8169-AF7FF19013EF"); //asimomos que este id lo tomamos de algun combo o listbox donde este la lista de editoriales. etc
            nuevoLibro.usuario_uid = new Guid("00000000-0000-0000-0000-000000000000");
            nuevoLibro.cat_Pais = "DNK";
            nuevoLibro.cat_status = 0;

            catalogoRepositorio.AgregarNuevo(nuevoLibro);


            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void ObtenerElNuevoLibro()
        {
            CatalogoRepositorio catalogoRepositorio = new CatalogoRepositorio();

            var libro = catalogoRepositorio.ObtenerPorNombre("NUEVO LIBRO .NET");


            Assert.AreEqual("NUEVO LIBRO .NET", libro.cat_Titulo, false, "No Existe"); //false indica que ignora el case-sentitive.
        }

        [TestMethod()]
        public void BorrarNuevoLibro()
        {
            CatalogoRepositorio catalogoRepositorio = new CatalogoRepositorio();
            
            //para utilizar el metodo borrar:

            //Puedo buscar la entidad y pasarla como parametro
            //var libro = catalogoRepositorio.ObtenerPorNombre("NUEVO LIBRO .NET");
            //catalogoRepositorio.Borrar(libro);

            //O puedo ejecutar directamente una expresion Lambda
            //Borrar el libro por el nombre O por ID, etc.
            catalogoRepositorio.Borrar(c => c.cat_Titulo.Equals("NUEVO LIBRO .NET"));

            Assert.AreEqual(1, 1);
        }
    }
}