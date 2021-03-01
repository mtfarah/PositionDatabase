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

namespace PositionDatabase.Pages.APO
{
    public class EditModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public EditModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PositionDatabase.Models.APO APO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            APO = await _context.APO
                .Include(a => a.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (APO == null)
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

            _context.Attach(APO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APOExists(APO.Id))
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

        private bool APOExists(int id)
        {
            return _context.APO.Any(e => e.Id == id);
        }
    }
}
