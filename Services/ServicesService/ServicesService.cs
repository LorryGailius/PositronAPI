using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Schedule;

namespace PositronAPI.Services.ServicesService
{
    public class ServicesService : IServicesService
    {
        private readonly AppDbContext _context;

        public ServicesService(AppDbContext context)
        {
            _context = context;
        }

        // Add a service
        public async Task<Service> CreateService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        // Remove a service
        public async Task<Service> DeleteService(long serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null)
            {
                return null;
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return service;
        }

        // Edit a service
        public async Task<Service> EditService(Service service, long serviceId)
        {
            var existingService = await _context.Services.FindAsync(serviceId);
            if (existingService == null)
            {
                return null;
            }

            existingService.EmployeeId = service.EmployeeId;
            existingService.Name = service.Name;
            existingService.Description = service.Description;
            existingService.Price = service.Price;
            existingService.Duration = service.Duration;
            existingService.Price = service.Price;
            existingService.Category = service.Category;

            await _context.SaveChangesAsync();

            return existingService;
        }

        // Get a service
        public async Task<Service> GetService(long serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null)
            {
                return null;
            }
            return service;
        }

        // Get all services based on category
        public async Task<List<Service>> GetServices(ServiceCategory serviceCategory, int top = 10, int skip = 0)
        {
            return await _context.Services.Where(s => s.Category == serviceCategory).Skip(skip).Take(top).ToListAsync();
        }
    }
}
