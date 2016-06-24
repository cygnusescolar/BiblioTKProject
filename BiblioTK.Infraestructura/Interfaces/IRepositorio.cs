using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTK.Infraestructura.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        List<T> ListarTodos();

        T Seleccionar(Expression<Func<T, bool>> predicate);

        List<T> Filtrar(Expression<Func<T, bool>> predicate);
      
        void AgregarNuevo(T entity);
        void Actualizar(T entity);

        void Borrar(T entity);
        void Borrar(Expression<Func<T, bool>> predicate);

    }
}
