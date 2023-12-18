using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Payment
{
    public class Payment
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "orderId")]
        public long OrderId { get; set; }

        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }

        [DataMember(Name = "paymentMethod")]
        public PaymentMethod PaymentMethod { get; set; }

        [DataMember(Name = "createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Payment {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Payment)obj);
        }


        /// <summary>
        /// Returns true if Payment instances are equal
        /// </summary>
        /// <param name="other">Instance of Payment to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Payment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                Id == other.Id &&
                    Id.Equals(other.Id)
                ) &&
                (
                    OrderId == other.OrderId &&
                    OrderId.Equals(other.OrderId)
                ) &&
                (
                    Amount == other.Amount &&
                    Amount.Equals(other.Amount)
                ) &&
                (
                    PaymentMethod == other.PaymentMethod &&
                    PaymentMethod.Equals(other.PaymentMethod)
                ) &&
                (
                    CreatedAt == other.CreatedAt &&
                    CreatedAt.Equals(other.CreatedAt)
                );
        }
    }
}
