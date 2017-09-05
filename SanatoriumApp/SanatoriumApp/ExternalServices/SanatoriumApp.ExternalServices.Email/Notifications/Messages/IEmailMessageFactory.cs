using SanatoriumApp.ExternalServices.Email.Core.Messages;

namespace SanatoriumApp.ExternalServices.Email.Notifications.Messages
{
    public interface IEmailMessageFactory<T>
    {
        MessageTemplate Create(T model);
    }
}
