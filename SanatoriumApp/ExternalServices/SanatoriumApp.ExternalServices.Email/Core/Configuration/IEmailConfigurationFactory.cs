namespace SanatoriumApp.ExternalServices.Email.Core.Configuration
{
    public interface IEmailConfigurationFactory
    {
        SmtpConfiguration GetSmtpConfiguration();
    }
}
