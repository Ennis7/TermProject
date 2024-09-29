using Microsoft.EntityFrameworkCore;

namespace TermProject.Models
{
    public class CookieContext : DbContext
    {
        public CookieContext(DbContextOptions<CookieContext> options) : base(options) { }
        public DbSet<Members> Membership { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>().HasData(
                new Members
                {
                    Id = 1,
                    FirstName = "Cookie",
                    LastName = "Monster",
                    Email = "MonsterEatsCookies@gmail.com"
                },
                new Members
                {
                    Id = 2,
                    FirstName = "Cookie",
                    LastName = "Crisp",
                    Email = "CookieCrispCereal@aol.com"
                },
                new Members
                {
                    Id = 3,
                    FirstName = "Sarah",
                    LastName = "Ennis",
                    Email = "ennis@gmail.nmc.edu"
                }
            );
        }
    }
}
