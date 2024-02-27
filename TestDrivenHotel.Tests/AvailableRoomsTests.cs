using FluentAssertions;
using TestDrivenHotel.DAL.Models;
using TestDrivenHotel.Logic;
using Xunit;

namespace TestDrivenHotel.Tests
{
    public class AvailableRoomsTests
    {

        List<RoomModel> testRooms =
        [
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
        ];

        // Tests of booking models

        List<BookingModel> testBookings =
        [
            new BookingModel
            {
                Id = 1,
                RoomId = 1,
                StartDate = new DateTime(2024, 3, 22),
                EndDate = new DateTime(2024, 3, 26),
                BookingCreated = DateTime.Now,
                Special = "Family vacation"
            },
            new BookingModel
            {
                Id = 2,
                RoomId = 2,
                StartDate = new DateTime(2024, 3, 21),
                EndDate = new DateTime(2024, 3, 24),
                BookingCreated = DateTime.Now,
                Special = "Long weekend"
            },
            new BookingModel
            {
                Id = 3,
                RoomId = 3,
                StartDate = new DateTime(2024, 4, 19),
                EndDate = new DateTime(2024, 4, 25),
                BookingCreated = DateTime.Now,
                Special = " "
            },
        ];


        // Feature test

        [Fact]
        public void FilterFeatures_OceanView_ShouldReturnOneRoomsWithAnOceanView()
        {
            //Given
            string feature = "OceanView";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);
            var expectedRooms = rooms.Where(f => f.OceanView == true).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(2);
        }
        [Fact]
        public void FilterFeatures_NoRoomsWithOceanView_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> roomsWithNoOceanView =
            [
                new RoomModel
                {
                    Id = 2,
                    Description = "Standard Room",
                    Price = 400,
                    MaxGuests = 2,
                    OceanView = false,
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
            ];
            string feature = "OceanView";
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(roomsWithNoOceanView, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }


        [Fact]
        public void FilterFeatures_NoBalconyRooms_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> roomsWithNoBalcony =
            [
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
                    Description = "Standard Room",
                    Price = 400,
                    MaxGuests = 2,
                    OceanView = true,
                    Balcony = false
                },
            ];
            string feature = "Balcony";
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(roomsWithNoBalcony, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_nullRoomsList_ShouldThrowArgumentNullException()
        {
            //Given
            List<RoomModel>? nullRoomsList = null;
            string feature = "Balcony";
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterFeatures(nullRoomsList, feature);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterFeatures_InvalidFeature_ShouldReturnEmptyList()
        {
            //Given
            string feature = "Tesla coil";
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterFeatures(rooms, feature);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        [Fact]
        public void FilterFeatures_NullFeatures_ShouldThrowArgumnentNullException()
        {
            //Given
            string? nullFeature = null;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterFeatures(rooms, nullFeature);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        // Guests filter tests

        [Fact]
        public void FilterGuests_nullRoomsList_ShouldThrowArgumentNullException()
        {
            //Given
            List<RoomModel>? nullRoomsList = null;
            int guests = 2;
            BookingLogic bookingLogic = new();

            //When
            Action nullListTest = () => bookingLogic.FilterGuests(nullRoomsList, guests);

            //Then
            nullListTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterGuests_NormalNumber_ShouldReturnOneRoom()
        {
            //Given
            int guests = 3;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterGuests(rooms, guests);
            var expectedRooms = rooms.Where(r => r.MaxGuests >= guests).ToList();

            //Then
            actualRooms.Should().BeEquivalentTo(expectedRooms);
            actualRooms.Should().BeOfType<List<RoomModel>>();
            actualRooms.Should().NotBeNullOrEmpty();
            actualRooms.Should().HaveCount(2);
        }

        [Fact]
        public void FilterGuests_EmptyRoomsList_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> emptyRoomsList = [];
            int guests = 2;
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterGuests(emptyRoomsList, guests);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().BeOfType<List<RoomModel>>();
            emptyList.Should().NotBeNull();
        }

        [Fact]
        public void FilterGuests_NullGuests_ShouldThrowArgumnentNullException()
        {
            //Given
            int nullGuests = 0;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            Action nullFeatureTest = () => bookingLogic.FilterGuests(rooms, nullGuests);

            //Then
            nullFeatureTest.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void FilterGuests_LargeNumber_ShouldReturnEmptyList()
        {
            //Given
            int guests = 33;
            List<RoomModel> rooms = testRooms;
            BookingLogic bookingLogic = new();

            //When
            var actualRooms = bookingLogic.FilterGuests(rooms, guests);

            //Then
            actualRooms.Should().BeEmpty();
            actualRooms.Should().BeOfType<List<RoomModel>>();
        }

        // Filter date test

        [Fact]
        public void FilterDates_EmptyRoomList_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> emptyRoomList = [];
            List<BookingModel>? bookings = testBookings;
            DateTime arrivalDate = new(2024, 07, 07);
            DateTime departureDate = new(2024, 07, 14);
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.FilterDates(emptyRoomList, bookings, arrivalDate, departureDate);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().NotBeNull();
            emptyList.Should().BeOfType<List<RoomModel>>();
        }

        // Available room test

        [Fact]
        public void GetAvailableRooms_EmptyRoomList_ShouldReturnEmptyList()
        {
            //Given
            List<RoomModel> emptyRoomList = [];
            List<BookingModel>? bookings = testBookings;
            string feature = "None";
            int guests = 1;
            DateTime arrivalDate = new(2024, 07, 07);
            DateTime departureDate = new(2024, 07, 14);
            BookingLogic bookingLogic = new();

            //When
            var emptyList = bookingLogic.GetAvailableRooms(emptyRoomList, bookings, feature, guests, arrivalDate, departureDate);

            //Then
            emptyList.Should().BeEmpty();
            emptyList.Should().NotBeNull();
            emptyList.Should().BeOfType<List<RoomModel>>();
        }
    }
}