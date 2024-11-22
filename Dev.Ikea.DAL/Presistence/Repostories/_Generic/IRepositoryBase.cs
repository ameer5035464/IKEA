using Dev.Ikea.DAL.Models;
using Dev.Ikea.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Presistence.Repostories._Generic
{
    public interface IRepositoryBase<T> where T : ModelBase
    {
        IEnumerable<T> GetAll(bool WithAsNoTracking = true);

        IQueryable<T> GetAllIQueryable();

        T? GetById(int id);

        int Add(T t);

        int Update(T t);

        int Delete(T t);
    }
}
