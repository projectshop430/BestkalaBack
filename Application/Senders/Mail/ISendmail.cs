using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Senders.Mail
{
    public interface ISendmail
    {
        void send(string to, string subject, string body);
    }
}
