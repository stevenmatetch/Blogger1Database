using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blogger1Database.Models;

namespace Blogger1Database.Data
{
    public class Blogger1DatabaseContext : DbContext
    {
        public Blogger1DatabaseContext (DbContextOptions<Blogger1DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Blogger1Database.Models.Books> Books { get; set; }
    }
}
