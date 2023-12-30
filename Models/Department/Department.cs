using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Department
{
    public class Department : IEquatable<Department>
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "managerId")]
        public long? ManagerId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Department {\n");
            sb.Append("  ManagerId: ").Append(ManagerId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Department)obj);
        }

        /// <summary>
        /// Returns true if Department instances are equal
        /// </summary>
        /// <param name="other">Instance of Department to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Department other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ManagerId == other.ManagerId &&
                    ManagerId.Equals(other.ManagerId)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    Id == other.Id &&
                    Id.Equals(other.Id)
                );
        }

    }
}
