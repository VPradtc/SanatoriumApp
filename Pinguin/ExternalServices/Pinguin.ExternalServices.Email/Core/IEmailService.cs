using Pinguin.ExternalServices.Email.Core.Messages;

namespace Pinguin.ExternalServices.Email.Core
{
    public interface IEmailService
    {
        void SendMessage(MessageTemplate messageTemplate, params string[] emailTo);
    }
}
