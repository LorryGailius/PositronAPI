using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PositronAPI.Models.LoyaltyCard;

public class LoyaltyCardImportDTO
{
    [DataMember(Name = "customerId")]
    public long CustomerId { get; set; }

    [DataMember(Name = "balance")]
    [Range(0, double.MaxValue)]
    public decimal Balance { get; set; } = 0.0M;
}