using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class AppDbContext : DbContext 
    {
        public DbSet<User> Users{ get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "fabijan",
                    Password = "admin",
                    Role = Role.Admin,
                    Token = null,
                }
            );
        }
    }
}
