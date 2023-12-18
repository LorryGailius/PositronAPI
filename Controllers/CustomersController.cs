﻿using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Customer;
using PositronAPI.Models.LoyaltyCard;
using PositronAPI.Services.CouponService;
using PositronAPI.Services.CustomerService;
using PositronAPI.Services.LoyaltyService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly LoyaltyService _loyaltyService;

        public CustomersController(CustomerService customerService, LoyaltyService loyaltyService, CouponService couponService)
        {
            _customerService = customerService;
            _loyaltyService = loyaltyService;
        }

        // Customer Endpoints

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <remarks>Creates a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        [HttpPost]
        [Route("/customer")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer body)
        {
            if (body == null) { return BadRequest(); }
            var response = await _customerService.CreateCustomer(body);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        /// <summary>
        /// Remove a customer
        /// </summary>
        /// <remarks>Deletes a customer.</remarks>
        /// <param name="customerId">The id of the customer</param>
        [HttpDelete]
        [Route("/customer/{customerId}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute][Required] long customerId)
        {
            var response = await _customerService.DeleteCustomer(customerId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// Edit a customer
        /// </summary>
        /// <remarks>Edits a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        /// <param name="customerId">The id of the customer</param>
        [HttpPut]
        [Route("/customer/{customerId}")]
        public async Task<ActionResult> EditCustomer([FromBody] Customer body, [FromRoute][Required] long customerId)
        {
            if (body.Id != 0 && body.Id != customerId) { return BadRequest(); }

            var response = await _customerService.EditCustomer(body, customerId);

            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        /// <summary>
        /// Get a customer
        /// </summary>
        /// <remarks>Gets a customer.</remarks>
        /// <param name="customerId">The id of the customer to get</param>
        [HttpGet]
        [Route("/customer/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomer([FromRoute][Required] long customerId)
        {
            var response = await _customerService.GetCustomer(customerId);
            if (response == null) { return NotFound(); }
            return Ok(response);
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <remarks>Get all items.</remarks>
        /// <param name="top">The number of customers to get</param>
        /// <param name="skip">The number of customers to skip over</param>
        [HttpGet]
        [Route("/customer")]
        public async Task<ActionResult<List<Customer>>> GetCustomers([FromQuery] int top, [FromQuery] int skip)
        {
            if (top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _customerService.GetCustomers(top, skip) : await _customerService.GetCustomers();

            if (response.Count == 0) { return NoContent(); }

            return Ok(response);
        }

        // Loyalty Card Endpoints

        /// <summary>
        /// Add a loyalty card for customer
        /// </summary>
        /// <remarks>Creates a loyalty card.</remarks>
        /// <param name="body">Properties for creating a new loyalty card.</param>
        [HttpPost]
        [Route("/customer/{customerId}/loyaltyCard")]
        public async Task<ActionResult> CreateLoyaltyCard([FromBody][Required] LoyaltyCard body)
        {
            var response = await _loyaltyService.CreateLoyaltyCard(body);

            if (response == null) { return BadRequest(); }
            return Ok(response);
        }

        /// <summary>
        /// Remove a loyalty card
        /// </summary>
        /// <remarks>Deletes a loyalty card.</remarks>
        /// <param name="customerId">The id of the loyalty card holder</param>
        [HttpDelete]
        [Route("/customer/{customerId}/loyaltyCard")]
        public async Task<ActionResult> DeleteLoyaltyCard([FromRoute][Required] long customerId)
        {
            var response = await _loyaltyService.DeleteLoyaltyCard(customerId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// Gets loyalty card of a customer
        /// </summary>
        /// <remarks>Gets loyalty card.</remarks>
        /// <param name="customerId">The id of the loyalty card holder</param>
        [HttpGet]
        [Route("/customer/{customerId}/loyaltyCard")]
        public async Task<ActionResult<LoyaltyCard>> GetLoyaltyCard([FromRoute][Required] long customerId)
        {
            return await _loyaltyService.GetLoyaltyCard(customerId);
        }
    }
}
