using System.Runtime.Serialization;

namespace PositronAPI.Models.Schedule;

public class ServiceModelDTO
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "description")]
    public string? Description { get; set; }

    [DataMember(Name = "duration")]
    public int Duration { get; set; }

    [DataMember(Name = "category")]
    public ServiceCategory Category { get; set; }

    [DataMember(Name = "quantity")]
    public int Quantity { get; set; }

    [DataMember(Name = "subtotal")]
    public double Subtotal { get; set; }
}