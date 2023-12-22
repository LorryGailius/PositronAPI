using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Item;
using PositronAPI.Services.ItemService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemsController(ItemService itemService)
        {
            _itemService = itemService;
        }

        /// <summary>
        /// Add an item
        /// </summary>
        /// <remarks>Creates an item.</remarks>
        /// <param name="body">Properties for creating a new item.</param>
        [HttpPost]
        [Route("/item")]
        public async Task<ActionResult<Item>> CreateItem([FromBody] Item body)
        {
            if (IsValidItem(body))
            {
                var newItem = new Item { Name = body.Name, Category = body.Category,
                                        Description = body.Description, Price = body.Price , Stock = body.Stock};

                var response = await _itemService.CreateItem(newItem);

                if (response == null) { return BadRequest(); }
                else { return Ok(response); }
            }

            return BadRequest("Given object is not valid");
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <remarks>Deletes an item.</remarks>
        /// <param name="itemId">The id of the item</param>
        [HttpDelete]
        [Route("/item/{itemId}")]
        public async Task<ActionResult> DeleteItem([FromRoute][Required] long itemId)
        {
            var response = await _itemService.DeleteItem(itemId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        /// <summary>
        /// Edit an item
        /// </summary>
        /// <remarks>Edits an item.</remarks>
        /// <param name="body">Properties for creating a new item.</param>
        /// <param name="itemId">The id of the item</param>
        [HttpPut]
        [Route("/item/{itemId}")]
        public async Task<ActionResult> EditItem([FromBody] Item body, [FromRoute][Required] long itemId)
        {
            if (body.Id != 0 && body.Id != itemId) { return BadRequest(); }

            var response = await _itemService.EditItem(body, itemId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        /// <summary>
        /// Get an item
        /// </summary>
        /// <remarks>Gets an item.</remarks>
        /// <param name="itemId">The id of the item to get</param>
        [HttpGet]
        [Route("/item/{itemId}")]
        public async Task<ActionResult<Item>> GetItem([FromRoute][Required] long itemId)
        {
            return await _itemService.GetItem(itemId);
        }

        /// <summary>
        /// Gets all items by category
        /// </summary>
        /// <remarks>Get all items.</remarks>
        /// <param name="top">The number of items to get</param>
        /// <param name="skip">The number of items to skip over</param>
        /// <param name="categoryId">The id of the category to get</param>
        [HttpGet]
        [Route("/item")]
        public async Task<ActionResult<List<Item>>> GetItems([FromQuery] ItemCategory categoryId, [FromQuery] int top, [FromQuery] int skip)
        {
            if (top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _itemService.GetItems(categoryId, top, skip) : await _itemService.GetItems(categoryId);

            if (response.Count == 0) { return NoContent(); }

            return Ok(response);
        }

        public bool IsValidItem(Item item)
        {
            if (item == null ||
               String.IsNullOrEmpty(item.Name) ||
               item.Stock < 0 ||
               item.Price < 0) { return false; }

            return true;
        }
    }
}
