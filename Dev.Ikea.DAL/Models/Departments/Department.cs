using Dev.Ikea.DAL.Models.Employees;

namespace Dev.Ikea.DAL.Models.Departments
{
    public class Department : ModelBase
    {
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
