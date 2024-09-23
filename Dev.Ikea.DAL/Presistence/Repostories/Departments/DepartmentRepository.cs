using Dev.Ikea.DAL.Models.Department;
using Dev.Ikea.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Dev.Ikea.DAL.Presistence.Repostories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAll(bool withAsNoTracking = true)
        {
            if (withAsNoTracking)
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
            return _dbContext.Departments.ToList();
        }

        public IQueryable<Department> GetAllIQueryable()
        {
            return _dbContext.Departments;
        }

        public Department? GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
           _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

    }
}
