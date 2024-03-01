using MiPresupuestoApp.Data;
using MiPresupuestoApp.Negocio.Interface;
using System.Linq.Expressions;

namespace MiPresupuestoApp.Negocio
{
    public class GenericNegocio<T> : IGenericNegocio<T> where T : class
    {
        protected readonly Context _context;

        public GenericNegocio(Context context)
        {
            _context = context;
        }


        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAllByCondition(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).ToList();
        }

        public T GetByCondition(Expression<Func<T, bool>> where)
        {
            return _context.Set<T>().Where(where).FirstOrDefault()!;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id)!;
        }


        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Insert(T model)
        {
            _context.Set<T>().Add(model);
            return this.Save();
        }

        public bool Update(T model)
        {
            _context.Set<T>().Update(model);
            return this.Save();
        }
        
        public bool Delete(T model)
        {
            _context.Set<T>().Remove(model);
            return this.Save();
        }

    }
}
