using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Coupon;
using PositronAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class CouponsController : ControllerBase
    {
        private readonly CouponService _couponService;

        public CouponsController(CouponService couponService)
        {
            _couponService = couponService;
        }

        // Coupon Endpoints

        /// <summary>
        /// Create a new coupon for a customer.
        /// </summary>
        /// <remarks>Creates a coupon.</remarks>
        /// <param name="body">The properties for creating a new coupon.</param>
        /// <returns>The created coupon.</returns>
        [HttpPost]
        [Route("/coupon")]
        public async Task<ActionResult<Coupon>> CreateCoupon([FromBody][Required] Coupon body)
        {
            var response = await _couponService.CreateCoupon(body);

            if (response == null) { return BadRequest(); }
            return Ok(response);
        }

        /// <summary>
        /// Remove a coupon
        /// </summary>
        /// <remarks>Deletes a coupon.</remarks>
        /// <param name="couponId">The id of the coupon</param>
        [HttpDelete]
        [Route("/coupon/{couponId}")]
        public async Task<ActionResult> DeleteCoupon([FromRoute][Required] long couponId)
        {
            var response = await _couponService.DeleteCoupon(couponId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// Get a coupon of a customer
        /// </summary>
        /// <remarks>Gets a coupon.</remarks>
        /// <param name="couponId">The id of the coupon</param>
        [HttpGet]
        [Route("/coupon/{couponId}")]
        public async Task<ActionResult<Coupon>> GetCoupon([FromRoute][Required] long couponId)
        {
            var response = await _couponService.GetCoupon(couponId);

            if (response == null) { return NotFound(); }

            return Ok(response);
        }

        /// <summary>
        /// Gets coupons of a customer
        /// </summary>
        /// <remarks>Gets coupons.</remarks>
        /// <param name="customerId">The id of the coupon holder</param>
        [HttpGet]
        [Route("/coupon")]
        public async Task<ActionResult<List<Coupon>>> GetCoupons([FromRoute][Required] long customerId)
        {
            var response = await _couponService.GetCoupons(customerId);

            if (!response.Any()) { return NoContent(); }

            return Ok(response);
        }
    }
}