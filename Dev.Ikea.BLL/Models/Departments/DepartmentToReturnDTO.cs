using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dev.Ikea.BLL.Models.Departments
{
    public class DepartmentToReturnDTO
    {
        //Model Base Properties
        public int Id { get; set; }

        //Departments Properties
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        [Display(Name = "Date Of Creation")]
        public DateOnly CreationDate { get; set; }
    }
}
