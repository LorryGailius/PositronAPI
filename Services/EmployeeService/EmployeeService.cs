using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Employee;

namespace PositronAPI.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            if (!Enum.IsDefined(typeof(Role), employee.Role)) return null;

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(long employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return null;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> EditEmployee(EmployeeUpdateDTO employee, long employeeId)
        {
            var existingemployee = await _context.Employees.FindAsync(employeeId);
            if (existingemployee == null)
            {
                return null;
            }

            existingemployee.Name = employee.Name;
            existingemployee.Surname = employee.Surname;
            existingemployee.Role = employee.Role;
            existingemployee.Wage = employee.Wage;

            await _context.SaveChangesAsync();

            return existingemployee;
        }

        public async Task<Employee> GetEmployee(long employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                return null;
            }
            return employee;
        }

        public async Task<List<Employee>> GetEmployees(int top = 10, int skip = 0)
        {
            return await _context.Employees.Skip(skip).Take(top).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployees(long departmentId, int top = 10, int skip = 0)
        {
            return await _context.Employees.Where(e => e.DepartmentId == departmentId).Skip(skip).Take(top).ToListAsync();
        }

        public async Task<List<Employee>> GetEmployees(Role role, int top = 10, int skip = 0)
        {
            return await _context.Employees.Where(e => e.Role == role).Skip(skip).Take(top).ToListAsync();
        }
    }
}
