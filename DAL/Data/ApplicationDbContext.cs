using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } //Fixar databasen baserat på modellen category

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>();

        }

    }
}
