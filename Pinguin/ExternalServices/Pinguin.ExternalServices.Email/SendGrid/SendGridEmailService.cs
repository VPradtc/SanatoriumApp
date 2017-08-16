using System;
using Pinguin.ExternalServices.Email.Core;
using Pinguin.ExternalServices.Email.Core.Messages;
using Pinguin.ExternalServices.Email.SendGrid.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Pinguin.ExternalServices.Email.SendGrid
{
    public class SendGridEmailService : IEmailService
    {
        private readonly SendGridConfiguration _config;

        public SendGridEmailService(SendGridConfigurationFactory configFactory)
        {
            _config = configFactory.Create();
        }

        public void SendMessage(MessageTemplate messageTemplate, params string[] emailTo)
        {
            var client = new SendGridClient(_config.ApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_config.EmailAddress, "Pinguin Team"),
                Subject = messageTemplate.Subject,
                PlainTextContent = "ERROR: Please enable HTML to render the contents of this message..",
                HtmlContent = messageTemplate.Body
            };

            foreach (var recipient in emailTo)
            {
                msg.AddTo(new EmailAddress(recipient));
            }
            var task = client.SendEmailAsync(msg);
            var result = task.Result;

            System.Diagnostics.Debug.WriteLine(result.ToString());
        }
    }
}
