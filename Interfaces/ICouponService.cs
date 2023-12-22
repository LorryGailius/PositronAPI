using PositronAPI.Models.Coupon;

namespace PositronAPI.Services.CouponService
{
    public interface ICouponService
    {
        Task<Coupon> CreateCoupon(Coupon coupon);
        Task<Coupon> DeleteCoupon(long couponId);
        Task<Coupon> GetCoupon(long couponId);
        Task<List<Coupon>> GetCoupons(long customerId);
    }
}