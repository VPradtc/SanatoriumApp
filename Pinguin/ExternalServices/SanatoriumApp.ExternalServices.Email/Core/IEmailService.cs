using SanatoriumApp.ExternalServices.Email.Core.Messages;

namespace SanatoriumApp.ExternalServices.Email.Core
{
    public interface IEmailService
    {
        void SendMessage(MessageTemplate messageTemplate, params string[] emailTo);
    }
}
