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

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
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

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Appointment)obj);
        }

        /// <summary>
        /// Returns true if Appointment instances are equal
        /// </summary>
        /// <param name="other">Instance of Appointment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Appointment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id &&
                    Id.Equals(other.Id)
                ) &&
                (
                    CustomerId == other.CustomerId &&
                    CustomerId.Equals(other.CustomerId)
                ) &&
                (
                    ServiceId == other.ServiceId &&
                    ServiceId.Equals(other.ServiceId)
                ) &&
                (
                    Date == other.Date &&
                    Date.Equals(other.Date)
                );
        }
    }
}
