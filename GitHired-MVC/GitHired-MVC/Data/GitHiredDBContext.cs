using GitHired_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Data
{
    public class GitHiredDBContext : DbContext
    {
        public GitHiredDBContext(DbContextOptions<GitHiredDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = 1,
                    Name = "Test User",
                    Email = "test@test.com",
                    GitHubLink = "http://www.github.com/testuser",
                    Avatar = "Test Avatar"
                }
                );

            modelBuilder.Entity<Focus>().HasData(
                new Focus
                {
                    ID = 1,
                    UserID = 1,
                    Name = "Test Focus",
                    DesiredPosition = "Test Position",
                    Location = "Testville, USA",
                    Skill = "ASP.NET Core",
                    ResumeLink = "Test Resume Link",
                    CoverLetter = "Test Cover Letter"
                }
                );

            modelBuilder.Entity<Board>().HasData(
                new Board
                {
                    ID = 1,
                    FocusID = 1,
                    Name = "Default Board"

                    
                }
                );

            modelBuilder.Entity<Column>().HasData(
                new Column
                {
                    ID = 1,
                    BoardID = 1,
                    Name = "Default Column 1",
                    Order = 1
                },
                new Column
                {
                    ID = 2,
                    BoardID = 1,
                    Name = "Default Column 2",
                    Order = 2
                },
                new Column
                {
                    ID = 3,
                    BoardID = 1,
                    Name = "Default Column 3",
                    Order = 3
                }
                );
        }
        public DbSet<Board> Board { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Column> Column { get; set; }
        public DbSet<Focus> Focus { get; set; }
        public DbSet<User> User { get; set; }
    }
}
