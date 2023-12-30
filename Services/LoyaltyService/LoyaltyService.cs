using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.LoyaltyCard;

namespace PositronAPI.Services.LoyaltyService
{
    public class LoyaltyService
    {
        private readonly AppDbContext _context;

        public LoyaltyService(AppDbContext context)
        {
            _context = context;
        }

        // Add a loyalty card
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

        // Remove a loyalty card
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

        // Get a loyalty card
        public async Task<LoyaltyCard> GetLoyaltyCard(long loyaltyCardId)
        {
            return await _context.LoyaltyCards.FindAsync(loyaltyCardId);
        }

        public async Task<LoyaltyCard> GetLoyaltyCardByCustomer(long customerId)
        {
            return await _context.LoyaltyCards.FirstOrDefaultAsync(l => l.CustomerId == customerId);
        }
    }
}
