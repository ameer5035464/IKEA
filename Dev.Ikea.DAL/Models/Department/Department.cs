namespace Dev.Ikea.DAL.Models.Department
{
    public class Department : ModelBase
    {
        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
