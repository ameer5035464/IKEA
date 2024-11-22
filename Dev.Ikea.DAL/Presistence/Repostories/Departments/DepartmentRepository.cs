using Dev.Ikea.DAL.Models.Departments;
using Dev.Ikea.DAL.Presistence.Data;
using Dev.Ikea.DAL.Presistence.Repostories._Generic;
using Microsoft.EntityFrameworkCore;

namespace Dev.Ikea.DAL.Presistence.Repostories.Departments
{
    public class DepartmentRepository : RepositoryBase<Department> , IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext):base(dbContext)
        {
        }
    }
}
