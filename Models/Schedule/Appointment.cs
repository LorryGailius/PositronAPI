using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Schedule
{
    public class Appointment : IEquatable<Appointment>
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "customerId")]
        public long CustomerId { get; set; }

        [DataMember(Name = "serviceId")]
        public long ServiceId { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Appointment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public bool Equals(Appointment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    CustomerId == other.CustomerId ||
                    CustomerId != null &&
                    CustomerId.Equals(other.CustomerId)
                ) &&
                (
                    ServiceId == other.ServiceId ||
                    ServiceId != null &&
                    ServiceId.Equals(other.ServiceId)
                ) &&
                (
                    Date == other.Date ||
                    Date != null &&
                    Date.Equals(other.Date)
                );
        }
    }
}
