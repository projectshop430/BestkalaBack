using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Senders.SMS
{
    public interface ISMS
    {
        void SMsS(string body, string to, string code);
    }
}
