using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryAPI.Repository
{
    public class LibraryDbContext : DbContext
    {
        // The LibraryDbContext class must expose a public constructor with a
        // DbContextOptions parameter. This is how context
        // configuration from AddDbContext is passed to the DbContext.

        // LibraryDbContext can then be used in ASP.NET Core controllers
        // or other services through constructor injection.

        // The final result is an LibraryDbContext instance created
        // for each request and passed to the controller to perform a
        // unit-of-work before being disposed when the request ends.
        public LibraryDbContext(DbContextOptions options) :
            base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        // For cases where the navigations, foreign key, or required/optional
        // nature of the relationship are not discovered by convention, these
        // things can be configured explicitly.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Publishers)
                .HasForeignKey(e => e.PublisherId)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Authors)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

}
