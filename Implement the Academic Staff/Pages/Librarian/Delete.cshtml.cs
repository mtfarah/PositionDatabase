using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.Librarian
{
    public class DeleteModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public DeleteModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PositionDatabase.Models.Librarian Librarian { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Librarian = await _context.Librarian
                .Include(l => l.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (Librarian == null)
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

            Librarian = await _context.Librarian.FindAsync(id);

            if (Librarian != null)
            {
                _context.Librarian.Remove(Librarian);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
