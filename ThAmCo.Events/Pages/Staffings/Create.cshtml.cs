using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Pages.Staffings
{
    public class CreateModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public CreateModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Name");
            ViewData["FirstAiders"] = new SelectList(_context.Staff.Where(s => s.IsFirstAider), "StaffId", "Name");
            return Page();
        }

        [BindProperty]
        public Staffing Staffing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Staffings.Add(Staffing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
