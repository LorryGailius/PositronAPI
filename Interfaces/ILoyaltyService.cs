using PositronAPI.Models.LoyaltyCard;

namespace PositronAPI.Services.LoyaltyService
{
    public interface ILoyaltyService
    {
        Task<LoyaltyCard> CreateLoyaltyCard(LoyaltyCard loyaltyCard);
        Task<LoyaltyCard> DeleteLoyaltyCard(long customerId);
        Task<LoyaltyCard> GetLoyaltyCard(long loyaltyCardId);
        Task<LoyaltyCard> GetLoyaltyCardByCustomer(long customerId);
    }
}
