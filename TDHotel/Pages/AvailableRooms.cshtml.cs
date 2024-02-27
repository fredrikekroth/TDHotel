using Microsoft.AspNetCore.Mvc.RazorPages;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.DAL.Repository;
using TestDrivenHotel.Logic;

namespace TestDrivenHotel.UI.Pages
{
    public class AvailableRoomsModel : PageModel
    {
        public int RoomId { get; set; }
        public int Guests { get; set; }
        public string? Feature { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public List<RoomModel>? AvailableRooms { get; set; }
        public string? Message { get; set; }

        public void OnGet(string feature, int guests, DateTime arrivalDate, DateTime departureDate)
        {

            this.Feature = feature;
            this.Guests = guests;
            this.ArrivalDate = arrivalDate;
            this.DepartureDate = departureDate;

            BookingLogic bookingLogic = new();

            List<BookingModel> bookings = ListRepository.GetAllBookings();
            List<RoomModel>? rooms = ListRepository.GetAllRooms();

            try
            {
                AvailableRooms = bookingLogic.GetAvailableRooms(rooms, bookings, Feature, Guests, ArrivalDate, DepartureDate);
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            };
        }
    }
}
