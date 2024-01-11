using PositronAPI.Models.Order;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.OrderService;

namespace PositronAPI.Extensions;

public static class ServiceExtensions
{
    public static ServiceModelDTO ToModelDto(this Service service, ServiceOrder orderService) => new()
    {
        Name = service.Name,
        Description = service.Description,
        Subtotal = orderService.Subtotal,
        Duration = service.Duration,
        Quantity = orderService.Quantity,
        Category = service.Category,
    };
}