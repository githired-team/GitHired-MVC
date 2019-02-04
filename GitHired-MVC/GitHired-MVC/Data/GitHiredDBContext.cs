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
        }
        public DbSet<Board> Board { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Column> Column { get; set; }
        public DbSet<Focus> Focus { get; set; }
        public DbSet<User> User { get; set; }
    }
}
