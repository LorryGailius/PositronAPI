using System.Runtime.Serialization;

namespace PositronAPI.Models.Schedule;

public class AppointmentImportDTO
{
    [DataMember(Name = "customerId")]
    public long CustomerId { get; set; }

    [DataMember(Name = "serviceId")]
    public long ServiceId { get; set; }

    [DataMember(Name = "date")]
    public DateTime Date { get; set; }
}