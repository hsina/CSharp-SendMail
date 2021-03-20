using System;
using System.Net;
using System.Net.Mail;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("寄件信箱", "寄件信箱密碼");

            MailMessage message = new MailMessage();

            message.From = new MailAddress("寄件地址", "寄件人名稱");
            message.IsBodyHtml = true;
            message.Subject = "C#信件主旨";
            message.Body = "<h1>信件內容</h1>";
            message.To.Add(new MailAddress("receiver mail"));
            message.To.Add(new MailAddress("receiver mail2"));
            message.CC.Add(new MailAddress("copy receiver mail"));
            message.Bcc.Add(new MailAddress("bcc receiver mail"));
            message.Attachments.Add(new Attachment([Attachment location(String Format)]));

            client.Send(message);
            message.Dispose();

            Console.WriteLine("Send Mail!");
        }
    }
}
