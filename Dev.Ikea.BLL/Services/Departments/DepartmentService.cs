using Dev.Ikea.BLL.Models.Departments;
using Dev.Ikea.DAL.Models.Department;
using Dev.Ikea.DAL.Presistence.Repostories.Departments;
using Microsoft.EntityFrameworkCore;

namespace Dev.Ikea.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentToReturnDTO> GetAllDepartments()
        {
            var dept = _departmentRepository.GetAllIQueryable().Select(D => new DepartmentToReturnDTO
            {
                Name = D.Name,
                Description = D.Description,
                CreationDate = D.CreationDate,
                Id = D.Id
            }).AsNoTracking().ToList();

            return dept;
        }

        public DepartmentDetailsToReturnDTO? GetDepartmentById(int id)
        {
            var dept = _departmentRepository.GetById(id);

            if (dept != null)
            {
                return new DepartmentDetailsToReturnDTO
                {
                    Id = dept.Id,
                    Name = dept.Name,
                    Description = dept.Description,
                    CreationDate = dept.CreationDate,
                    Code = dept.Code,
                    CreatedBy = dept.CreatedBy,
                    CreatedOn = dept.CreatedOn,
                    IsDeleted = dept.IsDeleted,
                    LastModifiedBy = dept.LastModifiedBy,
                    LastModifiedOn = dept.LastModifiedOn,
                };
            }
            return null;
        }

        public int CreateDepartment(DepartmentCreateDTO department)
        {
            var CreateDep = new Department
            {
                Id = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = 1,
                LastModifiedOn = DateTime.Now,
                LastModifiedBy = 1
            };

            return _departmentRepository.Add(CreateDep);
        }

        public int UpdateDepartment(DepartmentUpdateDTO department)
        {
            var dept = new Department
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                Code = department.Code,
                LastModifiedOn = DateTime.Now,
                LastModifiedBy = 1
            };
            return _departmentRepository.Update(dept);
        }

        public bool DeleteDepartment(int id)
        {
            var dept = _departmentRepository.GetById(id);

            if (dept != null)
            {
                return _departmentRepository.Delete(dept) > 0;
            }
            return false;
        }

    }
}
