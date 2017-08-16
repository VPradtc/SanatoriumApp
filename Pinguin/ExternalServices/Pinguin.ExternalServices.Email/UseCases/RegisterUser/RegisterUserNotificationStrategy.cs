using Pinguin.ExternalServices.Email.Notifications;
using Pinguin.ExternalServices.Email.Core;
using Pinguin.ExternalServices.Email.Notifications.Messages;

namespace Pinguin.ExternalServices.Email.UseCases.RegisterUser
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
