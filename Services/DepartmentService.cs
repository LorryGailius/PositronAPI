using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Department;

namespace PositronAPI.Services
{
    public class DepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            Department newDepartment= new()
            {
                Name = department.Name,
                Id = department.Id,
                ManagerId = department.ManagerId,
            };

            _context.Departments.Add(newDepartment);
            await _context.SaveChangesAsync();
            return newDepartment;
        }

        public async Task<Department> DeleteDepartment(long departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department == null)
            {
                return null;
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> EditDepartment(Department department, long departmentId)
        {
            var existingDepartment = await _context.Departments.FindAsync(departmentId);
            if (existingDepartment == null)
            {
                return null;
            }

            existingDepartment.Id = department.Id;
            existingDepartment.ManagerId = department.ManagerId;
            existingDepartment.Name = department.Name;

            await _context.SaveChangesAsync();

            return existingDepartment;
        }

        public async Task<Department> GetDepartment(long departmentId)
        {
            var department = await _context.Departments.FindAsync(departmentId);
            if (department == null)
            {
                return null;
            }
            return department;
        }

        public async Task<List<Department>> GetDepartments(int top = 10, int skip = 0)
        {
            return await _context.Departments.Skip(skip).Take(top).ToListAsync();
        }

    }
}
