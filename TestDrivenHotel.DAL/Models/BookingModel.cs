namespace TestDrivenHotel.DAL.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? BookingCreated { get; set; }
        public string Special { get; set; } = string.Empty;
        public RoomModel? Room { get; set; }
    }
}
