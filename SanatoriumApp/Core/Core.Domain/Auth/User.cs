using Core.Domain.Auth.Roles;

namespace Core.Domain.Auth
{
    public class User : TrackableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string ApiPasswordHash { get; set; }
        public string ApiPasswordSalt { get; set; }
        public decimal Salary { get; set; }

        public RoleIdentifier RoleId { get; set; }
    }
}
