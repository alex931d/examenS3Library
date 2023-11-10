using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ClassesLib;
namespace repostory
{
    public class model : DbContext
    {
        public DbSet<users> Users { get; set; }
        public DbSet<lendings> Lendings { get; set; }
        public DbSet<bookss> Books { get; set; }
        public DbSet<lendingToUser> LendingToUsers { get; set; }
        public DbSet<roles> Roles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder
            options)
        {
            options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibaryS3;" +
            " Trusted_Connection = True; ");
        }
    }
}
