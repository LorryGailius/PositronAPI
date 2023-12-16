using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text;

namespace PositronAPI.Models.Order
{
    public class ItemOrder : IEquatable<ItemOrder>
    {
        [DataMember(Name = "orderId")]
        public long OrderId { get; set; }

        [DataMember(Name = "itemId")]
        public long ItemId { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        [DataMember(Name = "subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ItemOrder {\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  ItemId: ").Append(ItemId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  Subtotal: ").Append(Subtotal).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ItemOrder)obj);
        }


        /// <summary>
        /// Returns true if ItemOrder instances are equal
        /// </summary>
        /// <param name="other">Instance of ItemOrder to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ItemOrder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    OrderId == other.OrderId ||
                    OrderId != null &&
                    OrderId.Equals(other.OrderId)
                ) &&
                (
                    ItemId == other.ItemId ||
                    ItemId != null &&
                    ItemId.Equals(other.ItemId)
                ) &&
                (
                    Quantity == other.Quantity ||
                    Quantity != null &&
                    Quantity.Equals(other.Quantity)
                ) &&
                (
                    Subtotal == other.Subtotal ||
                    Subtotal != null &&
                    Subtotal.Equals(other.Subtotal)
                );
        }
    }
}
