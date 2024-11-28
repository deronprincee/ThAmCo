using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.GuestList
{
    public class DetailsModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public DetailsModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        public Guest Guest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Guest = await _context.Guests
                .Include(g => g.GuestBookings)
                .ThenInclude(ge => ge.Event)
                .FirstOrDefaultAsync(m => m.GuestId == id);

            if (Guest == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
