using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Order;

namespace PositronAPI.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        // Create Order
        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        // Add Item to Order
        public async Task<ItemOrder> AddItemToOrder(ItemOrder itemOrder)
        {
            _context.ItemOrders.Add(itemOrder);
            await _context.SaveChangesAsync();
            return itemOrder;
        }

        // Add Service to Order
        public async Task<ServiceOrder> AddServiceToOrder(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Add(serviceOrder);
            await _context.SaveChangesAsync();
            return serviceOrder;
        }

        // Get Order
        public async Task<Order> GetOrder(long orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        // Get all ItemOrder instances
        public async Task<List<ItemOrder>> GetOrderItems(long orderId)
        {
            return await _context.ItemOrders.Where(x => x.OrderId == orderId).ToListAsync();
        }

        // Get all ServiceOrder instances
        public async Task<List<ServiceOrder>> GetOrderServices(long orderId)
        {
            return await _context.ServiceOrders.Where(x => x.OrderId == orderId).ToListAsync();
        }

        // Edit Order
        public async Task<Order> EditOrder(Order order, long orderId)
        {
            var existingOrder = await _context.Orders.FindAsync(orderId);
            if (existingOrder == null)
            {
                return null;
            }

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.Status = order.Status;
            existingOrder.Total = order.Total;
            existingOrder.TaxCode = order.TaxCode;

            await _context.SaveChangesAsync();

            return existingOrder;
        }

        public decimal Subtotal(decimal price, int quantity)
        {
            return price * quantity;
        }
    }
}
