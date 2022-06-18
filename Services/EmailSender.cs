using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LaboratorioAzure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        public EmailOptions Options { get; } // Set with secret manager

        public EmailSender(IOptions<EmailOptions> optionAccesor, ILogger<EmailSender> logger) //inyeccion de dependencias
        {
            Options = optionAccesor.Value;
            _logger = logger;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }

            await Execute(Options.SendGridKey, subject, htmlMessage, toEmail);
        }

        private async Task Execute(string apikey, string subject, string htmlMessage, string toEmail)
        {
            var client = new SendGridClient(apikey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("jpsanabria37@misena.edu.co", "Recuperación contraseña"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(toEmail));
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode ? $"Email to {toEmail} queued successfully" : $"Failure Email to {toEmail}");
        }
    }
}
