using System;
using Core.Domain;

namespace SanatoriumApp.Domain.Bookings
{
    public class Booking : TrackableEntity
    {
        public int ClientId { get; set; }
        public int RoomId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
