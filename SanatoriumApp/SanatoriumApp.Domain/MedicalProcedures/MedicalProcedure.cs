using Core.Domain;

namespace SanatoriumApp.Domain.MedicalProcedures
{
    public class MedicalProcedure : TrackableEntity
    {
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
    }
}
