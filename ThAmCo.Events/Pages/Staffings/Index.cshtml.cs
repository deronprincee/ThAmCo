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
        public bool ShowFirstAiderWarning { get; set; } = false;


        public async Task OnGetAsync()
        {
            Staffing = await _context.Staffings
            .Include(s => s.Event)
            .Include(s => s.Staff)
            .ToListAsync();

            ShowFirstAiderWarning = Staffing
            .GroupBy(s => s.EventId)
            .Any(group => !group.Any(s => s.Staff.IsFirstAider));

        }

    }
}
