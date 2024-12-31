using System.Net.Mail;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CS15_Mail.Service;

public class SendMailService
{
    MailSettings _mailSettings { get; set; }
    public SendMailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }
    public async Task<string> SendMail(MailContent mailContent)
    {
        var email = new MimeMessage();
        email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
        email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
        email.To.Add(MailboxAddress.Parse(mailContent.To));
        email.Subject = mailContent.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = mailContent.Body;
        
        email.Body = builder.ToMessageBody();   
        using var smtp = new MailKit.Net.Smtp.SmtpClient();

        try
        {
            await smtp.ConnectAsync(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Send mail fail! " + ex.Message;
        }
        smtp.Disconnect(true);
        return "Send mail success!";
    }
    
    public class MailContent
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}