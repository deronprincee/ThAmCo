using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThAmCo.Events.Data;
using ThAmCo.Events.Services;

namespace ThAmCo.Events.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;
        private readonly AvailabilityService _availabilityService;

        public List<SelectListItem> VenueItems { get; set; } = [];

        public CreateModel(ThAmCo.Events.Data.EventsContext context, AvailabilityService availabilityService)
        {
            _context = context;
            _availabilityService = availabilityService;
        }

        public async Task<IActionResult> OnGet(string eventType, DateTime beginDate, DateTime endDate)
        {
            try
            {
                VenueItems = await _availabilityService.GetAvailabilitySelectListAsync(eventType, beginDate, endDate);
                return Page();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string eventType, DateTime beginDate, DateTime endDate)
        {
            if (!ModelState.IsValid)
            {
                VenueItems = await _availabilityService.GetAvailabilitySelectListAsync(eventType, beginDate, endDate);
                return Page();
            }

            try
            {
                _context.Events.Add(Event);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
