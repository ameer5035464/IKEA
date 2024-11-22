using Dev.Ikea.BLL.Models.Departments;
using Dev.Ikea.BLL.Services.Departments;
using Dev.Ikea.PL.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Ikea.PL.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var dept = _departmentService.GetAllDepartments();

            return View(dept);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentCreateDTO department)
        {
            if(!ModelState.IsValid)
            {
                return View(department);
            }

            var result = _departmentService.CreateDepartment(department);

            if (result > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
                ModelState.AddModelError(string.Empty, "Department not created");
                return View(department);    
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department == null)
                return NotFound();

            var MapDepartment = new DepartmentUpdateViewModel
            {
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate,
                Description = department.Description
            };

            return View(MapDepartment);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id,DepartmentUpdateViewModel department)
        {
            if (!ModelState.IsValid)
                return View(department);

            var DepartmetUpdate = new DepartmentUpdateDTO
            {
                Id = id,
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate,
                Description = department.Description
            };

			 _departmentService.UpdateDepartment(DepartmetUpdate) ;

           
                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id)
        {
            var DeleteItem = _departmentService.DeleteDepartment(id);

            return RedirectToAction("Index");
        }
    }
}
