using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CannaWatch.Models;

namespace CannaWatch.Data
{
    public  class AppDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Strain> Strains { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your connection string here
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-C3L2I48\SQLEXPRESS;Database=CannaDB;Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}
