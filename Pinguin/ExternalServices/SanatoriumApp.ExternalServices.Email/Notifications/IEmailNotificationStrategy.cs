namespace SanatoriumApp.ExternalServices.Email.Notifications
{
    public interface IEmailNotificationStrategy<T>
    {
        void Execute(T model);
    }
}
