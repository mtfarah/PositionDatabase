﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.AcademicStaff
{
    public class DetailsModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public DetailsModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        public PositionDatabase.Models.AcademicStaff AcademicStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcademicStaff = await _context.AcademicStaff
                .Include(a => a.Person).FirstOrDefaultAsync(m => m.Id == id);

            if (AcademicStaff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
