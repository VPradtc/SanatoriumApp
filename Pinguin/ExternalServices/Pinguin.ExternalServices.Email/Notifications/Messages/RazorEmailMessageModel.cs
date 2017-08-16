namespace Pinguin.ExternalServices.Email.Notifications.Messages
{
    public class RazorEmailMessageModel
    {
        public readonly string Subject;
        public readonly string TemplateFileName;

        public RazorEmailMessageModel(string subject, string templateFileName)
        {
            Subject = subject;
            TemplateFileName = templateFileName;
        }
    }
}
