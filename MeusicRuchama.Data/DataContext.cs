using MeusicRuchama.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace MeusicRuchama
{
    public class DataContext : DbContext
    {
        public DbSet<Students> students { get; set; }
        public DbSet<Teachers> teachers { get; set; }
        public DbSet<Lessons> lessons { get; set; }
        public DbSet<Users> users { get; set; }

        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=myschool_db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship between Students and Lessons
            modelBuilder.Entity<Students>()
                .HasMany(s => s.lessons)
                .WithMany(l => l.students)
                .UsingEntity<Dictionary<string, object>>( // junction table without a class
                    "LessonsStudents",
                    j => j
                        .HasOne<Lessons>()
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade), // only cascade on Lessons side
                    j => j
                        .HasOne<Students>()
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Restrict) // restrict on Students side to prevent multiple cascade paths
                );
        }

    }
}

