using System.Runtime.Serialization;

namespace PositronAPI.Models.Order;

public class OrderImportDTO
{
    [DataMember(Name = "customerId")]
    public long? CustomerId { get; set; }

    [DataMember(Name = "taxCode")]
    public TaxCode TaxCode { get; set; }
}