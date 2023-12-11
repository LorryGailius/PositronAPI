using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Item;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class ItemsController : ControllerBase
    {
        /// <summary>
        /// Add an item
        /// </summary>
        /// <remarks>Creates an item.</remarks>
        /// <param name="body">Properties for creating a new item.</param>
        [HttpPost]
        [Route("/item")]
        public virtual IActionResult CreateItem([FromBody] Item body)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Remove an item
        /// </summary>
        /// <remarks>Deletes an item.</remarks>
        /// <param name="itemId">The id of the item</param>
        [HttpDelete]
        [Route("/item/{itemId}")]
        public virtual IActionResult DeleteItem([FromRoute][Required] long itemId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Edit an item
        /// </summary>
        /// <remarks>Edits an item.</remarks>
        /// <param name="body">Properties for creating a new item.</param>
        /// <param name="itemId">The id of the item</param>
        [HttpPut]
        [Route("/item/{itemId}")]
        public virtual IActionResult EditItem([FromBody] Item body, [FromRoute][Required] long itemId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Get an item
        /// </summary>
        /// <remarks>Gets an item.</remarks>
        /// <param name="itemId">The id of the item to get</param>
        [HttpGet]
        [Route("/item/{itemId}")]
        public virtual IActionResult GetItem([FromRoute][Required] long itemId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
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
        public virtual IActionResult GetItems([FromQuery] decimal? top, [FromQuery] decimal? skip, [FromQuery] ItemCategories categoryId)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
