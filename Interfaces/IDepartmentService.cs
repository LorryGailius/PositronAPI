using PositronAPI.Models.Department;

namespace PositronAPI.Services.DepartmentService

{
    public interface IDepartmentService
    {
        Task<Department> CreateDepartment(Department department);
        Task<Department> DeleteDepartment(long departmentId);
        Task<Department> EditDepartment(Department department, long departmentId);
        Task<Department> GetDepartment(long departmentId);
        Task<List<Department>> GetDepartments(int top = 10, int skip = 0);
    }
}
