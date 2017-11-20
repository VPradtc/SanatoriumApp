using System;

namespace SanatoriumApp.ExternalServices.Email.SendGrid.Configuration
{
    public class SendGridConfiguration
    {
        public string ApiKey { get; set; }
        public string EmailAddress { get; set; }
    }
}
