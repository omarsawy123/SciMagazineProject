using Microsoft.Extensions.Options;
using SciMagazine.Application.DTOs;
using SciMagazine.Application.Interfaces.IServices;
using SciMagazine.Infrastructure.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SciMagazine.Infrastructure.Services
{
    public class EmailServices : IEmailServices
    {

        private readonly SendGridOptions _emailOptions;
        public EmailServices(IOptions<SendGridOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        public async Task<bool> SendRegisterRequestEmailToAdmin(RegisterRequestDto request)
        {
            await SendEmailAsync(request.Email, "Register application status", $"Test Email for ${request.UserName}");
            return true;
        }

        private async Task SendMail()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }


        public async Task SendEmailAsync(
            string toEmail,
            string subject,
            string plainTextContent,
            string htmlContent = "")
        {
            var client = new SendGridClient(_emailOptions.ApiKey);
            var from = new EmailAddress("omarsawy51@gmail.com", "");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }

}
