using PositronAPI.Models.Employee;

namespace PositronAPI.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(long employeeId);
        Task<Employee> EditEmployee(EmployeeUpdateDTO employee, long employeeId);
        Task<Employee> GetEmployee(long employeeId);
        Task<List<Employee>> GetEmployees(int top = 10, int skip = 0);
        Task<List<Employee>> GetEmployees(long departmentId, int top = 10, int skip = 0);
        Task<List<Employee>> GetEmployees(Role role, int top = 10, int skip = 0);
    }
}
