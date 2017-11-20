using System;
using System.Configuration;

namespace SanatoriumApp.ExternalServices.Email.SendGrid.Configuration
{
    public class SendGridConfigurationFactory
    {
        public SendGridConfiguration Create()
        {
            return new SendGridConfiguration
            {
                ApiKey = ConfigurationManager.AppSettings["sendGrid:ApiKey"],
                EmailAddress = ConfigurationManager.AppSettings["sendGrid:EmailAddress"],
            };
        }
    }
}
