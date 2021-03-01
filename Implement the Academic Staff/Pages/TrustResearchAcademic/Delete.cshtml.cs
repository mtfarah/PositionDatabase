using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.TrustResearchAcademic
{
    public class DeleteModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public DeleteModel(PositionDatabase.Data.PositionDatabaseContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrustResearchAcademic = await _context.TrustResearchAcademic.FindAsync(id);

            if (TrustResearchAcademic != null)
            {
                _context.TrustResearchAcademic.Remove(TrustResearchAcademic);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
