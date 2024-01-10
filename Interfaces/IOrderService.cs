using PositronAPI.Models.Order;

namespace PositronAPI.Services.OrderService
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(Order order);
        Task<ItemOrder> AddItemToOrder(ItemOrder itemOrder);
        Task<ServiceOrder> AddServiceToOrder(ServiceOrder serviceOrder);
        Task<Order> GetOrder(long orderId);
        Task<List<ItemOrder>> GetOrderItems(long orderId);
        Task<List<ServiceOrder>> GetOrderServices(long orderId);
        Task<Order> EditOrder(Order order, long orderId);
        decimal Subtotal(decimal price, int quantity);
    }
}
