namespace Dev.Ikea.BLL.Models.Departments
{
    public class DepartmentToReturnDTO
    {
        //Model Base Properties
        public int Id { get; set; }

        //Departments Properties
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
