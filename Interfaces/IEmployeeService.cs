using PositronAPI.Models.Employee;

namespace PositronAPI.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(long employeeId);
        Task<Employee> EditEmployee(Employee employee, long employeeId);
        Task<Employee> GetEmployee(long employeeId);
        Task<List<Employee>> GetEmployees(int top = 10, int skip = 0);
    }
}
