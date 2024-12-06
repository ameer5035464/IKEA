using Dev.Ikea.DAL.Common.Enums;
using Dev.Ikea.DAL.Models.Departments;

namespace Dev.Ikea.DAL.Models.Employees
{
    public class Employee : ModelBase
    {
        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }
        
        public virtual Department? Department { get; set; }
    }
}
