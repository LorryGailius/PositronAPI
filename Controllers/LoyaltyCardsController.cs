using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.LoyaltyCard;
using System.ComponentModel.DataAnnotations;
using PositronAPI.Services.LoyaltyService;

namespace PositronAPI.Controllers
{
    public class LoyaltyCardsController : ControllerBase
    {
        private readonly LoyaltyService _loyaltyService;

        public LoyaltyCardsController(LoyaltyService loyaltyService)
        {
            _loyaltyService = loyaltyService;
        }

        // Loyalty Card Endpoints

        /// <summary>
        /// Add a loyalty card for a customer.
        /// </summary>
        /// <remarks>Creates a loyalty card.</remarks>
        /// <param name="body">Properties for creating a new loyalty card.</param>
        [HttpPost]
        [Route("/loyaltyCard")]
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
        [Route("/loyaltyCard")]
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
        [Route("/loyaltyCard")]
        public async Task<ActionResult<LoyaltyCard>> GetLoyaltyCard([FromRoute][Required] long customerId)
        {
            return await _loyaltyService.GetLoyaltyCard(customerId);
        }
    }
}
