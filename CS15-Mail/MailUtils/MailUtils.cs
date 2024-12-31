using System.Net;
using System.Net.Mail;

namespace CS15_Mail.MailUtils;

public class MailUtils
{
    public static async Task<string> SendMail(string _from, string _to, string _subject, string _body)
    {
        //localhost la dia chi SMTP server
        //su dung lop MailMessage de tao mail 
        MailMessage message = new MailMessage(_from, _to, _subject, _body);
        message.BodyEncoding = System.Text.Encoding.UTF8; //ma hoa body sang UTF8( tieng viet)
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.IsBodyHtml = true; //cho phep hien thi html

        message.ReplyToList.Add(new MailAddress(_from)); //them dia chi nguoi gui vao danh sach reply
        message.Sender = new MailAddress(_from); //thiet lap nguoi gui

        using var smtpClient = new SmtpClient("localhost");
        try
        {
            await smtpClient.SendMailAsync(message);
            return "Send mail success!";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Send mail fail! " + ex.Message;
        }
    }
    public static async Task<string> SendGmail(string _gmail, string _password, string _to, string _subject, string _body)
    {
        //localhost la dia chi SMTP server
        //su dung lop MailMessage de tao mail 
        MailMessage message = new MailMessage() 
        {
            From = new MailAddress(_gmail),
            Subject = _subject,
            Body = _body,
            IsBodyHtml = true,
            BodyEncoding = System.Text.Encoding.UTF8,
            SubjectEncoding = System.Text.Encoding.UTF8,
        };
        message.To.Add(_to);
        message.ReplyToList.Add(new MailAddress("no-reply@example.com")); //them dia chi nguoi gui vao danh sach reply
        message.Sender = new MailAddress(_gmail); //thiet lap nguoi gui

        using var smtpClient = new SmtpClient("smtp.gmail.com");
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.Credentials = new NetworkCredential(_gmail, _password);
        try
        {
            await smtpClient.SendMailAsync(message);
            return "Send mail success!";
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "Send mail fail! " + ex.Message;
        }
    }
}