using SanatoriumApp.ExternalServices.Email.Core.Configuration;
using System.Net.Mail;

namespace SanatoriumApp.ExternalServices.Email.Core.Messages
{
    public interface IEmailMessageBuilder
    {
        MailMessage Construct(SmtpConfiguration configuration, MessageTemplate messageTemplate);
    }
}
