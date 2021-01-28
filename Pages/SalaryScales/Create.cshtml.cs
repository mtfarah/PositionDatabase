﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.SalaryScales
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
            return Page();
        }

        [BindProperty]
        public SalaryScale SalaryScale { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalaryScales.Add(SalaryScale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
