using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Upbeat.Data;
using Upbeat.Models;

namespace Upbeat.Pages.Views
{
    public class CreateModel : PageModel
    {
        private readonly Upbeat.Data.UpbeatContext _context;

        public CreateModel(Upbeat.Data.UpbeatContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Songs Songs { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Songs.Add(Songs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
