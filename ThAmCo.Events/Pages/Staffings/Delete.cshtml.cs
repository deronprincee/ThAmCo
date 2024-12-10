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
    public class DeleteModel : PageModel
    {
        private readonly ThAmCo.Events.Data.EventsContext _context;

        public DeleteModel(ThAmCo.Events.Data.EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Staffing Staffing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffing = await _context.Staffings.FirstOrDefaultAsync(m => m.StaffingId == id);

            if (staffing == null)
            {
                return NotFound();
            }
            else
            {
                Staffing = staffing;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var staffing = await _context.Staffings.FindAsync(id);
            if (staffing != null)
            {
                var isLastFirstAider = !_context.Staffings.Any(s => s.EventId == staffing.EventId && s.StaffId != staffing.StaffId && s.Staff.IsFirstAider);

                if (isLastFirstAider)
                {
                    ModelState.AddModelError("", "Cannot delete this staff member as they are the only first aider assigned to this event.");
                    return Page();
                }

                Staffing = staffing;
                _context.Staffings.Remove(Staffing);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
