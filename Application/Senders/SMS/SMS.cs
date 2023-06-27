using System;
using Kavenegar;
using Kavenegar.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient;

namespace Application.Senders.SMS
{
    public class SMS : ISMS
    {
        public async void SMsS(string body, string to, string code)
        {


            SmsIr smsIr = new SmsIr("sLI6vchWcpoCesrsdrLvj22ZaXeafctpKuv2GRQC406tUev0cxt7N4IOCxPAI8BU");

            var bulkSendResult = await smsIr.BulkSendAsync(30007732009094, body, new string[] { to });

            var verificationSendResult = await smsIr.VerifySendAsync(to, 100000, new VerifySendParameter[] { new("Code", code) });



        }
    }
}
