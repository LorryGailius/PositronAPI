using System.Runtime.Serialization;

namespace PositronAPI.Models.Order;

public class OrderUpdateDTO
{
    [DataMember(Name = "customerId")]
    public long? CustomerId { get; set; }

    [DataMember(Name = "status")]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    [DataMember(Name = "total")]
    public double Total { get; set; } = 0.0;

    [DataMember(Name = "taxCode")]
    public TaxCode TaxCode { get; set; }
}