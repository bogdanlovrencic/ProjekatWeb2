using JGSPNSWebApp.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace JGSPNSWebApp.Controllers
{
    public class ServiceController : ApiController
    {
        private IUnitOfWork unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
      

        public bool SendMail(string emailTo, string subject, string body)
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
           

                return true;
        }
    }
}
