using Dev.Ikea.DAL.Models.Employees;
using Dev.Ikea.DAL.Presistence.Repostories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.DAL.Presistence.Repostories.Employees
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        
    }
}
