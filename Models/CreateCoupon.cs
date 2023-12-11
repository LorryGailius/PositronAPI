using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models
{
    public class CreateCoupon : IEquatable<CreateCoupon>
    {
        /// <summary>
        /// Gets or Sets CustomerId
        /// </summary>

        [DataMember(Name = "customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets ExpirationDate
        /// </summary>

        [DataMember(Name = "expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or Sets Ammount
        /// </summary>

        [DataMember(Name = "ammount")]
        public decimal? Ammount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateCoupon {\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  ExpirationDate: ").Append(ExpirationDate).Append("\n");
            sb.Append("  Ammount: ").Append(Ammount).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CreateCoupon)obj);
        }

        /// <summary>
        /// Returns true if CreateCoupon instances are equal
        /// </summary>
        /// <param name="other">Instance of CreateCoupon to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateCoupon other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
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
                    Ammount == other.Ammount ||
                    Ammount != null &&
                    Ammount.Equals(other.Ammount)
                );
        }

    }
}
