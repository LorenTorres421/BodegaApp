using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BodegaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Wine> Wines { get; set; }

        public DbSet<Cata> Catas { get; set; }
        public BodegaContext(DbContextOptions<BodegaContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cata>()
            .HasMany(c => c.Wines)
            .WithMany(w => w.Catas);
        }



    }
}
