using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Employee;

namespace PositronAPI.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            Employee newEmployee = new()
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Role = employee.Role,
                Permission = employee.Permission,
                Wage = employee.Wage,

            };

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee;
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

        public async Task<Employee> EditEmployee(Employee employee, long employeeId)
        {
            var existingemployee = await _context.Employees.FindAsync(employeeId);
            if (existingemployee == null)
            {
                return null;
            }

            existingemployee.Name = employee.Name;
            existingemployee.Surname = employee.Surname;
            existingemployee.Role = employee.Role;
            existingemployee.Permission = employee.Permission;
            existingemployee.Wage = employee.Wage;

            await _context.SaveChangesAsync();

            return existingemployee;
        }

        public async Task<Employee> EditPermissions(long employeeId, Permission permission)
        {
            var existingemployee = await _context.Employees.FindAsync(employeeId);
            if (existingemployee == null)
            {
                return null;
            }
            existingemployee.Permission = permission;

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
    }
}
