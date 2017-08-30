using SanatoriumApp.ExternalServices.Email.Core.Models;

namespace SanatoriumApp.ExternalServices.Email.UseCases.RegisterUser
{
    public class RegisterUserMessageModel : RecipientMessageModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
