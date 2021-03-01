using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.TrustResearchAcademic
{
    public class EditModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public EditModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PositionDatabase.Models.TrustResearchAcademic TrustResearchAcademic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrustResearchAcademic = await _context.TrustResearchAcademic
                .Include(t => t.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (TrustResearchAcademic == null)
            {
                return NotFound();
            }
           ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TrustResearchAcademic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrustResearchAcademicExists(TrustResearchAcademic.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrustResearchAcademicExists(int id)
        {
            return _context.TrustResearchAcademic.Any(e => e.Id == id);
        }
    }
}
