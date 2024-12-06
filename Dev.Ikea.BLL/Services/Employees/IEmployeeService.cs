using Dev.Ikea.BLL.Models.Employees;
using Dev.Ikea.DAL.Models.Employees;

namespace Dev.Ikea.BLL.Services.Employees
{
	public interface IEmployeeService
	{
		IEnumerable<GetAllDTO> GetAllEmployees(string search);

		Employee? GetEmployeeById(int id);

		int AddEmployee(AddEmployeeDTO employee);

		int UpdateEmployee(UpdateDto employee);

		bool DeleteEmployee(int id);
	}
}
