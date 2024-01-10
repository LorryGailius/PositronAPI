using System.Runtime.Serialization;

namespace PositronAPI.Models.Coupon;

public class CouponImportDTO
{
    [DataMember(Name = "customerId")]
    public long CustomerId { get; set; }

    [DataMember(Name = "expirationDate")]
    public DateTime ExpirationDate { get; set; }


    [DataMember(Name = "Amount")]
    public double? Amount { get; set; }
}