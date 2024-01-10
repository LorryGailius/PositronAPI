using PositronAPI.Models.Schedule;

namespace PositronAPI.Services.ServicesService
{
    public interface IServicesService
    {
        Task<Service> CreateService(Service service);
        Task<Service> DeleteService(long serviceId);
        Task<Service> EditService(Service service, long serviceId);
        Task<Service> GetService(long serviceId);
        Task<List<Service>> GetServices(ServiceCategory serviceCategory, int top = 10, int skip = 0);
    }
}
