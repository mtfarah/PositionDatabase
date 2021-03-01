using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PositionDatabase.Data;
using PositionDatabase.Models;

namespace PositionDatabase.Pages.FSO
{
    public class IndexModel : PageModel
    {
        private readonly PositionDatabase.Data.PositionDatabaseContext _context;

        public IndexModel(PositionDatabase.Data.PositionDatabaseContext context)
        {
            _context = context;
        }

        public IList<PositionDatabase.Models.FSO> FSO { get;set; }

        public async Task OnGetAsync()
        {
            FSO = await _context.FSO
                .Include(f => f.Person).ToListAsync();
        }
    }
}
