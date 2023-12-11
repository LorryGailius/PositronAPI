using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models
{
    public class CreateCustomer : IEquatable<CreateCustomer>
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>

        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CreateCustomer {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
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
            return obj.GetType() == GetType() && Equals((CreateCustomer)obj);
        }

        /// <summary>
        /// Returns true if CreateCustomer instances are equal
        /// </summary>
        /// <param name="other">Instance of CreateCustomer to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CreateCustomer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                );
        }
    }
}
