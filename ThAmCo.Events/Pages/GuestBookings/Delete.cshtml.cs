using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.GuestBookings
{
    public class DeleteModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public DeleteModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GuestBooking GuestBooking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbooking = await _context.GuestBookings.FirstOrDefaultAsync(m => m.GuestBookingId == id);

            if (guestbooking == null)
            {
                return NotFound();
            }
            else
            {
                GuestBooking = guestbooking;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbooking = await _context.GuestBookings.FindAsync(id);
            if (guestbooking != null)
            {
                GuestBooking = guestbooking;
                _context.GuestBookings.Remove(GuestBooking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
