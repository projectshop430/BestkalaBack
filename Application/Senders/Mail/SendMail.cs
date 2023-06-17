using System;
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

                MailMessage msg = new MailMessage();

                msg.From = new MailAddress("datingapp1402@gmail.com");
                msg.To.Add(to.ToString());
                msg.Subject = subject;
                msg.Body = body.ToString();
                //msg.Priority = MailPriority.High;


                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("datingapp1402@gmail.com", "jajepybekzwuncdg");
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(msg);
                }



            }
            catch (Exception e)
            {

            }
        }
    }
}
