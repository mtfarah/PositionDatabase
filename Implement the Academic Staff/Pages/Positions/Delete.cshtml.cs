﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.Positions
{
    public class DeleteModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public DeleteModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Position Position { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Position = await _context.Position.FirstOrDefaultAsync(m => m.Id == id);

            if (Position == null)
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

            Position = await _context.Position.FindAsync(id);

            if (Position != null)
            {
                _context.Position.Remove(Position);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
