using PositronAPI.Models.Item;

namespace PositronAPI.Services.ItemService
{
    public interface IItemService
    {
        Task<Item> CreateItem(ItemImportDTO item);
        Task<Item> DeleteItem(long itemId);
        Task<Item> EditItem(Item item, long itemId);
        Task<Item> EditItemQuantity(int quantityChange, long itemId);
        Task<Item> GetItem(long itemId);
        Task<List<Item>> GetItems(ItemCategory category, int top = 10, int skip = 0);
    }
}
