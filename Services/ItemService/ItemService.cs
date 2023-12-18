using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Item;

namespace PositronAPI.Services.ItemService
{
    public class ItemService
    {
        private readonly AppDbContext _context;

        public ItemService(AppDbContext context)
        {
            _context = context;
        }


        // Add an item
        public async Task<Item> CreateItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // Remove an item from the database
        public async Task<Item> DeleteItem(long itemId)
        {
            var item = await _context.Items.FindAsync(itemId);
            if (item == null)
            {
                return null;
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        // Edit an item in the database
        public async Task<Item> EditItem(Item item, long itemId)
        {
            var existingItem = await _context.Items.FindAsync(itemId);
            if (existingItem == null)
            {
                return null;
            }

            existingItem.Name = item.Name;
            existingItem.Price = item.Price;
            existingItem.Category = item.Category;

            await _context.SaveChangesAsync();

            return existingItem;
        }

        // Edit an item's quantity in the database
        public async Task<Item> EditItemQuantity(int quantityChange, long itemId)
        {
            var existingItem = await _context.Items.FindAsync(itemId);
            if (existingItem == null)
            {
                return null;
            }

            // If the quantity change is negative, check if the stock will go below 0
            if (quantityChange < 0)
            {
                if (existingItem.Stock + quantityChange > 0)
                { existingItem.Stock += quantityChange; }
                else
                { existingItem.Stock = 0; }
            }
            else
            {
                existingItem.Stock += quantityChange;
            }

            await _context.SaveChangesAsync();

            return existingItem;
        }

        // Get an item from the database
        public async Task<Item> GetItem(long itemId)
        {
            return await _context.Items.FindAsync(itemId);
        }

        // Get all items from the database, based on the category
        public async Task<List<Item>> GetItems(ItemCategory category, int top = 10, int skip = 0)
        {
            return await _context.Items.Where(i => i.Category == category).Skip(skip).Take(top).ToListAsync();
        }
    }
}
