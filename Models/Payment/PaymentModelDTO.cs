using System.Runtime.Serialization;
using PositronAPI.Models.Order;

namespace PositronAPI.Models.Payment;

public class PaymentModelDTO
{
    [DataMember(Name = "amount")]
    public double Amount { get; set; }

    [DataMember(Name = "paymentMethod")]
    public PaymentMethod PaymentMethod { get; set; }

    [DataMember(Name = "createdAt")]
    public DateTime CreatedAt { get; set; }
    public required List<ItemOrder> Items { get; set; }
    public required List<ServiceOrder> Services { get; set; }
}