using Dev.Ikea.BLL.Models.Employees;
using Dev.Ikea.DAL.Models.Departments;
using Dev.Ikea.DAL.Models.Employees;
using Dev.Ikea.DAL.Presistence.Repostories.Employees;
using Microsoft.EntityFrameworkCore;

namespace Dev.Ikea.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeService(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public IEnumerable<GetAllDTO> GetAllEmployees(string search)
        {
			var Employee = _employee.GetAllIQueryable().Where(E => E.IsDeleted == false && (string.IsNullOrEmpty(search) || E.Name.ToLower().Contains(search.ToLower()))).Select(E => new GetAllDTO
            {
                Id = E.Id,
                Name = E.Name,
                Age = E.Age,
                Email = E.Email,
                EmployeeType = E.EmployeeType,
                Gender = E.Gender,
                HiringDate = E.HiringDate,
                IsActive = E.IsActive,
                PhoneNumber = E.PhoneNumber,
                DepartmentId = E.DepartmentId,
                Department = E.Department.Name
            }).AsNoTracking().ToList();

            return Employee;
        }

        public Employee? GetEmployeeById(int id)
        {
            var Employee = _employee.GetById(id);

            if (Employee != null)
            {
                return Employee;
            }
            return null;

        }

        public int AddEmployee(AddEmployeeDTO employee)
        {
            var Employee = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                Salary = employee.Salary,
                CreatedBy = 1,
                LastModifiedBy = 3,
                LastModifiedOn = DateTime.UtcNow,
                DepartmentId = employee.DepartmentId
            };

            return _employee.Add(Employee);
        }

        public int UpdateEmployee(UpdateDto employee)
        {
            var Employee = new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                EmployeeType = employee.EmployeeType,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Gender= employee.Gender,
                CreatedBy= 1,
                LastModifiedBy = 3,
                LastModifiedOn = DateTime.UtcNow,
                DepartmentId = employee.DepartmentId
            };

            return _employee.Update(Employee);
        }

        public bool DeleteEmployee(int id)
        {
            var GetDelete = _employee.GetById(id);

            if (GetDelete != null)
            {
                return _employee.Delete(GetDelete) > 0;
            }
            return false;
        }

    }
}
