using BiblioTK.DAL.DataModel;
 using BiblioTK.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Infraestructura.Interfaces
{
    public interface ICatalogoRepositorio: IRepositorio<tbl_BiblioTK_Catalogo>
    {
      
        List<CatalogoResult> ListarTodosSP();
        List<CatalogoResult> listarTodosSPPaginado(int TamanoPagina, int PaginaActual);
        List<tbl_BiblioTK_Catalogo> ListarTodosPaginado(int TamanoPagina, int PaginaActual);
        tbl_BiblioTK_Catalogo ObtenerPorNombre(string NombreLibro);
        List<tbl_BiblioTK_Catalogo> ListarPorNombre(string NombreLibro);
    }
}
