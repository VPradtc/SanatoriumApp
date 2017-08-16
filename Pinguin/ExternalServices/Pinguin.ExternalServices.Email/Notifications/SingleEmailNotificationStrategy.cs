using Pinguin.ExternalServices.Email.Core;
using Pinguin.ExternalServices.Email.Notifications.Messages;

namespace Pinguin.ExternalServices.Email.Notifications
{
    public abstract class SingleEmailNotificationStrategy<T> : IEmailNotificationStrategy<T>
    {
        private readonly IEmailService _emailService;
        private readonly IEmailMessageFactory<T> _messageFactory;

        public SingleEmailNotificationStrategy(
            IEmailService emailService,
            IEmailMessageFactory<T> messageFactory)
        {
            _emailService = emailService;
            _messageFactory = messageFactory;
        }
        public abstract string[] GetRecipients(T model);

        public void Execute(T model)
        {
            var messageTemplae = _messageFactory.Create(model);
            var recipients = GetRecipients(model);

            _emailService.SendMessage(messageTemplae, recipients);
        }
    }
}
