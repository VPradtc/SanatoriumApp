namespace SanatoriumApp.ExternalServices.Email.Core.Configuration
{
    public class SmtpConfiguration
    {
        public int PortNumber { get; set; }
        public int Timeout { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool IsBodyHtml { get; set; }
        public string SmtpAddress { get; set; }
        public string EmailFrom { get; set; }
        public string Password { get; set; }
    }
}
