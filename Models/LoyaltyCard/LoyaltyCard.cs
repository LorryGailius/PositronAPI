using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.LoyaltyCard
{
    public class LoyaltyCard : IEquatable<LoyaltyCard>
    {
        /// <summary>
        /// ID of the loyalty card
        /// </summary>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets CustomerId
        /// </summary>

        [DataMember(Name = "customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or Sets Balance
        /// </summary>

        [DataMember(Name = "balance")]
        public decimal? Balance { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LoyaltyCard {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
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
            return obj.GetType() == GetType() && Equals((LoyaltyCard)obj);
        }

        /// <summary>
        /// Returns true if LoyaltyCard instances are equal
        /// </summary>
        /// <param name="other">Instance of LoyaltyCard to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LoyaltyCard other)
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
                    Balance == other.Balance ||
                    Balance != null &&
                    Balance.Equals(other.Balance)
                );
        }

    }
}
