using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Schedule
{
    public class Service : IEquatable<Service>
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "employeeId")]
        public long EmployeeId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string? Description { get; set; }

        [DataMember(Name = "duration")]
        public TimeSpan Duration { get; set; }

        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        [DataMember(Name = "category")]
        public ServiceCategories Category { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Services {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  EmployeeId: ").Append(EmployeeId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Duration: ").Append(Duration).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Service)obj);
        }

        /// <summary>
        /// Returns true if Department instances are equal
        /// </summary>
        /// <param name="other">Instance of Department to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Service other)
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
                    EmployeeId == other.EmployeeId ||
                    EmployeeId != null &&
                    EmployeeId.Equals(other.EmployeeId)
                )&&
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) &&
                (
                    Duration == other.Duration ||
                    Duration != null &&
                    Duration.Equals(other.Duration)
                ) &&
                (
                    Price == other.Price ||
                    Price != null &&
                    Price.Equals(other.Price)
                ) &&
                (
                    Category == other.Category ||
                    Category != null &&
                    Category.Equals(other.Category)
                ) &&
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                );
        }
    }
}
