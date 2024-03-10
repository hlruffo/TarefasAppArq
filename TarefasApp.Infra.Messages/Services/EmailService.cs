using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TarefasApp.Infra.Messages.Models;
using TarefasApp.Infra.Messages.Settings;

namespace TarefasApp.Infra.Messages.Services
{
    public class EmailService
    {
        private readonly EmailSettings? _emailSettings;

        public EmailService(EmailSettings? emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public void SendEmail(EmailMessageModel model)
        {
            var mailMessage = new MailMessage(_emailSettings.Email, model.To);
            mailMessage.Subject = model.Subject;
            mailMessage.Body = model.Body;

            var smtpClient = new SmtpClient(_emailSettings.Smtp, _emailSettings.Port);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.Send(mailMessage);
        }
    }
}
