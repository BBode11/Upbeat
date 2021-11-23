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
    public class IndexModel : PageModel
    {
        private readonly Upbeat.Data.UpbeatContext _context;

        public IndexModel(Upbeat.Data.UpbeatContext context)
        {
            _context = context;
        }

        public IList<Songs> Songs { get;set; }

        public async Task OnGetAsync()
        {
            Songs = await _context.Songs.ToListAsync();
        }


    }
}
