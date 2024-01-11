using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Extensions;
using PositronAPI.Interfaces;
using PositronAPI.Models.Order;
using PositronAPI.Models.Payment;
using PositronAPI.Services.CouponService;
using PositronAPI.Services.LoyaltyService;
using PositronAPI.Services.OrderService;

namespace PositronAPI.Services.PaymentService;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _context;
    private readonly IOrderService _orderService;
    private readonly ICouponService _couponService;
    private readonly ILoyaltyService _loyaltyService;

    public PaymentService(AppDbContext context, IOrderService orderService, ICouponService couponService,
        ILoyaltyService loyaltyService)
    {
        _context = context;
        _orderService = orderService;
        _couponService = couponService;
        _loyaltyService = loyaltyService;
    }

    public async Task<PaymentModelDTO> CreatePayment(PaymentImportDTO paymentImportDto)
    {
        var order = await _context.Orders.FindAsync(paymentImportDto.OrderId);
        if (order == null)
        {
            return null;
        }

        var loyaltyCard = await _context.LoyaltyCards.FirstOrDefaultAsync(l => l.CustomerId == order.CustomerId);

        if (paymentImportDto is { PaymentMethod: PaymentMethod.Coupon, CouponId: not null })
        {
            var coupon = await _couponService.GetCoupon(paymentImportDto.CouponId.Value);
            if (coupon == null)
            {
                return null;
            }

            var couponBalanceAfterPayment = coupon.Amount - paymentImportDto.Amount;

            if (couponBalanceAfterPayment < 0)
            {
                return null;
            }

            coupon.Amount = couponBalanceAfterPayment;
            _context.Coupons.Update(coupon);
        }

        if (paymentImportDto.PaymentMethod == PaymentMethod.Loyalty)
        {
            if (loyaltyCard == null)
            {
                return null;
            }

            var loyaltyCardBalanceAfterPayment = loyaltyCard.Balance - paymentImportDto.Amount;

            if (loyaltyCardBalanceAfterPayment < 0)
            {
                return null;
            }

            loyaltyCard.Balance = loyaltyCardBalanceAfterPayment;
            _context.LoyaltyCards.Update(loyaltyCard);
        }
        else
        {
            if (loyaltyCard is not null)
            {
                var loyaltyCardBalanceAfterPayment = loyaltyCard.Balance + paymentImportDto.Amount * 0.01;
                loyaltyCard.Balance = loyaltyCardBalanceAfterPayment;
                _context.LoyaltyCards.Update(loyaltyCard);
            }
        }

        var payment = new Payment
        {
            OrderId = paymentImportDto.OrderId,
            Amount = paymentImportDto.Amount,
            PaymentMethod = paymentImportDto.PaymentMethod,
            CreatedAt = DateTime.Now.ToUniversalTime(),
        };

        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        var allPayments = _context.Payments.Where(x => x.OrderId == paymentImportDto.OrderId).ToList();

        if (allPayments.Sum(x => x.Amount) >= order.Total)
        {
            order.Status = OrderStatus.Completed;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        var itemOrder = await _context.ItemOrders.Where(x => x.OrderId == paymentImportDto.OrderId).ToListAsync();
        var serviceOrder = await _context.ServiceOrders.Where(x => x.OrderId == paymentImportDto.OrderId).ToListAsync();

        return payment.ToModelDto(itemOrder, serviceOrder);
    }
}