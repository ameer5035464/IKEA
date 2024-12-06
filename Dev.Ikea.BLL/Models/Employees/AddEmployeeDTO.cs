﻿using Dev.Ikea.DAL.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dev.Ikea.BLL.Models.Employees
{
    public class AddEmployeeDTO
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
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
    }
}
