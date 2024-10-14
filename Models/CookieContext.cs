using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TermProject.Models
{
    public class CookieContext : DbContext
    {
        public CookieContext(DbContextOptions<CookieContext> options) : base(options) { }
        public DbSet<Members> Membership { get; set; }
        public DbSet<MoodEntry> MoodEntries { get; set; }

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
            modelBuilder.Entity<MoodEntry>().HasData(
                new MoodEntry
                {
                    Id= 1,
                    Mood = "Sad",
                    Notes = "Today was a tough day",
                    MembersId = 1,
                },
                new MoodEntry
                {
                    Id= 2,
                    Mood = "Happy",
                    Notes = "Today was a great day",
                    MembersId = 2,
                },
                new MoodEntry
                {
                    Id = 3,
                    Mood = "Okay",
                    Notes = "Today was neutral",
                    MembersId = 3,
                   
                }
            );
        }

    }
}
