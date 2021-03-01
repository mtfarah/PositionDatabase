using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.TemporaryLibrarian
{
    public class DeleteModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public DeleteModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PositionDatabase.Models.TemporaryLibrarian TemporaryLibrarian { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TemporaryLibrarian = await _context.TemporaryLibrarian
                .Include(t => t.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (TemporaryLibrarian == null)
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

            TemporaryLibrarian = await _context.TemporaryLibrarian.FindAsync(id);

            if (TemporaryLibrarian != null)
            {
                _context.TemporaryLibrarian.Remove(TemporaryLibrarian);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
