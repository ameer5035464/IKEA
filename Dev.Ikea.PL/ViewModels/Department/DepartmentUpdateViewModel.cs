using System.ComponentModel.DataAnnotations;

namespace Dev.Ikea.PL.ViewModels.Department
{
    public class DepartmentUpdateViewModel
    {
        [Required(ErrorMessage ="Enter Valid Code")]
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name ="Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
