using Microsoft.EntityFrameworkCore;
using TestDrivenHotel.DAL.Models;

namespace TestDrivenHotel.DAL
{
    public class HotelDbContext : DbContext
    {
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<RoomModel> Rooms { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomModel>()
                .HasMany(r => r.Bookings)
                .WithOne(b => b.Room)
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 2,
                Description = "Standard Room",
                Price = 400,
                MaxGuests = 2,
                OceanView = true,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 3,
                Description = "Double room with extra beds",
                Price = 500,
                MaxGuests = 5,
                OceanView = false,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 4,
                Description = "Presidential Suite",
                Price = 600,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 5,
                Description = "P. Diddy suite",
                Price = 600,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 6,
                Description = "Elon Suite",
                Price = 1000,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 7,
                Description = "Single room",
                Price = 250,
                MaxGuests = 1,
                OceanView = true,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 8,
                Description = "Conference suite",
                Price = 550,
                MaxGuests = 4,
                OceanView = true,
                Balcony = false
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 9,
                Description = "Honeymoon Suite",
                Price = 700,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            });

            modelBuilder.Entity<RoomModel>().HasData(new RoomModel
            {
                Id = 10,
                Description = "Small economy room",
                Price = 300,
                MaxGuests = 2,
                OceanView = false,
                Balcony = false
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 1,
                RoomId = 1,
                StartDate = new DateTime(2024, 3, 22),
                EndDate = new DateTime(2024, 3, 26),
                BookingCreated = DateTime.Now,
                Special = "Family vacation"
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 2,
                RoomId = 2,
                StartDate = new DateTime(2024, 3, 21),
                EndDate = new DateTime(2024, 3, 24),
                BookingCreated = DateTime.Now,
                Special = "Long weekend"
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 3,
                RoomId = 3,
                StartDate = new DateTime(2024, 4, 19),
                EndDate = new DateTime(2024, 4, 25),
                BookingCreated = DateTime.Now,
                Special = " "
            });

            modelBuilder.Entity<BookingModel>().HasData(new BookingModel
            {
                Id = 4,
                RoomId = 4,
                StartDate = new DateTime(2024, 5, 14),
                EndDate = new DateTime(2024, 5, 21),
                BookingCreated = DateTime.Now,
                Special = "Honeymoon"
            });
        }
    }
}

