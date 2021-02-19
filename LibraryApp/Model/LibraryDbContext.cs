using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Model
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
    }
}
