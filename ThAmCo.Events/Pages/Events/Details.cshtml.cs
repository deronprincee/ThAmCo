using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public DetailsModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;
        public int GuestCount { get; set; } //variable to store the count of all the guests in an event

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Event = await _context.Events
                .Include(e => e.GuestBookings)
                .ThenInclude(gb => gb.Guest)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (Event == null)
            {
                return NotFound();
            }

            GuestCount = Event.GuestBookings.Count;

            return Page();
        }
    }
}
