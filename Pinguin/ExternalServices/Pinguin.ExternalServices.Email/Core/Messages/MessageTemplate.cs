namespace Pinguin.ExternalServices.Email.Core.Messages
{
    public class MessageTemplate
    {
        public readonly string Subject;
        public readonly string Body;

        public MessageTemplate(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
