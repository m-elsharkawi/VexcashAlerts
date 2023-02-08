using EmailService.Interfaces;
using EmailService.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailService.Controllers
{
    public class SendGridEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<EmailResponse> SendEmailAsync(EmailMessage emailMessage)
        {
            var apiKey = _configuration.GetValue<string>("SendGridApiKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailMessage.FromEmail, emailMessage.FromName);
            var to = new EmailAddress(emailMessage.ToEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, emailMessage.Subject, emailMessage.Message, emailMessage.Message);
            var response = await client.SendEmailAsync(msg);
            return new EmailResponse
            {
                Success = response.StatusCode == System.Net.HttpStatusCode.Accepted,
                Message = response.Body.ReadAsStringAsync().Result
            };
        }
    }
}
