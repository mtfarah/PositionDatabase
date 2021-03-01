using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.Positions
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
            //PositionDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Position Position { get; set; }


      

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*var emptyTitles = new Position();

            if (await TryUpdateModelAsync<Position>(
                 emptyTitles,
                 "title",   // Prefix for form value.
                 s => s.ID, s => s.Title, s => s.Description, s => s.Department, s => s.ContractType, s => s.StartDate))
            {
                _context.Position.Add(emptyTitles);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PositionDropDownList(_context, emptyTitles.ID);
            return Page();*/

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Position.Add(Position);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
