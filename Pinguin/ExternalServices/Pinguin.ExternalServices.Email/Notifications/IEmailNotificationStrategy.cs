namespace Pinguin.ExternalServices.Email.Notifications
{
    public interface IEmailNotificationStrategy<T>
    {
        void Execute(T model);
    }
}
