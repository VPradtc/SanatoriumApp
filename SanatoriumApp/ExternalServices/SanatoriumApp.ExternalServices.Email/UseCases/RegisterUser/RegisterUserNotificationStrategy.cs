using SanatoriumApp.ExternalServices.Email.Notifications;
using SanatoriumApp.ExternalServices.Email.Core;
using SanatoriumApp.ExternalServices.Email.Notifications.Messages;

namespace SanatoriumApp.ExternalServices.Email.UseCases.RegisterUser
{
    public class RegisterUserNotificationStrategy : SingleUserEmailNotificationStrategy<RegisterUserMessageModel>
    {
        public RegisterUserNotificationStrategy(
            IEmailService emailService, 
            IEmailMessageFactory<RegisterUserMessageModel> messageFactory) : base(emailService, messageFactory)
        {
        }
    }
}
