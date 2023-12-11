﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class CustomersController : ControllerBase
    {
        // Customer Endpoints

        /// <summary>
        /// Add a customer
        /// </summary>
        /// <remarks>Creates a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        [HttpPost]
        [Route("/customer")]
        public virtual IActionResult CreateCustomer([FromBody] CreateCustomer body)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Remove a customer
        /// </summary>
        /// <remarks>Deletes a customer.</remarks>
        /// <param name="customerId">The id of the customer</param>
        [HttpDelete]
        [Route("/customer/{customerId}")]
        public virtual IActionResult DeleteCustomer([FromRoute][Required] string customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Edit a customer
        /// </summary>
        /// <remarks>Edits a customer.</remarks>
        /// <param name="body">Properties for creating a new customer.</param>
        /// <param name="customerId">The id of the customer</param>
        [HttpPut]
        [Route("/customer/{customerId}")]
        public virtual IActionResult EditCustomer([FromBody] CreateCustomer body, [FromRoute][Required] string customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Get a customer
        /// </summary>
        /// <remarks>Gets a customer.</remarks>
        /// <param name="customerId">The id of the customer to get</param>
        [HttpGet]
        [Route("/customer/{customerId}")]
        public virtual IActionResult GetCustomer([FromRoute][Required] string customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <remarks>Get all items.</remarks>
        /// <param name="top">The number of customers to get</param>
        /// <param name="skip">The number of customers to skip over</param>
        [HttpGet]
        [Route("/customer")]
        public virtual IActionResult GetCustomers([FromQuery] decimal? top, [FromQuery] decimal? skip)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
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
        public virtual IActionResult CreateLoyaltyCard([FromBody] CreateLoyaltyCard body, [FromRoute][Required] string customerId)
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
        public virtual IActionResult DeleteLoyaltyCard([FromRoute][Required] string customerId)
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
        public virtual IActionResult GetLoyaltyCard([FromRoute][Required] string customerId)
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
        public virtual IActionResult CreateCoupon([FromBody] CreateCoupon body, [FromRoute][Required] string customerId)
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
        public virtual IActionResult DeleteCoupon([FromRoute][Required] string customerId, [FromRoute][Required] string couponId)
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
        public virtual IActionResult GetCoupon([FromRoute][Required] string customerId, [FromRoute][Required] string couponId)
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
        public virtual IActionResult GetCoupons([FromRoute][Required] string customerId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

    }
}
