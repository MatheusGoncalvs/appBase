using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBase.Services
{
    public class NullMailService : INullMailService
    {
        private readonly ILogger<NullMailService> logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            this.logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {
            //Log the message
            logger.LogInformation($"To: {to} Subject: {subject} Body: {body}.");
        }
    }
}
