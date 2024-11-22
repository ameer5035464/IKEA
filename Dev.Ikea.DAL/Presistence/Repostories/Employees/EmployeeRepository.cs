using Dev.Ikea.DAL.Models.Employees;
using Dev.Ikea.DAL.Presistence.Data;
using Dev.Ikea.DAL.Presistence.Repostories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Presistence.Repostories.Employees
{
    public class EmployeeRepository : RepositoryBase<Employee> , IEmployeeRepository
    {
		private readonly ApplicationDbContext _dbContext;

		public EmployeeRepository(ApplicationDbContext dbContext):base(dbContext)
        {
			_dbContext = dbContext;
		}
    }
}
