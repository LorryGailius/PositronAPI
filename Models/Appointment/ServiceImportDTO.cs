using System.Runtime.Serialization;

namespace PositronAPI.Models.Schedule;

public class ServiceImportDTO
{
    [DataMember(Name = "employeeId")]
    public long EmployeeId { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "description")]
    public string? Description { get; set; }

    [DataMember(Name = "duration")]
    public TimeSpan Duration { get; set; }

    [DataMember(Name = "price")]
    public decimal Price { get; set; }

    [DataMember(Name = "category")]
    public ServiceCategory Category { get; set; }
}