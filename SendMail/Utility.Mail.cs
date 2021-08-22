using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace SendMail.Utility.Mail
{
    public class MailSender
    {
        private SmtpClient client = new SmtpClient();

        public MailSender(string SenderAddress, string SenderPassword)
        {    
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SenderAddress, SenderPassword);
        }
        
        public void Send(string SenderAddress, string SenderName, string Subject, string Body, List<string> AttachmentPaths, List<string> ToAddress, List<string> CCAddress, List<string> BCCAddress )
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(SenderAddress, SenderName);
            message.IsBodyHtml = true;
            message.Subject = Subject;
            message.Body = Body;
            foreach (var path in AttachmentPaths)
            {
                message.Attachments.Add(new Attachment(path));
            }
            foreach (var addr in ToAddress)
            {
                message.To.Add(new MailAddress(addr));
            }
            foreach (var addr in CCAddress)
            {
                message.CC.Add(new MailAddress(addr));
            }
            foreach (var addr in BCCAddress)
            {
                message.Bcc.Add(new MailAddress(addr));
            }

            client.Send(message);
            message.Dispose();

            Console.WriteLine("Send Mail!");
        }
    }
}