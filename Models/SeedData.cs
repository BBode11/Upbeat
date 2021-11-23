using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upbeat.Data;

namespace Upbeat.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UpbeatContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<UpbeatContext>>()))
            {
                //Look for songs
                if (context.Songs.Any())
                {
                    return; //DB has been seeded.
                }

                context.Songs.AddRange(
                    new Songs
                    {
                        Title = "STAY",
                        Artist = "The Kid LAROI",
                        Genre = "Snyth-Pop / Pop Rock",
                        ReleaseDate = DateTime.Parse("07-09-2021"),
                        DurationTime = Convert.ToDouble("2.21")
                    },

                    new Songs
                    {
                        Title = "Easy On Me",
                        Artist = "Adele",
                        Genre = "Pop",
                        ReleaseDate = DateTime.Parse("10-15-2021"),
                        DurationTime = Convert.ToDouble("3.44")
                    },

                    new Songs
                    {
                        Title = "Save Your Tears",
                        Artist = "The Weekend",
                        Genre = "R&B / Soul",
                        ReleaseDate = DateTime.Parse("08-09-2020"),
                        DurationTime = Convert.ToDouble("3.35")
                    },

                    new Songs
                    {
                        Title = "Bad Habits",
                        Artist = "Ed Sheeran",
                        Genre = "Pop",
                        ReleaseDate = DateTime.Parse("06-25-2021"),
                        DurationTime = Convert.ToDouble("3.50")
                    },

                    new Songs
                    {
                        Title = "My Universe",
                        Artist = "Coldplay",
                        Genre = "Alternative / Indie",
                        ReleaseDate = DateTime.Parse("09-24-2021"),
                        DurationTime = Convert.ToDouble("3.48")
                    },

                    new Songs
                    {
                        Title = "CASHMERE COLOGNE",
                        Artist = "Gabriella Zauna",
                        Genre = "Alternative / Indie",
                        ReleaseDate = DateTime.Parse("10-01-2021"),
                        DurationTime = Convert.ToDouble("3.11")
                    },

                    new Songs
                    {
                        Title = "Happier Than Ever",
                        Artist = "Billie Eilish",
                        Genre = "Pop / Electropop",
                        ReleaseDate = DateTime.Parse("07-30-2021"),
                        DurationTime = Convert.ToDouble("4.58")
                    },

                    new Songs
                    {
                        Title = "Peaches",
                        Artist = "Justin Bieber",
                        Genre = "Pop / R&B",
                        ReleaseDate = DateTime.Parse("03-19-2021"),
                        DurationTime = Convert.ToDouble("3.18")
                    },

                    new Songs
                    {
                        Title = "good 4 u",
                        Artist = "Olivia Rodrigo",
                        Genre = "Pop Rock / Pop Punk",
                        ReleaseDate = DateTime.Parse("04-14-2021"),
                        DurationTime = Convert.ToDouble("2.58")
                    },

                    new Songs
                    {
                        Title = "Need to Know",
                        Artist = "Doja Cat",
                        Genre = "Pop Trap",
                        ReleaseDate = DateTime.Parse("08-31-2021"),
                        DurationTime = Convert.ToDouble("3.30")
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
