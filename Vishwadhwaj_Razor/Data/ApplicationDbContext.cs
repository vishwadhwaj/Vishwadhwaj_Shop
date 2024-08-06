using Microsoft.EntityFrameworkCore;
using Vishwadhwaj_Razor.Models;

namespace Vishwadhwaj_Razor.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, name = "action", DisplayOrder = 1 },
                new Category() { Id = 2, name = "sci-fi", DisplayOrder = 2 },
                new Category() { Id = 3, name = "history", DisplayOrder = 3 }
            );
        }
    }
}
