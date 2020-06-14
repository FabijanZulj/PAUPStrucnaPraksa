using Microsoft.EntityFrameworkCore;
using StrucnaPraksa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrucnaPraksa.Models
{
    public class AppDbContext : DbContext 
    {
        public DbSet<User> Users{ get; set; }
        public DbSet<OsnovniPodaci> OsnovniPodaci { get; set; }
        public DbSet<Anketa> Ankete { get; set; }
        public DbSet<Dnevnik> Dnevnici { get; set; }
        public DbSet<Izvjesce> Izvjesca { get; set; }
        

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
                    Password = "pIbvhgmpVHahDBTYUgQvew==",
                    Role = Role.Admin,
                    Ime = "Fabijan",
                    Prezime = "Zulj",
                    Token = null,
                }
            );
        }
    }
}
