using System;
using System.Collections.Generic;
using SendMail.Utility.Mail;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            MailSender Sender = new MailSender("sender mail", "sender password");
            Sender.Send(
                SenderAddress : "sender mail", 
                SenderName : "sender name", 
                Subject : "mail title", 
                Body : "mail content", 
                AttachmentPaths : new List<string>(){ "file path" }, 
                ToAddress : new List<string>(){"receiver mail", "receiver mail2"}, 
                CCAddress : new List<string>(){"copy receiver mail"}, 
                BCCAddress : new List<string>(){"bcc copy receiver mail"}
            );
        }
    }
}
