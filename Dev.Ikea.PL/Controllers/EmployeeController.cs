using Dev.Ikea.BLL.Models.Employees;
using Dev.Ikea.BLL.Services.Departments;
using Dev.Ikea.BLL.Services.Employees;
using Dev.Ikea.PL.ViewModels.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Ikea.PL.Controllers
{
	[Authorize]
	public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employee;
        private readonly IDepartmentService _Department;

        public EmployeeController(IEmployeeService employee, IDepartmentService department)
        {
            _employee = employee;
            _Department = department;
        }

        [HttpGet]
        public IActionResult Index(string? search)
        {

            var employee = _employee.GetAllEmployees(search);

            return View(employee);

        }

        [HttpGet]
        public IActionResult Search(string? search)
        {
            var employee = _employee.GetAllEmployees(search);

            
            return PartialView("_EmployeeTablePartial", employee);

        }

        [HttpGet]
        public IActionResult GetEmployeeById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var employee = _employee.GetEmployeeById(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            ViewData["Departments"] = _Department.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var Addemployeee = _employee.AddEmployee(employee);

            if (Addemployeee > 0)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Not Created");
            return View(employee);
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var GetEmp = _employee.GetEmployeeById(id.Value);

            if (GetEmp == null)
            {
                return NotFound();
            }

            ViewData["Departments"] = _Department.GetAllDepartments();

            var ViewEmp = new EmployeeUpdateViewModel
            {
                Name = GetEmp.Name,
                Email = GetEmp.Email,
                Address = GetEmp.Address,
                Age = GetEmp.Age,
                EmployeeType = GetEmp.EmployeeType,
                IsActive = GetEmp.IsActive,
                PhoneNumber = GetEmp.PhoneNumber,
                Salary = GetEmp.Salary,
                Gender = GetEmp.Gender,
                DepartmentId = GetEmp.DepartmentId,
            };

            return View(ViewEmp);

        }

        [HttpPost]
        public IActionResult UpdateEmployee([FromRoute] int id, EmployeeUpdateViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            var EmpUpdate = new UpdateDto
            {
                Id = id,
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                Age = employee.Age,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Gender = employee.Gender,
                DepartmentId = employee.DepartmentId,
            };

            _employee.UpdateEmployee(EmpUpdate);

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            var EmpToDelete = _employee.DeleteEmployee(id);

            return RedirectToAction("Index");
        }
    }
}
