using Microsoft.AspNetCore.Mvc;
using LionTrackdAPI.Models;
using LionTrackdAPI.Services;

namespace LionTrackdAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public ItemsController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        // GET: api/items or api/items?id={id}
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string? id = null)
        {
            // If id is provided as query parameter, get single item
            if (!string.IsNullOrEmpty(id))
            {
                var item = await _mongoDBService.GetAsync(id);
                if (item is null)
                    return NotFound(new { message = $"Item with ID '{id}' not found." });

                return Ok(new { message = "Item retrieved successfully.", data = item });
            }

            // Otherwise, get all items
            var items = await _mongoDBService.GetAsync();
            if (items is null || items.Count == 0)
                return Ok(new { message = "No items found in the database.", data = new List<Item>() });

            return Ok(new { message = $"Successfully retrieved {items.Count} item(s).", data = items });
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetById(string id)
        {
            var item = await _mongoDBService.GetAsync(id);
            if (item is null)
                return NotFound(new { message = $"Item with ID '{id}' not found." });

            return Ok(new { message = "Item retrieved successfully.", data = item });
        }

        // GET: api/items/category or api/items/category?category={category}
        [HttpGet("category")]
        public async Task<ActionResult<List<Item>>> GetByCategory([FromQuery] string category)
        {
            if (string.IsNullOrEmpty(category))
                return BadRequest(new { message = "Category parameter is required." });

            var items = await _mongoDBService.GetByCategoryAsync(category);
            if (items is null || items.Count == 0)
                return Ok(new { message = $"No items found in category '{category}'.", data = new List<Item>() });

            return Ok(new { message = $"Successfully retrieved {items.Count} item(s) from '{category}' category.", data = items });
        }

        // POST: api/items
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item newItem)
        {
            await _mongoDBService.CreateAsync(newItem);
            return CreatedAtAction(nameof(GetById), new { id = newItem.Id }, 
                new { message = "Item created successfully.", data = newItem });
        }

        // PUT: api/items?id={id}
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] Item updatedItem)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { message = "ID parameter is required." });

            var item = await _mongoDBService.GetAsync(id);
            if (item is null)
                return NotFound(new { message = $"Item with ID '{id}' not found. Unable to update." });

            updatedItem.Id = item.Id;
            await _mongoDBService.UpdateAsync(id, updatedItem);

            return Ok(new { message = $"Item with ID '{id}' updated successfully.", data = updatedItem });
        }

        // DELETE: api/items?id={id}
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest(new { message = "ID parameter is required." });

            var item = await _mongoDBService.GetAsync(id);
            if (item is null)
                return NotFound(new { message = $"Item with ID '{id}' not found. Unable to delete." });

            await _mongoDBService.RemoveAsync(id);
            return Ok(new { message = $"Item with ID '{id}' has been successfully deleted." });
        }
    }
}
