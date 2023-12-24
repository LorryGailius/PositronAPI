﻿using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Order;
using PositronAPI.Models.Item;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.CustomerService;
using PositronAPI.Services.OrderService;
using PositronAPI.Services.ItemService;
using PositronAPI.Services.ServicesService;
using System.ComponentModel.DataAnnotations;
using PositronAPI.Models.Coupon;
using PositronAPI.Services.CouponService;
using PositronAPI.Services.AppointmentService;
using System.Reflection.Metadata.Ecma335;

namespace PositronAPI.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly CustomerService _customerService;
        private readonly ItemService _itemService;
        private readonly ServicesService _servicesService;

        public OrdersController(OrderService orderService, CustomerService customerService, ItemService itemService, ServicesService servicesService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _itemService = itemService;
            _servicesService = servicesService;
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
            Item responseItem = await IsValidItemOrder(orderId, itemId);
            if (responseItem is null) { return NotFound(); }

            decimal subtotal = _orderService.Subtotal(responseItem.Price, quantity);

            ItemOrder itemOrder = new ItemOrder { OrderId = orderId, ItemId = itemId, Quantity = quantity, Subtotal = subtotal};

            var response = _orderService.AddItemToOrder(itemOrder);

            if (response == null) { return BadRequest(); }
            else { return Created(String.Empty, response); }
        }

        /// <summary>
        /// Check whether a new item can be added to order
        /// </summary>
        /// <remarks>Check for validity</remarks>
        /// <param name="orderId">long orderId</param>
        /// <param name="itemId">long itemId</param>
        /// <returns>responseItem if valid, null if not valid</returns>
        private async Task<Item> IsValidItemOrder(long orderId, long itemId)
        {
            var responseOrder = await _orderService.GetOrder(orderId);
            var responseItem = await _itemService.GetItem(itemId);

            if (responseOrder == null || responseItem == null) { return null; }

            return responseItem;
        }


        [HttpPost]
        [Route("/order/{orderId}/addservice/{serviceId}/{quantity}")]
        public async Task<ActionResult> AddServiceToOrder([FromRoute][Required] long orderId,
                                                       [FromRoute][Required] long serviceId, [FromRoute][Required] int quantity)
        {
            Service responseService = await IsValidServiceOrder(orderId, serviceId);
            if (responseService is null) { return NotFound(); }

            decimal subtotal = _orderService.Subtotal(responseService.Price, quantity);

            ServiceOrder serviceOrder = new ServiceOrder { OrderId = orderId, ServiceId = serviceId, Quantity = quantity, Subtotal = subtotal };

            var response = _orderService.AddServiceToOrder(serviceOrder);

            if (response == null) { return BadRequest(); }
            else { return Created(String.Empty, response); }
        }

        /// <summary>
        /// Check whether a new service can be added to order
        /// </summary>
        /// <remarks>Check for validity</remarks>
        /// <param name="orderId">long orderId</param>
        /// <param name="serviceId">long serviceId</param>
        /// <returns>responseService if valid, null if not valid</returns>
        private async Task<Service> IsValidServiceOrder(long orderId, long serviceId)
        {
            var responseOrder = await _orderService.GetOrder(orderId);
            var responseService = await _servicesService.GetService(serviceId);

            if (responseOrder == null || responseService == null) { return null; }

            return responseService;
        }


        [HttpGet]
        [Route("/order/{orderId}")]
        public async Task<ActionResult<Order>> GetOrder([FromRoute][Required] long orderId)
        {
            var response = await _orderService.GetOrder(orderId);

            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        [HttpGet]
        [Route("/order/{orderId}/getitems")]
        public async Task<ActionResult<List<ItemOrder>>> GetOrderItems([FromRoute][Required] long orderId)
        {
            var response = await _orderService.GetOrderItems(orderId);

            if (response == null) { return NotFound(); }
            return Ok(response);
        }


        [HttpGet]
        [Route("/order/{orderId}/getservices")]
        public async Task<ActionResult<List<ServiceOrder>>> GetOrderServices([FromRoute][Required] long orderId)
        {
            var response = await _orderService.GetOrderServices(orderId);

            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        [HttpPut]
        [Route("/order/{orderId}")]
        public async Task<ActionResult<Order>> EditOrder([FromBody] Order body, [FromRoute][Required] long orderId)
        {
            if (body == null) { return BadRequest(); }
            var response = await _orderService.EditOrder(body, orderId);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

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