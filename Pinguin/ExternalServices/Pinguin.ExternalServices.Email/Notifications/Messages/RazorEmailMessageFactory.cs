using Pinguin.ExternalServices.Email.Core.Messages;
using RazorEngine;
using System;
using System.IO;
using RazorEngine.Templating;

using MailPreprocessor = PreMailer.Net.PreMailer;

namespace Pinguin.ExternalServices.Email.Notifications.Messages
{
    public abstract class RazorEmailMessageFactory<T> : IEmailMessageFactory<T>
    {
        private readonly string _pathPrefix = @"..\ExternalServices\Pinguin.ExternalServices.Email\MessageTemplates\";

        private string CreateWebFilePath(RazorEmailMessageModel model, string extension)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _pathPrefix, $"{model.TemplateFileName}.{extension}");
        }

        private string CreateCacheKey(RazorEmailMessageModel model)
        {
            var modelTypeSuffix = typeof(T).Name;

            return String.Format("{0}_{1}", model.TemplateFileName, modelTypeSuffix);
        }

        private string CreateMessageBody(T model, RazorEmailMessageModel razorMessageModel, string templateCacheKey)
        {
            if (Engine.Razor.IsTemplateCached(templateCacheKey, model.GetType()))
            {
                return Engine.Razor.Run(templateCacheKey, model.GetType(), model);
            }

            var templatePath = CreateWebFilePath(razorMessageModel, "cshtml");
            var rawBody = File.ReadAllText(templatePath);

            return Engine.Razor.RunCompile(rawBody, templateCacheKey, model.GetType(), model);
        }

        private string GetCssInlinedHtml(string basicHtml, RazorEmailMessageModel razorMessageModel)
        {
            var cssString = File.ReadAllText(CreateWebFilePath(razorMessageModel, "css"));

            return MailPreprocessor.MoveCssInline(basicHtml, css: cssString).Html;
        }

        public abstract RazorEmailMessageModel GetMessageModel(T model);

        public MessageTemplate Create(T model)
        {
            var razorMessageModel = GetMessageModel(model);

            var templateCacheKey = CreateCacheKey(razorMessageModel);
            var compiledBody = CreateMessageBody(model, razorMessageModel, templateCacheKey);

            var body = GetCssInlinedHtml(compiledBody, razorMessageModel);

            return new MessageTemplate(razorMessageModel.Subject, body);
        }
    }
}
