using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.LoyaltyCard;
using System.ComponentModel.DataAnnotations;
using PositronAPI.Services.LoyaltyService;
using PositronAPI.Services.CustomerService;

namespace PositronAPI.Controllers
{
    public class LoyaltyCardsController : ControllerBase
    {
        private readonly LoyaltyService _loyaltyService;
        private readonly CustomerService _customerService;

        public LoyaltyCardsController(LoyaltyService loyaltyService, CustomerService customerService)
        {
            _loyaltyService = loyaltyService;
            _customerService = customerService;
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
            if (await IsValidLoyaltyCard(body))
            {
                var newLoyaltyCard = new LoyaltyCard { CustomerId = body.CustomerId, Balance = body.Balance };

                var response = await _loyaltyService.CreateLoyaltyCard(newLoyaltyCard);

                if (response == null) { return BadRequest(); }
                else { return Ok(response); }
            }

            return BadRequest("Given object is not valid");
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

        public async Task<bool> IsValidLoyaltyCard(LoyaltyCard loyaltyCard)
        {
            if (loyaltyCard == null ||
                await _customerService.GetCustomer(loyaltyCard.CustomerId) == null ||
                await _loyaltyService.GetLoyaltyCardByCustomer(loyaltyCard.CustomerId) != null) { return false; }

            return true;
        }
    }
}
