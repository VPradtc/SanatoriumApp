using Pinguin.ExternalServices.Email.Core.Models;
using Pinguin.ExternalServices.Email.Core;
using Pinguin.ExternalServices.Email.Notifications.Messages;

namespace Pinguin.ExternalServices.Email.Notifications
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
