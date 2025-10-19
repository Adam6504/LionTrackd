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

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {
            var items = await _mongoDBService.GetAsync();
            if (items is null)
                return NotFound();

            return Ok(items);
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var item = await _mongoDBService.GetAsync(id);
            if (item is null)
                return NotFound();

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public async Task<IActionResult> Post(Item newItem)
        {
            await _mongoDBService.CreateAsync(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Item updatedItem)
        {
            var item = await _mongoDBService.GetAsync(id);
            if (item is null)
                return NotFound();

            updatedItem.Id = item.Id;
            await _mongoDBService.UpdateAsync(id, updatedItem);

            return NoContent();
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _mongoDBService.GetAsync(id);
            if (item is null)
                return NotFound();

            await _mongoDBService.RemoveAsync(id);
            return NoContent();
        }
    }
}
