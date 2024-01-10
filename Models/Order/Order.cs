using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Order
{
    public class Order : IEquatable<Order>
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "customerId")]
        public long? CustomerId { get; set; }

        [DataMember(Name = "status")]
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        [DataMember(Name = "total")]
        public double Total { get; set; } = 0.0;

        [DataMember(Name = "taxCode")]
        public TaxCode TaxCode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Order)obj);
        }


        /// <summary>
        /// Returns true if Order instances are equal
        /// </summary>
        /// <param name="other">Instance of Order to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Order other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id &&
                    Id.Equals(other.Id)
                ) &&
                (
                    CustomerId == other.CustomerId&&
                    CustomerId.Equals(other.CustomerId)
                ) &&
                (
                    Status == other.Status &&
                    Status.Equals(other.Status)
                ) &&
                (
                    Total == other.Total &&
                    Total.Equals(other.Total)
                ) &&
                (
                    TaxCode == other.TaxCode &&
                    TaxCode.Equals(other.TaxCode)
                );
        }
    }
}
