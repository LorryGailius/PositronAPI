using PositronAPI.Models.Order;
using PositronAPI.Models.Schedule;

namespace PositronAPI.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderImportDTO order);
        Task<ItemModelDTO> AddItemToOrder(ItemOrder itemOrder);
        Task<ServiceModelDTO> AddServiceToOrder(ServiceOrder serviceOrder);
        Task<Order> GetOrder(long orderId);
        Task<List<ItemModelDTO>> GetOrderItems(long orderId);
        Task<List<ServiceModelDTO>> GetOrderServices(long orderId);
        Task<long> RemoveItemFromOrder(long orderId, long itemId);
        Task<long> RemoveServiceFromOrder(long orderId, long serviceId);
        Task<Order> EditOrder(Order order, long orderId);
        double Subtotal(double price, int quantity);
    }
}
