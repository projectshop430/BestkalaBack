﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Senders.Mail
{
    public class SendMail :ISendmail
    {
       

        public void send(string to, string subject, string body)
        {
            try
            {

                var mail = new MailMessage();

                var smtpServer = new SmtpClient("smtp");

                mail.From = new MailAddress("email address", "Dating app");

                mail.To.Add(to);

                mail.Subject = subject;

                mail.Body = body;

                mail.IsBodyHtml = true;

                 

                smtpServer.Credentials = new NetworkCredential("email address", "password");

                smtpServer.EnableSsl = false;

                smtpServer.Send(mail);
            }
            catch (Exception e)
            {

            }
        }
    }
}
