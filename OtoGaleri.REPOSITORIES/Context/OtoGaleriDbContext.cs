using Microsoft.EntityFrameworkCore;
using OtoGaleri.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri.REPOSITORIES.Context
{
    public class OtoGaleriDbContext : DbContext
    {
        public OtoGaleriDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=OtoGaleriDb;trusted_connection=true;");
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Magaza> Magazalar { get; set; }
         
    }
}