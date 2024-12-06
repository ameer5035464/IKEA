    using Dev.Ikea.DAL.Models;
using Dev.Ikea.DAL.Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Presistence.Repostories._Generic
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll(bool WithAsNoTracking = true)
        {
            return _dbContext.Set<T>().ToList();
        }

        public IQueryable<T> GetAllIQueryable()
        {
            return _dbContext.Set<T>();
        }

        public T? GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public int Add(T t)
        {
             _dbContext.Set<T>().Add(t);
            return _dbContext.SaveChanges();
        }
        public int Update(T t)
        {
            _dbContext.Set<T>().Update(t);  
            return _dbContext.SaveChanges();
        }

        public int Delete(T t)
        {
            _dbContext.Set<T>().Remove(t);
            return _dbContext.SaveChanges();
        }

    }
}
