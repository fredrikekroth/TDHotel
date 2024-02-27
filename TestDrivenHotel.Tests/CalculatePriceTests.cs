using FluentAssertions;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;
using Xunit;

namespace TestDrivenHotel.Tests
{
    public class CalculatePriceTests
    {
        // Booking/Price tests

        BookingLogic bookingLogic = new();

        [Fact]
        public void CalculatePrice_NullRoom_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel? nullRoom = null;
            int guests = 2;

            //When
            Action nullRoomTest = () => bookingLogic.PriceCalculator(nullRoom, guests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CalculatePrice_NullGuests_ShouldThrowArgumentNullException()
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

            int nullGuests = 0;

            //When
            Action nullRoomTest = () => bookingLogic.PriceCalculator(room, nullGuests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }
        [Fact]
        public void CalculatePrice_NullRoomNullGuests_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel? nullRoom = null;
            int guests = 0;

            //When
            Action nullRoomTest = () => bookingLogic.PriceCalculator(nullRoom, guests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CalculatePrice_TwoGuests_ShouldReturnTotalPrice750()
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
            int guests = 2;

            //When
            var actualPrice = bookingLogic.PriceCalculator(room, guests);
            var expectedPrice = room.Price * guests * 0.60;

            //Then
            actualPrice.Should().Be(expectedPrice);
            actualPrice.Should().Be(780);
            actualPrice.Should().BePositive();
        }
        [Fact]
        public void CalculatePrice_OneGuest_ShouldReturnTotalPrice500()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            };
            int guests = 1;

            //When
            var actualPrice = bookingLogic.PriceCalculator(room, guests);
            var expectedPrice = room.Price;

            //Then
            actualPrice.Should().Be(expectedPrice);
            actualPrice.Should().Be(650);
            actualPrice.Should().BePositive();
        }

        [Fact]
        public void CalculatePrice_MoreThanMaxNrOfGuests_ShouldThrowArgumentException()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            };
            int tooManyGuests = 3;

            //Then
            Action nullRoomTest = () => bookingLogic.PriceCalculator(room, tooManyGuests);

            //Then
            nullRoomTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CalculatePrice_MoreThenSixGuests_ShouldThrowArgumentException()
        {
            //Given
            RoomModel room = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 650,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            };
            int tooManyGuests = 54;

            //When
            Action nullRoomTest = () => bookingLogic.PriceCalculator(room, tooManyGuests);

            //Then
            nullRoomTest.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CalculatePrice_NullPriceRoom_ShouldThrowArgumentNullException()
        {
            //Given
            RoomModel nullRoomPrice = new()
            {
                Id = 1,
                Description = "Large Deluxe room",
                Price = 0,
                MaxGuests = 2,
                OceanView = true,
                Balcony = true
            };
            int guests = 2;

            //When
            Action nullRoomTest = () => bookingLogic.PriceCalculator(nullRoomPrice, guests);

            //Then
            nullRoomTest.Should().Throw<ArgumentNullException>();
        }
    }
}
