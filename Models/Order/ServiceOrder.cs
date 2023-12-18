using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Order
{
    public class ServiceOrder
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "orderId")]
        public long OrderId { get; set; }

        [DataMember(Name = "serviceId")]
        public long ServiceId { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ServiceOrder {\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ServiceOrder)obj);
        }


        /// <summary>
        /// Returns true if ServiceOrder instances are equal
        /// </summary>
        /// <param name="other">Instance of ServiceOrder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ServiceOrder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    OrderId == other.OrderId &&
                    OrderId.Equals(other.OrderId)
                ) &&
                (
                    ServiceId == other.ServiceId &&
                    ServiceId.Equals(other.ServiceId)
                ) &&
                (
                    Quantity == other.Quantity &&
                    Quantity.Equals(other.Quantity)
                ) &&
                (
                    Subtotal == other.Subtotal &&
                    Subtotal.Equals(other.Subtotal)
                );
        }
    }
}
