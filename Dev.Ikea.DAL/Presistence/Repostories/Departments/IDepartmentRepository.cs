using Dev.Ikea.DAL.Models.Department;

namespace Dev.Ikea.DAL.Presistence.Repostories.Departments
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool withAsNoTracking = true);

        IQueryable<Department> GetAllIQueryable();

        Department? GetById(int id);

        int Add(Department department);

        int Update(Department department);

        int Delete(Department department);
    }
}
