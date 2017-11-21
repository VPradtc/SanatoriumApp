using System;
using Core.Domain;

namespace SanatoriumApp.Domain.Bookings
{
    public class BookingGetByPageModel : TrackableEntity
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int RoomId { get; set; }
        public string RoomName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
