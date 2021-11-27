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
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ArtistSort { get; set; }
        public string TitleSort { get; set; }
        public string DateSort { get; set; }
        public string GenreSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "TitleDesc" : "";
            //ArtistSort = String.IsNullOrEmpty(sortOrder) ? "ArtistDesc" : "";
            ArtistSort = sortOrder == "ArtistAsc" ? "ArtistDesc" : "ArtistAsc";
            GenreSort = sortOrder == "GenreAsc" ? "GenreDesc" : "GenreAsc";
            DateSort = sortOrder == "DateAsc" ? "DateDesc" : "DateAsc"; 

            var songs = from s in _context.Songs
                        select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Title.Contains(SearchString));
            }

            switch (sortOrder)
            {
                case "TitleDesc":
                    songs = songs.OrderByDescending(b => b.Title);
                    break;
                case "ArtistAsc":
                    songs = songs.OrderBy(s => s.Artist);
                    break;
                case "ArtistDesc":
                    songs = songs.OrderByDescending(s => s.Artist);
                    break;
                case "GenreAsc":
                    songs = songs.OrderBy(s => s.Genre);
                    break;
                case "GenreDesc":
                    songs = songs.OrderByDescending(s => s.Genre);
                    break;
                case "DateDesc":
                    songs = songs.OrderByDescending(b => b.ReleaseDate);
                    break;
                case "DateAsc":
                    songs = songs.OrderBy(b => b.ReleaseDate);
                    break;
                default:
                    songs = songs.OrderBy(b => b.Title);
                    break;
            }

            Songs = await songs.AsNoTracking().ToListAsync();
        }


    }
}
