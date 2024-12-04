using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly VenueService _venueService;

        public List<SelectListItem> VenueItems { get; set; } = [];

        public CreateModel(ThAmCo.Events.Data.EventsContext context, VenueService venueService)
        {
            _context = context;
            _venueService = venueService;
        }

        public async Task<IActionResult> OnGet()
        {
            VenueItems = await _venueService.GetCategorySelectListAsync();
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                VenueItems = await _venueService.GetCategorySelectListAsync();
                return Page();
            }

            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
