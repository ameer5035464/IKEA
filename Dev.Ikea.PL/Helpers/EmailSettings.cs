using Dev.Ikea.DAL.Models;
using Dev.Ikea.PL.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Dev.Ikea.PL.Helpers
{
    public class EmailSettings(IOptions<MailSettings> options) : IEmailSettings
    {
        public void SendEmail(Email email)
        {
            var mail = new MimeMessage
            {
                Sender = new MailboxAddress(options.Value.DisplayName, options.Value.Email),
                Subject = email.Subject,
                Body = new BodyBuilder()
                {
                    TextBody = email.Body
                }.ToMessageBody()
            };
            mail.To.Add(new MailboxAddress(string.Empty, email.To));
            mail.From.Add(new MailboxAddress(options.Value.DisplayName, options.Value.Email));


            using var smtp = new SmtpClient();
            smtp.Connect(options.Value.Host, options.Value.Port,MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(options.Value.Email, options.Value.Password);
            smtp.Send(mail);
            smtp.Disconnect(true);
        }

    }
}
