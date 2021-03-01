using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.Librarian
{
    public class CreateModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public CreateModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public PositionDatabase.Models.Librarian Librarian { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Librarian.Add(Librarian);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
