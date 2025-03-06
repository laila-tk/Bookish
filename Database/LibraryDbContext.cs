using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookish.Models;

namespace Bookish.Database
{
    public class LibraryContext : DbContext
    {

        public LibraryContext (DbContextOptions<LibraryContext> options) : base(options) {}
        public DbSet<Bookish.Models.Book> Book { get; set; } = default!;
        public DbSet<Bookish.Models.Member> Member { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=Library;User Id=bookish;Password=bookish;");
        }
    }
}
