using System.Runtime.Serialization;

namespace PositronAPI.Models.Payment;

public class PaymentImportDTO
{
    [DataMember(Name = "orderId")]
    public long OrderId { get; set; }

    [DataMember(Name = "amount")]
    public decimal Amount { get; set; }

    [DataMember(Name = "paymentMethod")]
    public PaymentMethod PaymentMethod { get; set; }
}