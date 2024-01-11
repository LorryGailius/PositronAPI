using PositronAPI.Models.Schedule;

namespace PositronAPI.Services.ServicesService
{
    public interface IServicesService
    {
        Task<Service> CreateService(ServiceImportDTO service);
        Task<Service> DeleteService(long serviceId);
        Task<Service> EditService(ServiceUpdateDTO service, long serviceId);
        Task<Service> GetService(long serviceId);
        Task<List<Service>> GetServices(ServiceCategory serviceCategory, int top = 10, int skip = 0);
    }
}
