using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.LoyaltyCard;
using System.ComponentModel.DataAnnotations;
using PositronAPI.Services.LoyaltyService;
using PositronAPI.Services.CustomerService;

namespace PositronAPI.Controllers
{
    public class LoyaltyCardsController : ControllerBase
    {
        private readonly ILoyaltyService _loyaltyService;
        private readonly ICustomerService _customerService;

        public LoyaltyCardsController(ILoyaltyService loyaltyService, ICustomerService customerService)
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
        public async Task<ActionResult> CreateLoyaltyCard([FromBody][Required] LoyaltyCardImportDTO body)
        {
            if (await IsValidLoyaltyCard(body))
            {

                var response = await _loyaltyService.CreateLoyaltyCard(body);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
            }

            return BadRequest("Given object is not valid");
        }

        /// <summary>
        /// Remove a loyalty card
        /// </summary>
        /// <remarks>Deletes a loyalty card.</remarks>
        /// <param name="loyaltyId">The id of the loyalty card</param>
        [HttpDelete]
        [Route("/loyaltyCard/{loyaltyId}")]
        public async Task<ActionResult> DeleteLoyaltyCard([FromRoute][Required] long loyaltyId)
        {
            var response = await _loyaltyService.DeleteLoyaltyCard(loyaltyId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// Gets loyalty card of a customer
        /// </summary>
        /// <remarks>Gets loyalty card.</remarks>
        /// <param name="loyaltyId">The id of the loyalty card</param>
        [HttpGet]
        [Route("/loyaltyCard/{loyaltyId}")]
        public async Task<ActionResult<LoyaltyCard>> GetLoyaltyCard([FromRoute][Required] long loyaltyId)
        {
            var response = await _loyaltyService.GetLoyaltyCard(loyaltyId);

            if(response == null) { return NotFound(); }
            return Ok(response);
        }

        public async Task<bool> IsValidLoyaltyCard(LoyaltyCardImportDTO loyaltyCard)
        {
            if (loyaltyCard == null ||
                await _customerService.GetCustomer(loyaltyCard.CustomerId) == null ||
                await _loyaltyService.GetLoyaltyCardByCustomer(loyaltyCard.CustomerId) != null) { return false; }

            return true;
        }
    }
}
