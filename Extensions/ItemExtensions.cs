using PositronAPI.Models.Item;
using PositronAPI.Models.Order;

namespace PositronAPI.Extensions;

public static class ItemExtensions
{
    public static ItemModelDTO ToModelDto(this Item item, ItemOrder itemOrder) => new()
    {
        Name = item.Name,
        Category = item.Category,
        Subtotal = itemOrder.Subtotal,
        Quantity = itemOrder.Quantity,
    };
}