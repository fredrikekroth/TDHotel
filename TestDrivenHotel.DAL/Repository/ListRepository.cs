using TestDrivenHotel.DAL.Models;

namespace TestDrivenHotel.DAL.Repository
{
    public class ListRepository : IRepository
    {
        public static void AddBooking(BookingModel booking)
        {
            Bookings.Add(booking);
        }

        public static List<BookingModel> GetAllBookings()
        {
            return Bookings;
        }

        public static List<RoomModel>? GetAllRooms()
        {
            return Rooms;
        }

        public static List<BookingModel> Bookings = new List<BookingModel>
        {
            new BookingModel
            {
                Id = 1,
                RoomId = 1,
                StartDate = new DateTime(2024, 2, 5),
                EndDate = new DateTime(2024, 2, 10),
                BookingCreated = DateTime.Now,
                Special = "Birthday"
            },
            new BookingModel
            {
                Id = 2,
                RoomId = 2,
                StartDate = new DateTime(2024, 3, 15),
                EndDate = new DateTime(2024, 3, 20),
                BookingCreated = DateTime.Now,
                Special = "Honeymoon"
            },
            new BookingModel
            {
                Id = 3,
                RoomId = 3,
                StartDate = new DateTime(2024, 4, 10),
                EndDate = new DateTime(2024, 4, 15),
                BookingCreated = DateTime.Now,
                Special = " "
            },
            new BookingModel
            {
                Id = 4,
                RoomId = 4,
                StartDate = new DateTime(2024, 5, 20),
                EndDate = new DateTime(2024, 5, 25),
                BookingCreated = DateTime.Now,
                Special = "Tourist"
            }
        };


        public static List<RoomModel> Rooms = new List<RoomModel>
        {
            new RoomModel
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            },
            new RoomModel
            {
                Id = 2,
                Description = "Standard Room",
                Price = 400,
                MaxGuests = 2,
                OceanView = true,
                Balcony = false
            },
            new RoomModel
            {
                Id = 3,
                Description = "Double room with extra beds",
                Price = 500,
                MaxGuests = 5,
                OceanView = false,
                Balcony = true
            },
            new RoomModel
            {
                Id = 4,
                Description = "Presidential Suite",
                Price = 600,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            },
            new RoomModel
            {
                Id = 5,
                Description = "P. Diddy suite",
                Price = 600,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            },
            new RoomModel
            {
                Id = 6,
                Description = "Elon Suite",
                Price = 1000,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            },
            new RoomModel
            {
                Id = 7,
                Description = "Single room",
                Price = 250,
                MaxGuests = 1,
                OceanView = true,
                Balcony = false
            },
            new RoomModel
            {
                Id = 8,
                Description = "Conference suite",
                Price = 550,
                MaxGuests = 4,
                OceanView = true,
                Balcony = false
            },
            new RoomModel
            {
                Id = 9,
                Description = "Honeymoon Suite",
                Price = 700,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            },
            new RoomModel
            {
                Id = 10,
                Description = "Small economy room",
                Price = 300,
                MaxGuests = 2,
                OceanView = false,
                Balcony = false
            }
        };

    }
}
