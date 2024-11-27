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

        // GET: api/FoodBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBookingDto>>> GetFoodBookings()
        {
            var foodBooking = await _context.FoodBookings
                .Select(fb => new FoodBookingDto
                {
                    FoodBookingId = fb.FoodBookingId,
                    ClientReferenceId = fb.ClientReferenceId,
                    NumberOfGuests = fb.NumberOfGuests,
                    MenuId = fb.MenuId

                })
                .ToListAsync();
            if (foodBooking == null)
            {
                return NotFound();
            }
            return Ok(foodBooking);
        }

        // GET: api/FoodBookings/5
        [HttpGet("{foodBookingId}")]
        public async Task<ActionResult<FoodBookingDto>> GetFoodBooking(int foodBookingId)
        {
            var foodBooking = await _context.FoodBookings
                .Where(fb => fb.FoodBookingId == foodBookingId)
                .Select(fb => new FoodBookingDto
                {
                    FoodBookingId = fb.FoodBookingId,
                    ClientReferenceId = fb.ClientReferenceId,
                    NumberOfGuests = fb.NumberOfGuests,
                    MenuId = fb.MenuId
                })
                .ToListAsync();
            if (foodBooking == null)
            {
                return NotFound();
            }
            return Ok(foodBooking);
        } 
        
        // PUT: api/FoodBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{foodBookingId}")]
        public async Task<IActionResult> PutFoodBooking(int foodBookingId, CreateAndUpdateFoodBookingDto updateFoodBookingDto)
        {
            var foodBooking = await _context.FoodBookings
            .FirstOrDefaultAsync(fb => fb.FoodBookingId == foodBookingId);

            if (foodBooking == null)
            {
                return NotFound();
            }

            foodBooking.NumberOfGuests = updateFoodBookingDto.NumberOfGuests;
            foodBooking.MenuId = updateFoodBookingDto.MenuId;

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
        public async Task<ActionResult<FoodBookingDto>> PostFoodBooking(CreateAndUpdateFoodBookingDto createFoodBookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Method to generate a random ClientReferenceId
            static int GenerateRandomClientReferenceId()
            {
                Random rnd = new Random();
                int num = rnd.Next(100,500);
                return rnd.Next(num);
            }

            var foodBooking = new FoodBooking
            {
                ClientReferenceId = GenerateRandomClientReferenceId(),
                NumberOfGuests = createFoodBookingDto.NumberOfGuests,
                MenuId = createFoodBookingDto.MenuId
            };

            try
            {
                _context.FoodBookings.Add(foodBooking);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }

            var foodBookingCreateDto = new FoodBookingDto
            {
                FoodBookingId = foodBooking.FoodBookingId,
                ClientReferenceId = foodBooking.ClientReferenceId,
                NumberOfGuests = foodBooking.NumberOfGuests,
                MenuId = foodBooking.MenuId
            };

            return CreatedAtAction("GetFoodBooking", new { id = foodBookingCreateDto.FoodBookingId }, foodBookingCreateDto);
        }


        // DELETE: api/FoodBookings/5
        [HttpDelete("{foodBookingId}")]
        public async Task<IActionResult> DeleteFoodBooking(int foodBookingId)
        {
            try
            {
                var foodBooking = await _context.FoodBookings
                .FirstOrDefaultAsync(fb => fb.FoodBookingId == foodBookingId);

                if (foodBooking == null)
                {
                    return NotFound();
                }

                _context.FoodBookings.Remove(foodBooking);
                await _context.SaveChangesAsync();

                var foodItemRemoveDto = new FoodBookingDto
                {
                    FoodBookingId = foodBooking.FoodBookingId,
                    ClientReferenceId = foodBooking.ClientReferenceId,
                    NumberOfGuests = foodBooking.NumberOfGuests,
                    MenuId = foodBooking.MenuId
                };

                return Ok(foodItemRemoveDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBookings.Any(e => e.FoodBookingId == id);
        }
    }
}
