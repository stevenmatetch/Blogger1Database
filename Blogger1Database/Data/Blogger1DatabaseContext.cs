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
        public Blogger1DatabaseContext(DbContextOptions<Blogger1DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Blogger1Database.Models.Account> Account { get; set; }

        public DbSet<Blogger1Database.Models.Book> Book { get; set; }

        public DbSet<Blogger1Database.Models.Extra> Extra { get; set; }

        public DbSet<Blogger1Database.Models.User> User { get; set; }

        public DbSet<Blogger1Database.Models.Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.BookOrder>().HasKey(bo => new { bo.BookID, bo.OrderID });
        }

        public DbSet<Blogger1Database.Models.BookOrder> BookOrder { get; set; }
    }
}
