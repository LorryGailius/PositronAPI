using System.Runtime.Serialization;

namespace PositronAPI.Models.Item;

public class ItemImportDTO
{
    [DataMember(Name = "name")]
    public string Name { get; set; }

    [DataMember(Name = "category")]
    public ItemCategory Category { get; set; }

    [DataMember(Name = "description")]
    public string? Description { get; set; }

    [DataMember(Name = "price")]
    public decimal Price { get; set; } = 0.0M;

    [DataMember(Name = "stock")]
    public int Stock { get; set; } = 0;
}