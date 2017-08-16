using Pinguin.ExternalServices.Email.Core.Configuration;
using System.Net.Mail;

namespace Pinguin.ExternalServices.Email.Core.Messages
{
    public interface IEmailMessageBuilder
    {
        MailMessage Construct(SmtpConfiguration configuration, MessageTemplate messageTemplate);
    }
}
