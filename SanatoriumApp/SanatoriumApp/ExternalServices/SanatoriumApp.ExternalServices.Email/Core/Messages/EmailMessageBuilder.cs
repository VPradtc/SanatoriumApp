using System.Net.Mail;
using SanatoriumApp.ExternalServices.Email.Core.Configuration;

namespace SanatoriumApp.ExternalServices.Email.Core.Messages
{
    public class EmailMessageBuilder : IEmailMessageBuilder
    {
        public MailMessage Construct(SmtpConfiguration configuration, MessageTemplate messageTemplate)
        {
            return new MailMessage
            {
                From = new MailAddress(configuration.EmailFrom),
                Subject = messageTemplate.Subject,
                Body = messageTemplate.Body,
                IsBodyHtml = configuration.IsBodyHtml
            };
        }
    }
}
