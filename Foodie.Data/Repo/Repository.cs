using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodie.Data.Entity;

namespace Foodie.Data.Repo
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private static List<T> _entities;
        public Repository()
        {
            _entities = new List<T>();
        }
 
        public T First(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _entities.AsQueryable().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable().Distinct() ?? new List<T>().AsQueryable();
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _entities.AsQueryable().Where(predicate);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void Clear()
        {
            _entities = new List<T>();
        }
    }
}
