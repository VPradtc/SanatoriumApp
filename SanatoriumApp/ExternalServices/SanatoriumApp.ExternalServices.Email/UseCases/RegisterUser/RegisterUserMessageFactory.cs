using SanatoriumApp.ExternalServices.Email.Notifications.Messages;

namespace SanatoriumApp.ExternalServices.Email.UseCases.RegisterUser
{
    public class RegisterUserMessageFactory : RazorEmailMessageFactory<RegisterUserMessageModel>
    {
        public override RazorEmailMessageModel GetMessageModel(RegisterUserMessageModel model)
        {
            return new RazorEmailMessageModel(
                subject: "Notifications - User Registration",
                templateFileName: @"RegisterUser/ViewTemplate");
        }
    }
}
