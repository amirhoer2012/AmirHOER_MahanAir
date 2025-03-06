using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace AHInfraStructure
{
    public class AHContext:DbContext
    {
        public AHContext(DbContextOptions<AHContext> options) : base(options)
        {
        }

        public DbSet<AirPortEntity> Airports { get; set; }
        public DbSet<FlightEntity> Flights { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightEntity>()
                .HasOne(f => f.Source)
                .WithMany()
                .HasForeignKey(f => f.SourceId);

            modelBuilder.Entity<FlightEntity>()
                .HasOne(f => f.Destination)
                .WithMany()
                .HasForeignKey(f => f.DestinationId);

            modelBuilder.Entity<ReservationEntity>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r=>r.UserId);

            modelBuilder.Entity<ReservationEntity>()
                .HasOne(r => r.Flight)
                .WithMany()
                .HasForeignKey(r=>r.FlightId);
        }
    }
}
