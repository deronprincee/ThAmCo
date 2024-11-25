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
    public class MenusController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public MenusController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDto>>> GetMenu()
        {
            var menu = await _context.Menu
                .Select(m => new MenuDto
                { 
                    MenuId = m.MenuId,
                    MenuName = m.MenuName
                })
                .ToListAsync();

            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu);
        }

        // GET: api/Menus/5
        [HttpGet("by-menuName")]
        public async Task<ActionResult<MenuDto>> GetMenu(string menuName)
        {
            var menu = await _context.Menu
                .Where(m => m.MenuName == menuName)
                .Select(m => new MenuDto
                {
                    MenuId = m.MenuId,
                    MenuName = m.MenuName
                })
                .FirstOrDefaultAsync();

            if (menu == null)
            {
                return NotFound();
            }

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("by-menuName")]
        public async Task<IActionResult> PutMenu(string menuName, CreateAndUpdateMenuDto updateMenuDto)
        {
            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.MenuName == menuName);

            if (menu == null)
            {
                return NotFound();
            }

            menu.MenuName = updateMenuDto.MenuName;
            
            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(menu.MenuId))
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

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MenuDto>> PostMenu(CreateAndUpdateMenuDto createMenuDto)
        {
            var menu = new Menu
            {
                MenuName = createMenuDto.MenuName
            };

            try
            {
                _context.Menu.Add(menu);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            var menuCreatedDto = new MenuDto
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName
            };

            return CreatedAtAction("GetMenu", new { id = menu.MenuId }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("by-menuName")]
        public async Task<IActionResult> DeleteMenu(string menuName)
        {
            try
            {
                var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.MenuName == menuName);

                if (menu == null)
                {
                    return NotFound();
                }

                _context.Menu.Remove(menu);
                await _context.SaveChangesAsync();

                var menuRemoveDto = new MenuDto
                {
                    MenuId = menu.MenuId,
                    MenuName = menu.MenuName
                };

                return Ok(menuRemoveDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private bool MenuExists(int id)
        {
            return _context.Menu.Any(e => e.MenuId == id);
        }
    }
}
