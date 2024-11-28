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
    public class IndexModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public IndexModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IList<GuestBooking> GuestBooking { get;set; } = default!;
        public int GuestCount { get; set; } //variable to store the count of all the guests in an event

        // function will return list of all the guests attending an event
        public async Task OnGetAsync(int? id)
        {
            var eventsContext = _context.GuestBookings.AsQueryable();
            if (id != null)
            {
                eventsContext = eventsContext.Where(ws => ws.EventId == id);
            }
            eventsContext = eventsContext
            .Include(w => w.Guest)
            .Include(w => w.Event);
            GuestBooking = await eventsContext.ToListAsync();
            GuestCount = GuestBooking.Count;
        }
    }
}
