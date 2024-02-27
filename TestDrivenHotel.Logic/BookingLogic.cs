using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.DAL.Repository;

namespace TestDrivenHotel.Logic
{
    public class BookingLogic
    {
        public List<RoomModel> GetAvailableRooms(List<RoomModel> rooms, List<BookingModel> bookings, string specialFeature, int guests, DateTime arrivalDate, DateTime departureDate)
        {
            if (rooms == null)
                throw new ArgumentNullException();

            List<RoomModel>? roomsFilteredByFeatures = FilterFeatures(rooms, specialFeature);
            List<RoomModel>? roomsFilteredByNrOfGuests = FilterGuests(roomsFilteredByFeatures, guests);
            List<RoomModel>? availableRooms = FilterDates(roomsFilteredByNrOfGuests, bookings, arrivalDate, departureDate);

            return availableRooms;
        }

        public List<RoomModel>? FilterFeatures(List<RoomModel> rooms, string specialFeature)
        {
            if (String.IsNullOrEmpty(specialFeature))
                throw new ArgumentNullException("Select feature please.");

            switch (specialFeature)
            {
                case "OceanView":
                    return rooms.Where(r => r.OceanView).ToList();
                case "Balcony":
                    return rooms.Where(r => r.Balcony).ToList();
                case "None":
                    return rooms;
                default:
                    return new List<RoomModel>();
            }
        }

        public List<RoomModel>? FilterGuests(List<RoomModel> rooms, int guests)
        {
            if (guests <= 0)
                throw new ArgumentNullException("Number of guests has to be one or more!");

            return rooms.Where(r => r.MaxGuests >= guests).ToList();

        }

        public List<RoomModel>? FilterDates(List<RoomModel> rooms, List<BookingModel> bookings, DateTime startDate, DateTime endDate)
        {

            if (bookings == null || bookings.Count < 1)
                throw new ArgumentNullException("Can't find list of bookings.");

            if (endDate < startDate)
                throw new ArgumentException("Please check dates.");

            if (startDate < DateTime.Today)
                throw new ArgumentException("Date of arrival must be after the present day.");

            List<BookingModel> bookingOverlap = bookings
                .Where(b => startDate < b.EndDate && endDate > b.StartDate)
                .ToList();

            List<int> roomIdOverlap = bookingOverlap.Select(b => b.RoomId).ToList();

            return rooms
                    .Where(r => !roomIdOverlap.Contains(r.Id))
                    .ToList();
        }

        public double PriceCalculator(RoomModel room, int guests)
        {
            if (guests <= 0 || room == null || room.Price <= 0)
                throw new ArgumentNullException();
            if (guests > 6 || guests > room.MaxGuests)
                throw new ArgumentException();

            double totalPrice = room.Price;

            if (guests == 1)
            {
                return totalPrice;
            }
            else return totalPrice *= guests * 0.60;
        }

        public BookingModel CreateBooking(RoomModel room, DateTime arrivalDate, DateTime departureDate, String comment = " ")
        {
            if (room == null || room.Id < 1)
                throw new ArgumentNullException();

            if (arrivalDate > departureDate || arrivalDate < DateTime.Today)
                throw new ArgumentException("Incorrect dates");

            var bookings = ListRepository.GetAllBookings();
            int bookingId = (bookings.Max(b => b.Id)) + 1;

            BookingModel newBooking = new BookingModel
            {
                Id = bookingId,
                RoomId = room.Id,
                StartDate = arrivalDate,
                EndDate = departureDate,
                BookingCreated = DateTime.Now,
                Special = comment
            };

            ListRepository.AddBooking(newBooking);

            return newBooking;
        }
    }
}


