using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Coupons
{
    public class Coupon : IEquatable<Coupon>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets CustomerId
        /// </summary>

        [DataMember(Name = "customerId")]
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets ExpirationDate
        /// </summary>

        [DataMember(Name = "expirationDate")]
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Gets or Sets Amount
        /// </summary>

        [DataMember(Name = "Amount")]
        public decimal? Amount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Coupon {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  ExpirationDate: ").Append(ExpirationDate).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Coupon)obj);
        }

        /// <summary>
        /// Returns true if Coupon instances are equal
        /// </summary>
        /// <param name="other">Instance of Coupon to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Coupon other)
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
                    ExpirationDate == other.ExpirationDate ||
                    ExpirationDate != null &&
                    ExpirationDate.Equals(other.ExpirationDate)
                ) &&
                (
                    Amount == other.Amount ||
                    Amount != null &&
                    Amount.Equals(other.Amount)
                );
        }
    }
}
