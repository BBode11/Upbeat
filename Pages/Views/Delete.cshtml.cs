using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Upbeat.Data;
using Upbeat.Models;

namespace Upbeat.Pages.Views
{
    public class DeleteModel : PageModel
    {
        private readonly Upbeat.Data.UpbeatContext _context;

        public DeleteModel(Upbeat.Data.UpbeatContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Songs Songs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Songs = await _context.Songs.FirstOrDefaultAsync(m => m.ID == id);

            if (Songs == null)
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

            Songs = await _context.Songs.FindAsync(id);

            if (Songs != null)
            {
                _context.Songs.Remove(Songs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
