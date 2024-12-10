using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.Staffings
{
    public class IndexModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public IndexModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IList<Staffing> Staffing { get;set; } = default!;
        public Dictionary<int, bool> EventFirstAiderWarnings { get; set; } = new Dictionary<int, bool>();

        public async Task OnGetAsync()
        {
            Staffing = await _context.Staffings
                .Include(s => s.Event)
                .Include(s => s.Staff).ToListAsync();

            var eventIds = Staffing.Select(s => s.EventId).Distinct();
            foreach (var eventId in eventIds)
            {
                // Check if the event has a first aider assigned
                var hasFirstAider = Staffing.Any(s => s.EventId == eventId && s.Staff.IsFirstAider);
                EventFirstAiderWarnings[eventId] = !hasFirstAider;
            }
        }

    }
}
