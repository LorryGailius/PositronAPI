using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Extensions;
using PositronAPI.Models.Item;
using PositronAPI.Models.Order;
using PositronAPI.Models.Schedule;

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
        public async Task<Order> CreateOrder(OrderImportDTO order)
        {
            var newOrder = new Order() { CustomerId = order.CustomerId, Status = OrderStatus.Pending, Total = 0, TaxCode = order.TaxCode };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        // Add Item to Order
        public async Task<ItemModelDTO> AddItemToOrder(ItemOrder itemOrder)
        {
            _context.ItemOrders.Add(itemOrder);
            var item = await _context.Items.FindAsync(itemOrder.ItemId);
            var quantity = itemOrder.Quantity;
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == itemOrder.OrderId);
            order.Total += item.Price * quantity;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return item.ToModelDto(itemOrder);
        }

        // Add Service to Order
        public async Task<ServiceModelDTO> AddServiceToOrder(ServiceOrder serviceOrder)
        {
            _context.ServiceOrders.Add(serviceOrder);
            var service = await _context.Services.FindAsync(serviceOrder.ServiceId);
            var quantity = serviceOrder.Quantity;
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == serviceOrder.OrderId);
            order.Total += service.Price * quantity;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return service.ToModelDto(serviceOrder);
        }

        // Get Order
        public async Task<Order> GetOrder(long orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        // Get all ItemOrder instances
        public async Task<List<ItemModelDTO>> GetOrderItems(long orderId)
        {
            var orderItems = await _context.ItemOrders.Where(x => x.OrderId == orderId).ToListAsync();

            var items = await _context.Items.Where(x => orderItems.Select(y => y.ItemId).Contains(x.Id)).ToListAsync();

            var itemModels = new List<ItemModelDTO>();

            foreach (var item in items)
            {
                var itemOrder = orderItems.FirstOrDefault(x => x.ItemId == item.Id);

                itemModels.Add(item.ToModelDto(itemOrder));
            }

            return itemModels;
        }

        // Get all ServiceOrder instances
        public async Task<List<ServiceModelDTO>> GetOrderServices(long orderId)
        {
            var orderService = await _context.ServiceOrders.Where(x => x.OrderId == orderId).ToListAsync();

            var services = await _context.Services.Where(x => orderService.Select(y => y.ServiceId).Contains(x.Id)).ToListAsync();

            var serviceModels = new List<ServiceModelDTO>();

            foreach (var service in services)
            {
                var serviceOrder = orderService.FirstOrDefault(x => x.ServiceId == service.Id);

                serviceModels.Add(service.ToModelDto(serviceOrder));
            }

            return serviceModels;
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

        // Remove item from order
        public async Task<long> RemoveItemFromOrder(long orderId, long itemId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            var orderItem = await _context.ItemOrders.FirstOrDefaultAsync(x => x.OrderId == orderId && x.ItemId == itemId);

            if (orderItem is null)
            {
                return -1;
            }

            _context.ItemOrders.Remove(orderItem);
            await _context.SaveChangesAsync();
            return itemId;
        }

        // Remove service from order
        public async Task<long> RemoveServiceFromOrder(long orderId, long serviceId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            var orderService = await _context.ServiceOrders.FirstOrDefaultAsync(x => x.OrderId == orderId && x.ServiceId == serviceId);

            if (orderService is null)
            {
                return -1;
            }

            _context.ServiceOrders.Remove(orderService);
            await _context.SaveChangesAsync();
            return serviceId;
        }

        public double Subtotal(double price, int quantity)
        {
            return price * quantity;
        }
    }
}
