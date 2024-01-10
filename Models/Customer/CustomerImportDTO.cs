using System.Runtime.Serialization;

namespace PositronAPI.Models.Customer;

public class CustomerImportDTO
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "email")]
    public string? Email { get; set; }
}