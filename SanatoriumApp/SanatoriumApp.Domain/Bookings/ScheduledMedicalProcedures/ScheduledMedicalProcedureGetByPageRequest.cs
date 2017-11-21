using Core.Domain.Common;

namespace SanatoriumApp.Domain.Bookings.ScheduledMedicalProcedures
{
    public class ScheduledMedicalProcedureGetByPageRequest : KendoGridRequest
    {
        public int BookingId { get; set; }
    }
}
