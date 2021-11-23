using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Upbeat.Models;

namespace Upbeat.Data
{
    public class UpbeatContext : DbContext
    {
        public UpbeatContext (DbContextOptions<UpbeatContext> options)
            : base(options)
        {
        }

        public DbSet<Upbeat.Models.Songs> Songs { get; set; }
    }
}
