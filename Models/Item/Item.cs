using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Item
{
    public class Item : IEquatable<Item>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>

        [DataMember(Name = "price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or Sets Stock
        /// </summary>

        [DataMember(Name = "stock")]
        public int? Stock { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Item {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Stock: ").Append(Stock).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Item)obj);
        }

        /// <summary>
        /// Returns true if Item instances are equal
        /// </summary>
        /// <param name="other">Instance of Item to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Item other)
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
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) &&
                (
                    Price == other.Price ||
                    Price != null &&
                    Price.Equals(other.Price)
                ) &&
                (
                    Stock == other.Stock ||
                    Stock != null &&
                    Stock.Equals(other.Stock)
                ) &&
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                );
        }
    }
}
