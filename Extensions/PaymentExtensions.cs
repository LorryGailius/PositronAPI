using PositronAPI.Models.Order;
using PositronAPI.Models.Payment;

namespace PositronAPI.Extensions;

public static class PaymentExtensions
{
    public static PaymentModelDTO ToModelDto(this Payment payment, List<ItemOrder> itemOrders, List<ServiceOrder> serviceOrders)
    {
        return new PaymentModelDTO
        {
            CreatedAt = payment.CreatedAt,
            Amount = payment.Amount,
            PaymentMethod = payment.PaymentMethod,
            Items = itemOrders,
            Services = serviceOrders
        };
    }
}