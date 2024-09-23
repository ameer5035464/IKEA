using Dev.Ikea.BLL.Models.Departments;
using Dev.Ikea.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReturnDTO>GetAllDepartments();

        DepartmentDetailsToReturnDTO? GetDepartmentById(int id);

        int CreateDepartment(DepartmentCreateDTO department);

        int UpdateDepartment (DepartmentUpdateDTO department);

        bool DeleteDepartment(int id);

    }
}
