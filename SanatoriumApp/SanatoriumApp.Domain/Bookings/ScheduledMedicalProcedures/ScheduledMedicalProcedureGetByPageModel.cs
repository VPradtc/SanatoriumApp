using System;
using Core.Domain;

namespace SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProcedureGetByPageModel : TrackableEntity
    {
        public int BookingId { get; set; }
        public int MedicalProcedureId { get; set; }
        public string MedicalProcedureName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
