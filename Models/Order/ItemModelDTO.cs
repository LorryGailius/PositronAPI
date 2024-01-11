using PositronAPI.Models.Item;

namespace PositronAPI.Models.Order;

public class ItemModelDTO
{
    public required string Name { get; set; }

    public required ItemCategory Category { get; set; }

    public int Quantity { get; set; }

    public double Subtotal { get; set; }
}