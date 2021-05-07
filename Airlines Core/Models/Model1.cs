using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Airlines.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<flightattendants> flightattendants { get; set; }
        public virtual DbSet<flightcrews> flightcrews { get; set; }
        public virtual DbSet<flights> flights { get; set; }
        public virtual DbSet<navigators> navigators { get; set; }
        public virtual DbSet<pilots> pilots { get; set; }
        public virtual DbSet<posts> posts { get; set; }
        public virtual DbSet<radiooperators> radiooperators { get; set; }
        public virtual DbSet<stations> stations { get; set; }
        public virtual DbSet<traveltime> traveltime { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employee>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<flightattendants>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<flightattendants>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<flightattendants>()
                .HasMany(e => e.flightcrews)
                .WithRequired(e => e.flightattendants)
                .HasForeignKey(e => e.FlightAttendantsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<flightcrews>()
                .HasMany(e => e.flights)
                .WithRequired(e => e.flightcrews)
                .HasForeignKey(e => e.FlightCrewId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<flights>()
                .HasMany(e => e.stations)
                .WithMany(e => e.flights)
                .Map(m => m.ToTable("flights_has_stations", "mydb").MapLeftKey("Flights_idFlights").MapRightKey("Stations_IdStations"));

            modelBuilder.Entity<flights>()
                .HasMany(e => e.traveltime)
                .WithMany(e => e.flights)
                .Map(m => m.ToTable("flights_has_traveltime", "mydb").MapLeftKey("Flights_idFlights").MapRightKey("TravelTime_idTravelTime"));

            modelBuilder.Entity<navigators>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<navigators>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<navigators>()
                .HasMany(e => e.flightcrews)
                .WithRequired(e => e.navigators)
                .HasForeignKey(e => e.NavigatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pilots>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<pilots>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<pilots>()
                .HasMany(e => e.flightcrews)
                .WithRequired(e => e.pilots)
                .HasForeignKey(e => e.PilotId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<posts>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<posts>()
                .HasMany(e => e.employee)
                .WithRequired(e => e.posts)
                .HasForeignKey(e => e.PostId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<radiooperators>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<radiooperators>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<radiooperators>()
                .HasMany(e => e.flightcrews)
                .WithRequired(e => e.radiooperators)
                .HasForeignKey(e => e.RadioOperatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<stations>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
