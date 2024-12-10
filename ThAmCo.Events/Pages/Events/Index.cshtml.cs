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
    public class IndexModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public IndexModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; } = default!;
        public Dictionary<int, bool> EventFirstAiderWarnings { get; set; } = new();


        public async Task OnGetAsync()
        {
            Event = await _context.Events
            .Include(e => e.Staffings)
                .ThenInclude(s => s.Staff)
            .ToListAsync();

            // Populate warnings for events without a first aider
            foreach (var ev in Event)
            {
                var hasFirstAider = ev.Staffings.Any(s => s.Staff.IsFirstAider);
                EventFirstAiderWarnings[ev.EventId] = !hasFirstAider; // True if no first aider
            }
        }
    }
}
