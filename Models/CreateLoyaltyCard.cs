using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models
{
    public class CreateLoyaltyCard : IEquatable<CreateLoyaltyCard>
    {
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
            sb.Append("class CreateLoyaltyCard {\n");
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
            return obj.GetType() == GetType() && Equals((CreateLoyaltyCard)obj);
        }

        /// <summary>
        /// Returns true if CreateLoyaltyCard instances are equal
        /// </summary>
        /// <param name="other">Instance of CreateLoyaltyCard to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateLoyaltyCard other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Balance == other.Balance ||
                    Balance != null &&
                    Balance.Equals(other.Balance)
                );
        }
    }
}
