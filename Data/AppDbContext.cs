using CHEAPRIDES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHEAPRIDES.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<PersonInfo> Persons { get; set; }
        public DbSet<PersonLogin> PersonLogin { get; set; }

        public DbSet<CarRegShow> CarRegShows { get; set; }

        public DbSet<RideBooking> RideBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInfo>()
            .HasOne(p => p.PersonLogins)
            .WithOne(pi => pi.PersonInfo)
            .HasForeignKey<PersonLogin>(p1 => new { p1.pId})
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarRegShow>()
            .HasOne(p => p.PersonInfos1)
            .WithMany(p => p.CarRegShows)
            .HasForeignKey(c => c.pId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RideBooking>()
            .HasOne(p => p.CarRegShow)
            .WithMany(pi => pi.RideBookings)
            .HasForeignKey(c => c.Carid)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
