using Dev.Ikea.DAL.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Ikea.BLL.Models.Employees
{
    public class GetAllDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name ="Department")]
        public int? DepartmentId { get; set; }
        public int MyProperty { get; set; }
        public int? Age { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        public string? Department { get; set; }
    }
}
