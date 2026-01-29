using MeusicRuchama.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeusicRuchama
{
    public class DataContext : DbContext
    {
        public DbSet<Students> students { get; set; }
        public DbSet<Teachers> teachers { get; set; }
        public DbSet<Lessons> lessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=School2");
        }
    }
}

