
namespace TestDrivenHotel.DAL.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string? Description { get; set; } = String.Empty;
        public int Price { get; set; }
        public int MaxGuests { get; set; }
        public bool OceanView { get; set; }
        public bool Balcony { get; set; }


        public List<BookingModel>? Bookings { get; set; }
    }
}
