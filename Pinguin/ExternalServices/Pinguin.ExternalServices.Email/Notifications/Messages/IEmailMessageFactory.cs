using Pinguin.ExternalServices.Email.Core.Messages;

namespace Pinguin.ExternalServices.Email.Notifications.Messages
{
    public interface IEmailMessageFactory<T>
    {
        MessageTemplate Create(T model);
    }
}
