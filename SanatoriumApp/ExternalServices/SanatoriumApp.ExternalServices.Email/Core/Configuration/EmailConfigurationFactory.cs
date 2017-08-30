using System;
using System.Configuration;

namespace SanatoriumApp.ExternalServices.Email.Core.Configuration
{
    public class EmailConfigurationFactory : IEmailConfigurationFactory
    {
        public SmtpConfiguration GetSmtpConfiguration()
        {
            return new SmtpConfiguration
            {
                PortNumber = Int32.Parse(ConfigurationManager.AppSettings["email:PortNumber"]),
                Timeout = Int32.Parse(ConfigurationManager.AppSettings["email:Timeout"]),
                EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["email:EnableSsl"]),
                UseDefaultCredentials = Boolean.Parse(ConfigurationManager.AppSettings["email:UseDefaultCredentials"]),
                IsBodyHtml = Boolean.Parse(ConfigurationManager.AppSettings["email:IsBodyHtml"]),
                SmtpAddress = ConfigurationManager.AppSettings["email:SmtpAddress"],
                EmailFrom = ConfigurationManager.AppSettings["email:EmailFrom"],
                Password = ConfigurationManager.AppSettings["email:Password"]
            };
        }
    }
}
