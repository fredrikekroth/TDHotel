using FluentAssertions;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;
using Xunit;

namespace TestDrivenHotel.Tests
{
    public class CreateBookingTests
    {
        // Create Booking tests

        BookingLogic bookingLogic = new();

        [Fact]
        public void CreateBooking_NoRoomId_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel noIdRoom = new()
            {
                Id = 0,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            };
            DateTime arrivalDate = new(2024, 07, 19);
            DateTime departureDate = new(2024, 07, 25);

            //When
            Action nullRoomTest = () => bookingLogic.CreateBooking(noIdRoom, arrivalDate, departureDate);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateBooking_nullRoom_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel? nullRoom = null;
            DateTime arrivalDate = new(2024, 07, 19);
            DateTime departureDate = new(2024, 07, 25);

            //When
            Action nullListTest = () => bookingLogic.CreateBooking(nullRoom, arrivalDate, departureDate);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateBooking_HasComment_ShouldReturnABooking()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            };
            string comment = "Champange bottle";
            DateTime arrivalDate = new(2024, 07, 19);
            DateTime departureDate = new(2024, 07, 25);

            //When
            var actualBooking = bookingLogic.CreateBooking(room, arrivalDate, departureDate, comment);

            //Then
            actualBooking.Should().NotBeNull();
            actualBooking.Should().BeOfType<BookingModel>();
        }

        [Fact]
        public void CreateBooking_DepartureBeforeArrival_ShouldThrowArgumentException()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            };

            // CHECK

            DateTime arrivalDate = new(2024, 07, 19);
            DateTime departureDate = new(2024, 07, 13);

            //When
            Action datesTest = () => bookingLogic.CreateBooking(room, arrivalDate, departureDate);

            //Then
            datesTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateBooking_BookingInThePast_ShouldThrowArgumentException()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 4,
                OceanView = true,
                Balcony = true
            };
            DateTime arrivalDate = new(2023, 07, 19);
            DateTime departureDate = new(2023, 07, 25);

            //When
            Action datesTest = () => bookingLogic.CreateBooking(room, arrivalDate, departureDate);

            //Then
            datesTest.Should().Throw<ArgumentException>();
        }
    }
}
