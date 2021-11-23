using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upbeat.Data;
using Upbeat.Models;

namespace Upbeat.Pages.Views
{
    public class EditModel : PageModel
    {
        private readonly Upbeat.Data.UpbeatContext _context;

        public EditModel(Upbeat.Data.UpbeatContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(Songs.ID))
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

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.ID == id);
        }
    }
}
