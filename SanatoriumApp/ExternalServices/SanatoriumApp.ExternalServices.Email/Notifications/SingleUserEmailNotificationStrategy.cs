using SanatoriumApp.ExternalServices.Email.Core.Models;
using SanatoriumApp.ExternalServices.Email.Core;
using SanatoriumApp.ExternalServices.Email.Notifications.Messages;

namespace SanatoriumApp.ExternalServices.Email.Notifications
{
    public class SingleUserEmailNotificationStrategy<T> : SingleEmailNotificationStrategy<T>
        where T : RecipientMessageModel
    {
        public SingleUserEmailNotificationStrategy(
            IEmailService emailService, 
            IEmailMessageFactory<T> messageFactory) : base(emailService, messageFactory)
        {
        }

        public override string[] GetRecipients(T model)
        {
            return new[] { model.Email };
        }
    }
}
