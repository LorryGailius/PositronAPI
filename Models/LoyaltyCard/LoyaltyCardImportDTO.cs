using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PositronAPI.Models.LoyaltyCard;

public class LoyaltyCardImportDTO
{
    [DataMember(Name = "customerId")]
    public long CustomerId { get; set; }
}