using System.Threading.Tasks;
using SanatoriumApp.ExternalServices.Email.Core.Messages;
using SanatoriumApp.ExternalServices.Email.Core.Configuration;
using System.Net.Mail;
using System.Net;
using System.Web.Hosting;
using Core.Logging;

namespace SanatoriumApp.ExternalServices.Email.Core
{
    public class EmailService : IEmailService
    {
        private readonly SmtpConfiguration _smtpConfiguration;
        private readonly IEmailMessageBuilder _messageBuilder;
        private readonly IApplicationLogger _logger;

        public EmailService(
            IEmailConfigurationFactory configurationFactory,
            IEmailMessageBuilder messageBuilder,
            IApplicationLogger logger)
        {
            _smtpConfiguration = configurationFactory.GetSmtpConfiguration();
            _messageBuilder = messageBuilder;
            _logger = logger;
        }

        public void SendMessage(MessageTemplate messageTemplate, params string[] emailTo)
        {
            var mail = _messageBuilder.Construct(_smtpConfiguration, messageTemplate);

            foreach (var recipient in emailTo)
            {
                mail.To.Add(recipient);
            }

            var smtp = new SmtpClient(_smtpConfiguration.SmtpAddress, _smtpConfiguration.PortNumber)
            {
                UseDefaultCredentials = _smtpConfiguration.UseDefaultCredentials,
                Timeout = _smtpConfiguration.Timeout,
                Credentials = new NetworkCredential(_smtpConfiguration.EmailFrom, _smtpConfiguration.Password),
                EnableSsl = _smtpConfiguration.EnableSsl
            };

            _logger.Information("Sending email... {mailMessage}", mail);
            HostingEnvironment.QueueBackgroundWorkItem(ct => SendMailAsync(mail, smtp));
        }

        private async Task SendMailAsync(MailMessage mail, SmtpClient smtp)
        {
            await smtp.SendMailAsync(mail).ContinueWith((task) =>
            {
                smtp.Dispose();
                mail.Dispose();

                if (task.Status == TaskStatus.Faulted)
                {
                    _logger.Error(task.Exception, "Failed to deliver email {mailMessage}", mail);
                    throw task.Exception;
                }

            });
        }
    }
}
