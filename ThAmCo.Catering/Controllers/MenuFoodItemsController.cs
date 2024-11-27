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
    public class MenuFoodItemsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public MenuFoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuFoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuFoodItemDto>>> GetMenuFoodItems()
        {
            var menuFoodItem = await _context.MenuFoodItems
                .Select(mf => new MenuFoodItemDto
                {
                    FoodItemId = mf.FoodItemId,
                    MenuId = mf.MenuId,
                })
                .ToListAsync();
            if (menuFoodItem == null)
            {
                return NotFound();
            }
            return Ok(menuFoodItem);
        }

        // GET: api/MenuFoodItems/5
        [HttpGet("{foodItemId}/{menuId}")]
        public async Task<ActionResult<MenuFoodItemDto>> GetMenuFoodItem(int foodItemId, int menuId)
        {
            var menuFoodItem = await _context.MenuFoodItems
                .Where(mf => mf.FoodItemId == foodItemId && mf.MenuId == menuId)
                .Select(mf => new MenuFoodItemDto
                {
                    FoodItemId = mf.FoodItemId,
                    MenuId = mf.MenuId
                })
                .ToListAsync();
            if (menuFoodItem == null)
            {
                return NotFound();
            }
            return Ok(menuFoodItem);
        }

        // PUT: api/MenuFoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuFoodItem(int id, MenuFoodItem menuFoodItem)
        {
            if (id != menuFoodItem.MenuId)
            {
                return BadRequest();
            }

            _context.Entry(menuFoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuFoodItemExists(id))
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

        // POST: api/MenuFoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuFoodItemDto>> PostMenuFoodItem(MenuFoodItemDto menuFoodItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menuFoodItem = new MenuFoodItem
            {
                FoodItemId = menuFoodItemDto.FoodItemId,
                MenuId = menuFoodItemDto.MenuId,
            };

            try
            {
                _context.MenuFoodItems.Add(menuFoodItem);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            var menuFoodItemCreateDto = new MenuFoodItemDto
            {
                FoodItemId = menuFoodItem.FoodItemId,
                MenuId = menuFoodItem.MenuId
            };

            return CreatedAtAction("GetMenuFoodItem", new { id = menuFoodItemCreateDto.FoodItemId }, menuFoodItemCreateDto);
        }

        // DELETE: api/MenuFoodItems/5
        [HttpDelete("{foodItemId}/{menuId}")]
        public async Task<IActionResult> DeleteMenuFoodItem(int foodItemId, int menuId)
        {
            try
            {
                var menuFoodItem = await _context.MenuFoodItems
                .FirstOrDefaultAsync(fb => fb.FoodItemId == foodItemId && fb.MenuId == menuId);

                if (menuFoodItem == null)
                {
                    return NotFound();
                }

                _context.MenuFoodItems.Remove(menuFoodItem);
                await _context.SaveChangesAsync();

                var menuFoodItemRemoveDto = new MenuFoodItemDto
                {
                    FoodItemId = menuFoodItem.FoodItemId,
                    MenuId = menuFoodItem.MenuId
                };

                return Ok(menuFoodItemRemoveDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItems.Any(e => e.MenuId == id);
        }
    }
}
