using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Coupon;

namespace PositronAPI.Services.CouponService
{
    public class CouponService
    {
        private readonly AppDbContext _context;

        public CouponService(AppDbContext context)
        {
            _context = context;
        }

        // Add a coupon
        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        // Remove a coupon
        public async Task<Coupon> DeleteCoupon(long couponId)
        {
            var coupon = await _context.Coupons.FindAsync(couponId);
            if (coupon == null)
            {
                return null;
            }

            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        // Get a coupon
        public async Task<Coupon> GetCoupon(long couponId)
        {
            return await _context.Coupons.FindAsync(couponId);
        }

        // Get all coupons for a customer
        public async Task<List<Coupon>> GetCoupons(long customerId)
        {
            return await _context.Coupons.Where(c => c.CustomerId == customerId).ToListAsync();
        }
    }
}
