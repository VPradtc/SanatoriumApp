using Core.Domain;

namespace SanatoriumApp.Domain.Clients
{
    public class Client : TrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
    }
}
