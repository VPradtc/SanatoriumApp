namespace Pinguin.ExternalServices.Email.Core.Configuration
{
    public interface IEmailConfigurationFactory
    {
        SmtpConfiguration GetSmtpConfiguration();
    }
}
