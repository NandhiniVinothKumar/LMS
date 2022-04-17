using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using DataLayer.Interface;
using System.IO;

namespace BusinessLayer
{
    public class EmailService: IMailRepository
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.Sender = MailboxAddress.Parse(_emailSettings.Mail);
            mimeMessage.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            mimeMessage.Subject = mailRequest.Subject;
            var _builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        _builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            try
            {
                _builder.HtmlBody = mailRequest.Body;
                mimeMessage.Body = _builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
                await smtp.SendAsync(mimeMessage);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }


        }
    }
   
    public class EmailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }

}
