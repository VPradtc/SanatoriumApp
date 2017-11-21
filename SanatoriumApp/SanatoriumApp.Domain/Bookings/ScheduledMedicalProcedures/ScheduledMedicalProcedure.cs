using System;
using Core.Domain;

namespace SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProcedure : TrackableEntity
    {
        public int BookingId { get; set; }
        public int MedicalProcedureId { get; set; }
        public int UserId { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
