using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Order;
using PositronAPI.Models.Item;
using PositronAPI.Services.CustomerService;
using PositronAPI.Services.OrderService;
using PositronAPI.Services.ItemService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly CustomerService _customerService;
        private readonly ItemService _itemService;

        public OrdersController(OrderService orderService, CustomerService customerService, ItemService itemService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _itemService = itemService;
        }

        /// <summary>
        /// Create a new order.
        /// </summary>
        /// <remarks>Creates an order.</remarks>
        /// <param name="body">The properties for creating a new order.</param>
        /// <returns>The created order.</returns>
        [HttpPost]
        [Route("/order")]
        public async Task<ActionResult<Order>> CreateOrder([FromBody][Required] Order body)
        {
            if (await IsValidOrder(body)) 
            {
                var newOrder = new Order { CustomerId = body.CustomerId, Status = body.Status, Total = body.Total, TaxCode  = body.TaxCode };

                var response = await _orderService.CreateOrder(newOrder);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
            }

            return BadRequest("Given object is not valid");
        }

        [HttpPost]
        [Route("/order/{orderId}/additem/{itemId}/{quantity}")]
        public async Task<ActionResult> AddItemToOrder([FromRoute][Required] long orderId,
                                                       [FromRoute][Required] long itemId, [FromRoute][Required] int quantity)
        {
            var responseOrder = await _orderService.GetOrder(orderId);
            var responseItem = await _itemService.GetItem(itemId);

            if (responseOrder == null || responseItem == null) { return NotFound(); }

            decimal subtotal = quantity * responseItem.Price;

            ItemOrder itemOrder = new ItemOrder { OrderId = orderId, ItemId = itemId, Quantity = quantity, Subtotal = subtotal};

            var response = _orderService.AddItemToOrder(itemOrder);

            if (response == null) { return BadRequest(); }
            else { return Created(String.Empty, response); }
        }

        // AddServiceToOrder(ServiceOrder serviceOrder)

        // GetOrder(long orderId)

        // GetOrderItems(long orderId)

        // GetOrderServices(long orderId)

        // EditOrder(Order order, long orderId)

        public async Task<bool> IsValidOrder(Order order)
        {
            if (order == null ||
               order.CustomerId == 0 ||
               order.Status == OrderStatus.Pending ||
               !Enum.IsDefined(typeof(TaxCode), order.TaxCode)) { return false; }

            if(order.CustomerId.HasValue)
            {
                long customerIdNotNull = order.CustomerId.Value;
                var customer = await _customerService.GetCustomer(customerIdNotNull);

                if (customer == null) { return false; }
            }

            return true;
        }
    }
}