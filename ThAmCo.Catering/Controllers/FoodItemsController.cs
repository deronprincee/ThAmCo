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
        public async Task<ActionResult<IEnumerable<FoodItemDto>>> GetFoodItems()
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
        [HttpGet("{description}")]
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
        [HttpPut("{description}")]
        public async Task<IActionResult> PutFoodItem(string description, CreateAndUpdateFoodItemDto updateFoodItemDto)
        {
            var foodItem = await _context.FoodItems
                .FirstOrDefaultAsync(fi => fi.Description == description);

            if (foodItem == null)
            {
                return NotFound();
            }

            foodItem.Description = updateFoodItemDto.Description;
            foodItem.UnitPrice = updateFoodItemDto.UnitPrice;

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
        public async Task<ActionResult<FoodItemDto>> PostFoodItem(CreateAndUpdateFoodItemDto createFoodItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodItem = new FoodItem
            {
                Description = createFoodItemDto.Description,
                UnitPrice = createFoodItemDto.UnitPrice
            };

            try
            {
                _context.FoodItems.Add(foodItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            var FoodItemcreatedDto = new FoodItemDto
            {
                FoodItemId = foodItem.FoodItemId,
                Description = foodItem.Description,
                UnitPrice = foodItem.UnitPrice
            };

            return CreatedAtAction("GetFoodItem", new { description = FoodItemcreatedDto.Description }, FoodItemcreatedDto);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("{description}")]
        public async Task<IActionResult> DeleteFoodItem(string description)
        {
            try
            {
                var foodItem = await _context.FoodItems
                .FirstOrDefaultAsync(fi => fi.Description == description);

                if (foodItem == null)
                {
                    return NotFound();
                }

                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();

                var foodItemRemoveDto = new FoodItemDto
                {
                    FoodItemId = foodItem.FoodItemId,
                    Description = foodItem.Description,
                    UnitPrice = foodItem.UnitPrice
                };

                return Ok(foodItemRemoveDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.FoodItemId == id);
        }
    }
}
