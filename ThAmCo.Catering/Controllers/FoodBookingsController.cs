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
    public class FoodBookingsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public FoodBookingsController(CateringDbContext context)
        {
            _context = context;
        }

        // PUT: api/FoodBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> BookFoodBooking(int clientRefId, FoodBooking updateFoodBookingDto)
        {
            var foodBooking = await _context.FoodBookings
            .FirstOrDefaultAsync(fb => fb.ClientReferenceId == clientRefId);

            if (foodBooking == null)
            {
                return NotFound();
            }

            foodBooking.ClientReferenceId = updateFoodBookingDto.ClientReferenceId;
            foodBooking.NumberOfGuests = updateFoodBookingDto.NumberOfGuests;

            _context.Entry(foodBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodBookingExists(foodBooking.FoodBookingId))
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

        // POST: api/FoodBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodBooking>> PostFoodBooking(FoodBookingDto foodBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var foodBooking = new FoodBooking
            {
                NumberOfGuests = foodBookingDto.NumberOfGuests,
            };

            try
            {
                _context.FoodBookings.Add(foodBooking);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like Serilog, NLog, etc.)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            return CreatedAtAction("GetFoodBooking", new { id = foodBooking.FoodBookingId }, foodBooking);
        }

        // DELETE: api/FoodBookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);
            if (foodBooking == null)
            {
                return NotFound();
            }

            _context.FoodBookings.Remove(foodBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBookings.Any(e => e.FoodBookingId == id);
        }
    }
}
