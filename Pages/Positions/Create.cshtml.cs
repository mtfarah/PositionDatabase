using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PositionDatabase.Data;
using PositionDatabase.Models;
using System.Linq;

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
            ViewData["PersonId"] = new SelectList(_context.Persons, "PersonId", "EmployeeName");

            //ViewData["PositionSalaryScales"] = new SelectList(_context.PositionSalaryScales, "PositionSalaryScaleId", "PositionSalaryScaleId");
            SalaryScaleOptions = _context.SalaryScales.Select(d => new SelectListItem
            {
                Value = d.SalaryScaleId.ToString(),
                Text = d.StartDate.ToString("d") + " to " + d.EndDate.ToString("d")
            }).ToList();

            ContractTypeOptions = new List<SelectListItem>();

            var enumValArray = Enum.GetValues(typeof(CType));
            var cTypeEnumAray = enumValArray.OfType<CType>();
            var alphaSortedArray = cTypeEnumAray.OrderBy(ele => ele.ToString());

            foreach (var val in alphaSortedArray)
                ContractTypeOptions.Add(new SelectListItem() { Value = val.ToString(), Text = val.ToString() });

            return Page();
        }

        [BindProperty]
        public Position Position { get; set; }
        public List<SelectListItem> SalaryScaleOptions { get; set; }
        public List<SelectListItem> ContractTypeOptions { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Positions.Add(Position);
            await _context.SaveChangesAsync();

            var positionSalaryScales = new List<PositionSalaryScale>();
            foreach (var positionSalaryScale in Position.PositionSalaryScales)
            {
                positionSalaryScales.Add(new PositionSalaryScale
                {
                    PositionId = Position.PositionId,
                    SalaryScaleId = positionSalaryScale.SalaryScaleId
                });
            }

            _context.PositionSalaryScales.AddRange(positionSalaryScales);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
