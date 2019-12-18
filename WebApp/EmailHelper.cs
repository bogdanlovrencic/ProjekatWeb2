using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace JGSPNSWebApp
{
    public class EmailHelper
    {
        public static void SendMail(string emailTo, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress("titovrentavehicle@gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("titovrentavehicle@gmail.com", "drugtito");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

        }
    }
}