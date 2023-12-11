using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PositronAPI.Context;
using PositronAPI.Models.Coupons;
using PositronAPI.Models.Customer;
using PositronAPI.Models.LoyaltyCard;
using PositronAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // Customer Endpoints

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <remarks>Creates a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        [HttpPost]
        [Route("/customer")]
        public async Task<ActionResult> CreateCustomer([FromBody] Customer body)
        {
            var response = await _customerService.CreateCustomer(body);

            if(response == null) { return BadRequest(); }
            else { return Ok(response);}
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
            if(body.Id != 0 && body.Id != customerId) { return BadRequest(); }

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
            if(response == null) { return NotFound();}
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
        public async Task<ActionResult<List<Customer>>> GetCustomers([FromQuery] decimal? top, [FromQuery] decimal? skip)
        {
            var response = await _customerService.GetCustomers();
            if(!response.Any()) { return NoContent();}

            return Ok(response);
        }

        // Loyalty Card Endpoints

        /// <summary>
        /// Add a loyalty card for customer
        /// </summary>
        /// <remarks>Creates a loyalty card.</remarks>
        /// <param name="body">Properties for creating a new loyalty card.</param>
        /// <param name="customerId">The id of the loyalty card holder</param>
        [HttpPost]
        [Route("/customer/{customerId}/loyaltyCard")]
        public virtual IActionResult CreateLoyaltyCard([FromBody] LoyaltyCard body, [FromRoute][Required] long customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Remove a loyalty card
        /// </summary>
        /// <remarks>Deletes a loyalty card.</remarks>
        /// <param name="customerId">The id of the loyalty card holder</param>
        [HttpDelete]
        [Route("/customer/{customerId}/loyaltyCard")]
        public virtual IActionResult DeleteLoyaltyCard([FromRoute][Required] long customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Gets loyalty card of a customer
        /// </summary>
        /// <remarks>Gets loyalty card.</remarks>
        /// <param name="customerId">The id of the loyalty card holder</param>
        [HttpGet]
        [Route("/customer/{customerId}/loyaltyCard")]
        public virtual IActionResult GetLoyaltyCard([FromRoute][Required] long customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        // Coupon Endpoints

        /// <summary>
        /// Add a coupon for customer
        /// </summary>
        /// <remarks>Creates a coupon.</remarks>
        /// <param name="body">Properties for creating a new coupon.</param>
        /// <param name="customerId">The id of the coupon holder</param>
        [HttpPost]
        [Route("/customer/{customerId}/coupon")]
        public virtual IActionResult CreateCoupon([FromBody] Coupon body, [FromRoute][Required] long customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Remove a coupon
        /// </summary>
        /// <remarks>Deletes a coupon.</remarks>
        /// <param name="customerId">The id of the coupon holder</param>
        /// <param name="couponId">The id of the coupon</param>
        [HttpDelete]
        [Route("/customer/{customerId}/coupon/{couponId}")]
        public virtual IActionResult DeleteCoupon([FromRoute][Required] long customerId, [FromRoute][Required] long couponId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Get a coupon of a customer
        /// </summary>
        /// <remarks>Gets a coupon.</remarks>
        /// <param name="customerId">The id of the coupon holder</param>
        /// <param name="couponId">The id of the coupon</param>
        [HttpGet]
        [Route("/customer/{customerId}/coupon/{couponId}")]
        public virtual IActionResult GetCoupon([FromRoute][Required] long customerId, [FromRoute][Required] long couponId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Gets coupons of a customer
        /// </summary>
        /// <remarks>Gets couponss.</remarks>
        /// <param name="customerId">The id of the coupon holder</param>
        [HttpGet]
        [Route("/customer/{customerId}/coupon")]
        public virtual IActionResult GetCoupons([FromRoute][Required] long customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

    }
}
