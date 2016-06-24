using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BiblioTK.Infraestructura.Interfaces;
using BiblioTK.DAL.DataModel;

namespace BiblioTK.Infraestructura.Repositorios
{
    public abstract class RepositorioBase<T> : IRepositorio<T> where T : class
    {

        public List<T> ListarTodos()
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Set<T>().ToList();
            }
        }

        public T Seleccionar(Expression<Func<T, bool>> predicate)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Set<T>().FirstOrDefault(predicate);
            }
        }

   
        public List<T> Filtrar(Expression<Func<T, bool>> predicate)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                return context.Set<T>().Where(predicate).ToList();
            }
        }

 
        public void AgregarNuevo(T entity)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
    

        public void Actualizar(T entity)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Borrar(T entity)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Borrar(Expression<Func<T, bool>> predicate)
        {
            using (CygnusBiblioTKv2Entities context = new CygnusBiblioTKv2Entities())
            {
                var entities = context.Set<T>().Where(predicate).ToList();
                entities.ForEach(x => context.Entry(x).State = EntityState.Deleted);
                context.SaveChanges();
            }
        }
        
    }
}
