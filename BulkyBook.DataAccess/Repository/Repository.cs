using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.products.Include(u => u.Category);
            dbset = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> entities = dbset;
            if (includeProperties != null)
            {

                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    entities = entities.Include(includeProp);
                }
            }
            return entities;
        }

        public T GetFirstorDefalt(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> entities = dbset;

            if (includeProperties != null)
            {

                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    entities = entities.Include(includeProp);
                }
            }

            entities = entities.Where(filter);
            return entities.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }
    }
}
