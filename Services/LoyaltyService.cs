using PositronAPI.Context;
using PositronAPI.Models.LoyaltyCard;

namespace PositronAPI.Services
{
    public class LoyaltyService
    {
        private readonly AppDbContext _context;

        public LoyaltyService(AppDbContext context)
        {
            _context = context;
        }

        // public async Task<ActionResult> CreateLoyaltyCard([FromBody] LoyaltyCard body, [FromRoute][Required] long customerId)
        // DeleteLoyaltyCard([FromRoute][Required] long customerId)
        // GetLoyaltyCard([FromRoute][Required] long customerId)

        public async Task<LoyaltyCard> CreateLoyaltyCard(LoyaltyCard loyaltyCard)
        {
            var customer = await _context.Customers.FindAsync(loyaltyCard.CustomerId);
            if (customer == null)
            {
                return null;
            }
      
            _context.LoyaltyCards.Add(loyaltyCard);
            await _context.SaveChangesAsync();
            return loyaltyCard;
        }

        public async Task<LoyaltyCard> DeleteLoyaltyCard(long customerId)
        {
            var loyaltyCard = await _context.LoyaltyCards.FindAsync(customerId);
            if (loyaltyCard == null)
            {
                return null;
            }

            _context.LoyaltyCards.Remove(loyaltyCard);
            await _context.SaveChangesAsync();
            return loyaltyCard;
        }

        public async Task<LoyaltyCard> GetLoyaltyCard(long customerId)
        {
            return await _context.LoyaltyCards.FindAsync(customerId);
        }


    }
}
