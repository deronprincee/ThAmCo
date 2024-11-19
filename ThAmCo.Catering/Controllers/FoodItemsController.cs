using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Data;
using ThAmCo.Catering.Dtos;

namespace ThAmCo.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public FoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            var foodItem = await _context.FoodItems
                .Select(fi => new FoodItemDto
                {
                    FoodItemId = fi.FoodItemId,
                    Description = fi.Description,
                    UnitPrice = fi.UnitPrice,
                })
                .ToListAsync();
            if (foodItem == null)
            {
                return NotFound();
            }
            return Ok(foodItem);
        }

        // GET: api/FoodItems/5
        [HttpGet("by-description")]
        public async Task<ActionResult<FoodItemDto>> GetFoodItem(string description)
        {
            var foodItem = await _context.FoodItems
                .Where(fi => fi.Description == description)
                .Select(fi => new FoodItemDto
                {
                    FoodItemId = fi.FoodItemId,
                    Description = fi.Description,
                    UnitPrice = fi.UnitPrice,
                })
                .FirstOrDefaultAsync();
            if (foodItem == null)
            {
                return NotFound();
            }
            return Ok(foodItem);
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("by-description")]
        public async Task<IActionResult> PutFoodItem(string description, FoodItem foodItemDto)
        {
            if (description != foodItemDto.Description)
            {
                return BadRequest();
            }

            var foodItem = await _context.FoodItems.FindAsync(description);
            if (foodItem == null)
            {
                return NotFound();
            }

            foodItem.FoodItemId = foodItemDto.FoodItemId;
            foodItem.Description = foodItemDto.Description;
            foodItem.UnitPrice = foodItem.UnitPrice;

            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodItemExists(foodItem.FoodItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItemDto foodItemDto)
        {
            var foodItem = new FoodItem
            {
                Description = foodItemDto.Description,
                UnitPrice = foodItemDto.UnitPrice
            };

            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodItem", new { id = foodItem.FoodItemId }, foodItem);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.FoodItemId == id);
        }
    }
}
